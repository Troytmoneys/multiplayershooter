using System;
using UnityEngine;

namespace NovaArena.Events
{
    /// <summary>
    /// ScriptableObject describing a timed multiplayer event similar to Nova Arena Clash' event rotation.
    /// </summary>
    [CreateAssetMenu(fileName = "EventDefinition", menuName = "NovaArena/Event Definition", order = 0)]
    public sealed class EventDefinition : ScriptableObject
    {
        [SerializeField]
        private string eventId = Guid.NewGuid().ToString();

        [SerializeField]
        private string displayName = "Gem Grab";

        [SerializeField]
        private string description = "Control the map and hold 10 gems to win.";

        [SerializeField]
        private Sprite eventKeyArt = default!;

        [SerializeField]
        private Sprite modeIcon = default!;

        [SerializeField]
        private EventType type = EventType.Core;

        [SerializeField]
        private string recommendedPowerLevel = "5";

        [SerializeField]
        private bool isRanked = false;

        [SerializeField]
        private bool supportsDuos = false;

        public string EventId => eventId;
        public string DisplayName => displayName;
        public string Description => description;
        public Sprite EventKeyArt => eventKeyArt;
        public Sprite ModeIcon => modeIcon;
        public EventType Type => type;
        public string RecommendedPowerLevel => recommendedPowerLevel;
        public bool IsRanked => isRanked;
        public bool SupportsDuos => supportsDuos;
    }

    public enum EventType
    {
        Core,
        Seasonal,
        PowerLeague,
        Challenge,
        Special
    }
}
