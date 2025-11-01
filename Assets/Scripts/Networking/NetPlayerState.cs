using System;
using UnityEngine;

namespace NovaArena.Networking
{
    /// <summary>
    /// Lightweight representation of a player in the realtime session.
    /// Stores replicated properties and exposes events for UI.
    /// </summary>
    [Serializable]
    public sealed class NetPlayerState
    {
        [SerializeField]
        private string displayName = "Player";

        [SerializeField]
        private Color themeColor = Color.cyan;

        [SerializeField]
        private int trophies;

        public string DisplayName => displayName;
        public Color ThemeColor => themeColor;
        public int Trophies => trophies;
    }
}
