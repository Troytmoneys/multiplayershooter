using System;

namespace BrawlShooter.Core
{
    public enum MatchState
    {
        None,
        Lobby,
        Countdown,
        Playing,
        SuddenDeath,
        PostMatch
    }

    public sealed class MatchStateController
    {
        public event Action<MatchState> StateChanged = delegate { };

        public MatchState CurrentState { get; private set; } = MatchState.None;
        public float Elapsed { get; private set; }

        public void Tick(float deltaTime)
        {
            if (CurrentState is MatchState.Playing or MatchState.SuddenDeath)
            {
                Elapsed += deltaTime;
            }
        }

        public void SetState(MatchState newState)
        {
            if (CurrentState == newState)
            {
                return;
            }

            CurrentState = newState;
            Elapsed = 0f;
            StateChanged.Invoke(newState);
        }
    }
}
