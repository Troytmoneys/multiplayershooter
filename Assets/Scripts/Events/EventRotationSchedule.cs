using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrawlShooter.Events
{
    /// <summary>
    /// Holds a rotation of events and exposes helper queries for UI widgets.
    /// </summary>
    [CreateAssetMenu(fileName = "EventRotation", menuName = "BrawlShooter/Event Rotation", order = 1)]
    public sealed class EventRotationSchedule : ScriptableObject
    {
        [SerializeField]
        private List<EventDefinition> activeEvents = new();

        [SerializeField]
        private List<EventDefinition> upcomingEvents = new();

        [SerializeField]
        private DateTime rotationEndsAt = DateTime.UtcNow.AddHours(12);

        public IReadOnlyList<EventDefinition> ActiveEvents => activeEvents;
        public IReadOnlyList<EventDefinition> UpcomingEvents => upcomingEvents;
        public DateTime RotationEndsAt => rotationEndsAt;

        public void SetRotation(DateTime endsAt, IEnumerable<EventDefinition> current, IEnumerable<EventDefinition> next)
        {
            rotationEndsAt = endsAt;
            activeEvents.Clear();
            upcomingEvents.Clear();
            activeEvents.AddRange(current);
            upcomingEvents.AddRange(next);
        }
    }
}
