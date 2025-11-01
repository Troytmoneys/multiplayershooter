using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrawlShooter.Core;
using UnityEngine;

namespace BrawlShooter.Networking
{
    public interface IMatchmakingService
    {
        Task QueueAsync(string queueId, IDictionary<string, object>? properties = null);
        Task CancelAsync();
    }

    public sealed class MatchmakingService : IMatchmakingService
    {
        private readonly ITelemetryService _telemetry;
        private readonly System.Random _rng = new();

        public MatchmakingService()
        {
            _telemetry = GameServiceLocator.Resolve<ITelemetryService>();
        }

        public async Task QueueAsync(string queueId, IDictionary<string, object>? properties = null)
        {
            _telemetry.RecordEvent("MatchmakingQueue", new Dictionary<string, object>
            {
                ["QueueId"] = queueId,
                ["Properties"] = properties ?? new Dictionary<string, object>()
            });

            var simulatedWait = _rng.Next(1, 5);
            await Task.Delay(TimeSpan.FromSeconds(simulatedWait));
            _telemetry.RecordEvent("MatchFound", new Dictionary<string, object>
            {
                ["QueueId"] = queueId,
                ["WaitSeconds"] = simulatedWait
            });
        }

        public Task CancelAsync()
        {
            _telemetry.RecordEvent("MatchmakingCancel");
            return Task.CompletedTask;
        }
    }
}
