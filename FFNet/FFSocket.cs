using FFNet.Packets.Gss;
using FFNet.Packets.Gss.Fury_Messages;
using FFNet.Packets.Gss.Proto_Packets;
using FFNet.Packets.Matrix;
using Flare.Binary;
using NLog;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace FFNet
{

    // The main game socket
    public class FFSocket
    {
        // Internal
        private static Logger logger = LogManager.GetLogger("FFSocket");

        private UdpClient Socket;
        private IPEndPoint EndPoint;
        public uint SocketID { get; private set; }
        public static readonly byte[] ResendXors = new byte[] { 0x0, 0xFF, 0xAA, 0xCC }; // Used to decode data in resent pacakets

        // Public
        public SocketState State { get; private set; } = SocketState.NOT_OPENED;
        public bool ShouldListen { get; private set; } = false;
        public Mode Mode { get; set; } = Mode.Normal;
        public ushort CurrentSendSeqNum { get; private set; }
        public ushort CurrentRecvSeqNum { get; private set; }

        // Event handlers for message types
        public event MatrixMessageDelegate          OnMatrixMsgRecv;
        public event GssRawMessageDelegate          OnGssRawMsgRecv;
        public event GssProtoMessageDelegate        OnGssProtoMsgRecv;
        public event GssFuryMessageDelegate         OnGssFuryRecv;
        public event SocketClosedDelegate           OnSocketClosed;

        public FFSocket()
        {

        }

        public void Listen(ushort Port)
        {
            Socket = new UdpClient(Port);
            ShouldListen = true;
            StartRecv();

            logger.Info($"Socket listening on {Port}");
        }

        public void Bind(ushort Port, uint SocketID, ushort SeqNumStart, IPEndPoint ClientEndPoint)
        {
            Listen(Port);
            EndPoint = ClientEndPoint;
            this.SocketID = SocketID;
            CurrentSendSeqNum = SeqNumStart;
            CurrentRecvSeqNum = SeqNumStart;
            State = SocketState.CONNECTING;

            logger.Trace($"Socket bound to {Port} : {SocketID}");
        }

        public void Stop()
        {
            ShouldListen = false;
        }

        private void Close()
        {
            ChangeState(SocketState.CLOSING);
            Stop();

            var closeMsg = new CloseConnectionMsg();
            SendImmediate(closeMsg);
            OnSocketClosed?.Invoke(this);
        }

        private void StartRecv()
        {
            Socket.BeginReceive(new AsyncCallback(OnRecv), null);
        }

        private void OnRecv(IAsyncResult Result)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 0);
            var data = Socket.EndReceive(Result, ref ip);

            HandleMessage(data, ip);

            if (ShouldListen)
            {
                StartRecv();
            }
        }

        // Public so we can feed in packet captures as well
        public void HandleMessage(byte[] Data, IPEndPoint From)
        {
            // For debugging
            byte[] rawBytes = null;
            if (Mode == Mode.NoReply)
            {
                rawBytes = new byte[Data.Length];
                Array.Copy(Data, rawBytes, rawBytes.Length);
            }

            using (var r = new Reader(Data, Endianness.BigEndian))
            {
                // Parse the common headers
                uint sockID = r.UInt();

                logger.Trace("Got UDP message");
                if (sockID == 0) // Is a matrix message
                {
                    OnMatrixMessage(r, From, rawBytes);
                }
                else
                {
                    OnGssMessage(r, From);
                }
            }
        }

        private void OnMatrixMessage(Reader R, IPEndPoint From, byte[] RawBytes)
        {
            var type = R.Char(4);
            R.BaseStream.Seek(-4, System.IO.SeekOrigin.Current);
            BaseMatrixMessage matrixMsg = null;

            switch (new string(type))
            {
                case "POKE":
                    matrixMsg = new PokeMsg(R);
                    break;

                case "HEHE":
                    matrixMsg = new HeheMsg(R);
                    break;

                case "HUGG":
                    matrixMsg = new HuggMsg(R);
                    break;

                case "KISS":
                    matrixMsg = new KissMsg(R);
                    break;

                case "ABRT":
                    matrixMsg = new AbortMsg(R);
                    break;
            }

            OnMatrixMsgRecv?.Invoke(matrixMsg, From, RawBytes);
        }

        private void OnGssMessage(Reader R, IPEndPoint From)
        {
            // Split out the packets from the sent blob
            do
            {
                var header = new GssHeader(R); // Common header

                if (header.IsProtocolPacket)
                {
                    OnGssProtoMessage(R, header); // Time syncs, acks etc
                }
                else
                {
                    // TODO: Handle out of sync messages
                    if (header.SeqNum >= CurrentRecvSeqNum)
                    {
                        CurrentRecvSeqNum = header.SeqNum;
                        OnGssFuryMessage(R, header);
                    }
                    else
                    {
                        logger.Trace($"Recved stale message, seq {header.SeqNum} > {CurrentRecvSeqNum}");
                        R.Byte((int)header.Length);
                    }
                }


                // Raw message
                if (OnGssRawMsgRecv != null)
                {
                    R.BaseStream.Seek((int)header.Length, SeekOrigin.Current);
                    var unknowMsg = new GssUnknown();
                    unknowMsg.Payload = R.Byte((int)header.Length);
                    OnGssRawMsgRecv?.Invoke(header, unknowMsg, this);
                }
            }
            while (R.BaseStream.Position < R.BaseStream.Length);
        }

        // Stuff like ack, time syncs and so forth
        private void OnGssProtoMessage(Reader R, GssHeader Header)
        {
            BaseProtoMsg msg = null;

            switch (Header.MsgID)
            {
                case TimeSyncRequest.MSG_ID:
                    msg = Recv_TimeSyncReq(R, Header);
                    break;

                case CloseConnectionMsg.MSG_ID:
                    msg = new CloseConnectionMsg(R);

                    if (((CloseConnectionMsg)msg).IsValidClose())
                    {
                        Close();
                    }

                    break;

                case Ack.MSG_ID:
                    msg = Recv_Ack(R, Header);
                    break;

                // Even if we don't know what it is we need to consume those bytes, nom nom
                default:
                    var bytes = R.Byte((int)Header.Length);
                    break;
            }

            OnGssProtoMsgRecv?.Invoke(Header, msg, this);
        }

        private void OnGssFuryMessage(Reader R, GssHeader Header)
        {
            BaseFuryMsg msg = null;
            R = DecodeResentData(R, Header);

            logger.Trace($"Resends: {Header.ResendCount}");

            // Unknown for now
            FuryUnknownMsg unk = new FuryUnknownMsg();
            unk.Payload = R.Byte((int)Header.Length );

            OnGssFuryRecv?.Invoke(Header, unk, this);
        }

        #region Proto Message Handlers
        private Ack Recv_Ack(Reader R, GssHeader Header)
        {
            var ack = new Ack(R);

            logger.Trace($"Recived ack for {ack.AckFor} was in {ack.SeqNum}");

            return ack;
        }

        private TimeSyncRequest Recv_TimeSyncReq(Reader R, GssHeader Header)
        {
            var tsReq = new TimeSyncRequest(R);

            // Reply
            var reply = new TimeSyncResponse(((TimeSyncRequest)tsReq).ClientTimeUnix);
            SendImmediate(reply);

            logger.Trace($"Got a timesync req, {((TimeSyncRequest)tsReq).ClientTimeUnix}");

            return tsReq;
        }
        #endregion

        #region Send functions
        // Sends a matrix message right away
        public void SendImmediate(BaseMatrixMessage MatrixMsg, IPEndPoint SendTo = null)
        {
            if (Mode == Mode.NoReply) { return; }

            using (var ms = new MemoryStream())
            {
                using (var w = new Writer(ms, Endianness.BigEndian))
                {
                    w.UInt(0); // Matrix messages always have a 0 socketID
                    MatrixMsg.Write(w);
                    var bytes = ms.ToArray();
                    Socket.Send(bytes, bytes.Length, SendTo ?? EndPoint);
                }
            }
        }

        // Sends a proto message right away
        public void SendImmediate(BaseProtoMsg ProtoMsg, IPEndPoint SendTo = null)
        {
            if (Mode == Mode.NoReply) { return; }

            using (var ms = new MemoryStream())
            {
                using (var w = new Writer(ms, Endianness.BigEndian))
                {
                    w.UInt(SocketID);
                    var msgBytes = ProtoMsg.ToBytes();

                    // Use the header writer later
                    w.Byte(0);
                    w.Byte((byte)(msgBytes.Length + 3));
                    w.Byte(ProtoMsg.MsgID.Value);

                    w.Byte(msgBytes);

                    var bytes = ms.ToArray();
                    Socket.Send(bytes, bytes.Length, SendTo ?? EndPoint);
                }
            }
        }

        public void SendRaw(byte[] Data, IPEndPoint SendTo = null)
        {
            if (Mode == Mode.NoReply) { return; }

            Socket.Send(Data, Data.Length, SendTo ?? EndPoint);
        }
        #endregion

        #region Utils
        private byte[] XorByteArray(byte[] InArray, byte XorWith)
        {
            for (int i = 0; i < InArray.Length; i++)
            {
                InArray[i] = (byte)(InArray[i] ^ XorWith);
            }

            return InArray;
        }

        private Reader DecodeResentData(Reader R, GssHeader Header)
        {
            if (Header.ResendCount == 0)
            {
                return R; // Nothing to do :D
            }
            else
            {
                var msgBytes = R.Byte((int)Header.Length);
                var xored = XorByteArray(msgBytes, ResendXors[Header.ResendCount]);
                var ms = new MemoryStream(xored);
                var reader = new Reader(ms);
                return reader;
            }
        }

        private void ChangeState(SocketState NewState)
        {
            logger.Debug($"State change from {Enum.GetName(typeof(SocketState), State)} to {Enum.GetName(typeof(SocketState), NewState)}");
            State = NewState;
        }

        public ushort NextSendSeqNum()
        {
            // TODO: Wrap around
            CurrentSendSeqNum++;
            return CurrentSendSeqNum;
        }

        public void SendAck(ushort? AckFor = null)
        {
            if (AckFor == null)
            {
                AckFor = CurrentRecvSeqNum;
            }

            Ack ack = new Ack()
            {
                AckFor = AckFor.Value,
                SeqNum = NextSendSeqNum()
            };

            SendImmediate(ack);
            logger.Trace($"Sent ACK {AckFor.Value}");
        }
        #endregion

        #region Event Delegates
        public delegate void MatrixMessageDelegate(BaseMatrixMessage Msg, IPEndPoint From, byte[] RawBytes);
        public delegate void GssRawMessageDelegate(GssHeader Header, GssUnknown GssMessage, FFSocket Socket);
        public delegate void GssProtoMessageDelegate(GssHeader Header, BaseProtoMsg GssMessage, FFSocket Socket);
        public delegate void GssFuryMessageDelegate(GssHeader Header, BaseFuryMsg GssMessage, FFSocket Socket);
        public delegate void SocketClosedDelegate(FFSocket Socket);
        #endregion
    }

    public enum SocketState
    {
        NOT_OPENED = 0,
        INITIALIZING = 1,
        TRANSFERING = 2,
        CONNECTING = 3,
        WAITING_CONTACT = 4,
        CONNECTED = 5,
        DISCONNECT_NOTIFY = 6,
        DISCONNECTED = 7,
        CLOSING = 8,
        CLOSED = 9
    }

    public enum Mode
    {
        Normal, // For use in the server
        NoReply // Won't auto reply to proto message, for use in a decoder or packet anayliser
    }
}
