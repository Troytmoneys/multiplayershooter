using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrawlShooter.Events
{
    /// <summary>
    /// Runtime helper for tracking the current rotation window and providing countdown values.
    /// </summary>
    public sealed class EventRotationController : MonoBehaviour
    {
        [SerializeField]
        private EventRotationSchedule schedule = default!;

        public event Action? RotationChanged;

        public IReadOnlyList<EventDefinition> ActiveEvents => schedule.ActiveEvents;
        public IReadOnlyList<EventDefinition> UpcomingEvents => schedule.UpcomingEvents;

        public TimeSpan Remaining => schedule.RotationEndsAt - DateTime.UtcNow;

        private void Update()
        {
            if (Remaining <= TimeSpan.Zero)
            {
                RotationChanged?.Invoke();
            }
        }
    }
}
