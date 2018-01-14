using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFNet.Packets.Gss.Fury_Messages
{
    public class MessageNamesLookup
    {
        public static string[] matrix_fury = new string[]
        {
            "Login",
            "EnterZoneAck",
            "ExitZoneAck ",
            "KeyframeRequest",
            "DEV_ExecuteCommand",
            "Referee_ExecuteCommand",
            "RequestPause",
            "RequestResume",
            "ClientStatus",
            "ClientPreferences",
            "SynchronizationResponse",
            "SuperPing",
            "StressTestMasterObject",
            "ServerProfiler_RequestNames",
            "LogInstrumentation",
            "RequestSigscan",
            "SendEmergencyChat",
            "SigscanData",
            "WelcomeToTheMatrix",
            "Announce",
            "EnterZone",
            "UpdateZoneTimeSync",
            "HotfixLevelChanged",
            "ExitZone",
            "MatrixStatus",
            "MatchQueueResponse",
            "MatchQueueUpdate",
            "FoundMatchUpdate",
            "ChallengeJoinResponse",
            "ChallengeInvitation",
            "ChallengeInvitationSquadInfoAck",
            "ChallengeInvitationCancel",
            "ChallengeInvitationResponse",
            "ChallengeKicked",
            "ChallengeLeave",
            "ChallengeRosterUpdate",
            "ChallengeReadyCheck",
            "ChallengeMatchParametersUpdate",
            "ChallengeMatchStarting",
            "ForceUnqueue",
            "SynchronizationRequest",
            "GamePaused",
            "SuperPong",
            "ServerProfiler_SendNames",
            "ServerProfiler_SendFrame",
            "ZoneQueueUpdate",
            "DebugLagSampleSim",
            "DebugLagSampleClient",
            "LFGMatchFound",
            "LFGLeaderChange",
            "ReceiveEmergencyChat",
            "UpdateDevZoneInfo"
        };

        public static string GetMatrixFuryName(int Id)
        {
            const int offset = 17;
            if (Id >= offset && Id < matrix_fury.Length + offset)
            {
                return matrix_fury[Id - offset];
            }
            else
            {
                return string.Format("Out of range Id {0}", Id);
            }
        }
    }
}
