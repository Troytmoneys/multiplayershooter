using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BrawlShooter.Core
{
    public interface ITelemetryService
    {
        void RecordEvent(string eventName, IDictionary<string, object>? payload = null);
    }

    public sealed class TelemetryService : ITelemetryService
    {
        public void RecordEvent(string eventName, IDictionary<string, object>? payload = null)
        {
            if (payload == null || payload.Count == 0)
            {
                Debug.Log($"[Telemetry] {eventName}");
                return;
            }

            var builder = new StringBuilder();
            builder.Append('{');
            var index = 0;
            foreach (var kvp in payload)
            {
                if (index++ > 0)
                {
                    builder.Append(", ");
                }

                builder.Append(kvp.Key);
                builder.Append(": ");
                builder.Append(kvp.Value);
            }

            builder.Append('}');
            Debug.Log($"[Telemetry] {eventName} {builder}");
        }
    }
}
