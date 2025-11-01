using System;

namespace NovaArena.Core
{
    public enum MatchState
    {
        None,
        Lobby,
        Countdown,
        Playing,
        SuddenDeath,
        MatchEnded
    }

    public enum TeamAlignment
    {
        Neutral,
        Blue,
        Red
    }

    public sealed class MatchStateController
    {
        public event Action<MatchState> StateChanged = delegate { };
        public event Action<string, string, TeamAlignment> EliminationOccurred = delegate { };

        public MatchState CurrentState { get; private set; } = MatchState.None;
        public float Elapsed { get; private set; }
        public float MatchLengthSeconds { get; private set; } = 180f;

        public void ConfigureMatchLength(float seconds)
        {
            MatchLengthSeconds = seconds;
        }

        public void Tick(float deltaTime)
        {
            if (CurrentState is MatchState.Playing or MatchState.SuddenDeath)
            {
                Elapsed = Math.Min(Elapsed + deltaTime, MatchLengthSeconds);
                if (Elapsed >= MatchLengthSeconds)
                {
                    SetState(MatchState.MatchEnded);
                }
            }
        }

        public void SetState(MatchState newState)
        {
            if (CurrentState == newState)
            {
                return;
            }

            CurrentState = newState;
            if (newState == MatchState.Playing)
            {
                Elapsed = 0f;
            }

            StateChanged.Invoke(newState);
        }

        public void ReportElimination(string killer, string victim, TeamAlignment scoringTeam)
        {
            EliminationOccurred.Invoke(killer, victim, scoringTeam);
        }
    }
}
