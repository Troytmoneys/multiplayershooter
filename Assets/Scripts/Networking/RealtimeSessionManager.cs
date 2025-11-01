using System.Collections.Generic;
using UnityEngine;

namespace NovaArena.Networking
{
    /// <summary>
    /// High level abstraction that would normally wrap a dedicated server or relay.
    /// Handles player joins, replication events, and simulated latency to mimic live play.
    /// </summary>
    public sealed class RealtimeSessionManager : MonoBehaviour
    {
        [SerializeField]
        private float simulatedLatencyMs = 80f;

        [SerializeField]
        private bool simulatePacketLoss;

        [SerializeField, Range(0f, 0.5f)]
        private float packetLossChance = 0.05f;

        private readonly List<NetPlayerState> connectedPlayers = new();

        public IReadOnlyList<NetPlayerState> ConnectedPlayers => connectedPlayers;

        public void Join(NetPlayerState playerState)
        {
            connectedPlayers.Add(playerState);
            Debug.Log($"Player {playerState.DisplayName} joined. Latency={simulatedLatencyMs}ms");
        }

        public void Leave(NetPlayerState playerState)
        {
            connectedPlayers.Remove(playerState);
            Debug.Log($"Player {playerState.DisplayName} left session");
        }

        public bool ShouldSendPacket()
        {
            if (!simulatePacketLoss)
            {
                return true;
            }

            return Random.value > packetLossChance;
        }

        public float GetLatencySeconds()
        {
            return simulatedLatencyMs / 1000f;
        }
    }
}
