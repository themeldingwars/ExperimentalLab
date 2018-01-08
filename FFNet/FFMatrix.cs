using FFNet.Packets.Gss;
using FFNet.Packets.Matrix;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FFNet
{
    // Handles incoming connections from game clinets
    public class FFMatrix
    {
        private FFSocket GreetingSock = null;
        private const ushort Port = 25000;
        private static Tuple<ushort, ushort> GssPortRange = new Tuple<ushort, ushort>(50000, 60000);

        // Events
        public event MatrixConnectedDelegate        OnMatrixConnection;
        public event MatrixDisconnectedDelegate     OnMatrixDisconnection;

        // State Vars
        private uint CurrentSocketID = 1;
        private ushort CurrentSeqStart = 3000; // TODO: make per connection?
        private ushort CurrentGssPort = GssPortRange.Item1;
        private List<MatrixConnection> Connections = new List<MatrixConnection>();

        public FFMatrix()
        {
            GreetingSock = new FFSocket();
            GreetingSock.OnMatrixMsgRecv += OnMatrixMsg;
        }

        public void Start()
        {
            GreetingSock.Listen(Port);
            Debug.WriteLine($"Matrix listening on port: {Port}");
        }

        private void OnMatrixMsg(BaseMatrixMessage MatrixMsg, IPEndPoint From, byte[] RawBytes = null)
        {
            string typeStr = new string(MatrixMsg.Type);

            if (typeStr == "POKE")
            {
                // TODO: CHeck Proto version
                var id = GetNextSocketID();
                var hehe = new HeheMsg(id);
                GreetingSock.SendImmediate(hehe, From);
            }
            else if (typeStr == "KISS")
            {
                var port = GetNextGssPort();
                var seqStart = CurrentSeqStart;
                var hugg = new HuggMsg(CurrentSeqStart, port);
                GreetingSock.SendImmediate(hugg, From);

                // Hand is shaken!
                RegisterConnectedSocket(port, ((KissMsg)MatrixMsg).SocketID, seqStart, From);
            }

            Debug.WriteLine($"Got a matrix message, awww yisss!! {new string(MatrixMsg.Type)}");
        }

        private void RegisterConnectedSocket(ushort Port, uint SocketID, ushort SeqStart, IPEndPoint From)
        {
            var gsSocket = new FFSocket();
            gsSocket.Bind(Port, SocketID, SeqStart, From);

            var connectionInfo = new MatrixConnection()
            {
                ParentMatrix = this,
                Socket = gsSocket
            };

            gsSocket.OnSocketClosed += connectionInfo.Remove;

            Connections.Add(connectionInfo);

            OnMatrixConnection?.Invoke(connectionInfo);
        }

        public void RemoveConnection(MatrixConnection MConn)
        {
            Connections.Remove(MConn);
            OnMatrixDisconnection?.Invoke(MConn);
        }

        private uint GetNextSocketID()
        {
            // TODO: check if not in use
            if (CurrentSocketID == uint.MaxValue)
            {
                CurrentSocketID = 1;
            }

            return ++CurrentSocketID;
        }

        private ushort GetNextGssPort()
        {
            // TODO: check if not in use
            if (CurrentGssPort == GssPortRange.Item2)
            {
                CurrentGssPort = GssPortRange.Item1;
            }

            return ++CurrentGssPort;
        }

        #region Event Delegates
        public delegate void MatrixConnectedDelegate(MatrixConnection Connection);
        public delegate void MatrixDisconnectedDelegate(MatrixConnection Connection);
        #endregion
    }

    public class MatrixConnection
    {
        public FFMatrix ParentMatrix;

        public FFSocket Socket;

        public void Remove(FFSocket Sock)
        {
            ParentMatrix.RemoveConnection(this);
        }
    }
}
