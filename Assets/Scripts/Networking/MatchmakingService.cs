using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NovaArena.Core;
using NovaArena.Player;
using UnityEngine;

namespace NovaArena.Networking
{
    public interface IMatchmakingService
    {
        Task QueueAsync(string queueId, IDictionary<string, object>? properties = null);
        Task CancelAsync();
    }

    public readonly struct MatchmakingState
    {
        public MatchmakingState(string statusMessage, float timeRemaining, bool isMatchReady)
        {
            StatusMessage = statusMessage;
            TimeRemaining = timeRemaining;
            IsMatchReady = isMatchReady;
        }

        public string StatusMessage { get; }
        public float TimeRemaining { get; }
        public bool IsMatchReady { get; }
    }

    public static class MatchmakingLocator
    {
        private static MatchmakingService? instance;

        public static MatchmakingService Resolve()
        {
            return instance ??= new MatchmakingService();
        }
    }

    public sealed class MatchmakingService : IMatchmakingService
    {
        private readonly ITelemetryService telemetry;
        private readonly System.Random rng = new();

        private float queueTimer;
        private float estimatedWait;
        private bool awaitingConfirmation;

        public MatchmakingService()
        {
            telemetry = GameServiceLocator.Resolve<ITelemetryService>();
        }

        public async Task QueueAsync(string queueId, IDictionary<string, object>? properties = null)
        {
            telemetry.RecordEvent("MatchmakingQueue", new Dictionary<string, object>
            {
                ["QueueId"] = queueId,
                ["Properties"] = properties ?? new Dictionary<string, object>()
            });

            var simulatedWait = rng.Next(1, 5);
            await Task.Delay(TimeSpan.FromSeconds(simulatedWait));
            telemetry.RecordEvent("MatchFound", new Dictionary<string, object>
            {
                ["QueueId"] = queueId,
                ["WaitSeconds"] = simulatedWait
            });
        }

        public Task CancelAsync()
        {
            telemetry.RecordEvent("MatchmakingCancel");
            queueTimer = 0f;
            awaitingConfirmation = false;
            return Task.CompletedTask;
        }

        public float GetEstimatedTime(HeroClass heroClass)
        {
            return heroClass switch
            {
                HeroClass.Tank => 7.5f,
                HeroClass.Support => 5.5f,
                HeroClass.Controller => 6.0f,
                _ => 4.5f
            };
        }

        public MatchmakingState TickQueue()
        {
            if (!awaitingConfirmation)
            {
                estimatedWait = rng.Next(4, 9);
                awaitingConfirmation = true;
                queueTimer = 0f;
            }

            queueTimer += Time.deltaTime;
            var timeRemaining = Mathf.Max(0f, estimatedWait - queueTimer);

            var ready = queueTimer >= estimatedWait;
            var status = ready ? "Match found!" : "Searching...";
            return new MatchmakingState(status, timeRemaining, ready);
        }

        public void ConfirmMatch()
        {
            if (!awaitingConfirmation)
            {
                return;
            }

            telemetry.RecordEvent("MatchConfirmed");
            awaitingConfirmation = false;
            queueTimer = 0f;
        }
    }
}
