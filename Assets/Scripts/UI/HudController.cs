using NovaArena.Combat;
using NovaArena.Core;
using UnityEngine;
using UnityEngine.UI;

namespace NovaArena.UI
{
    /// <summary>
    /// Coordinates all match overlay widgets, mirroring Nova Arena Clash HUD layout.
    /// </summary>
    public sealed class HudController : MonoBehaviour
    {
        [Header("Core Stats")]
        [SerializeField] private Slider healthSlider = default!;
        [SerializeField] private HealthComponent trackedHealth = default!;

        [Header("Widgets")]
        [SerializeField] private TeamScoreWidget scoreWidget = default!;
        [SerializeField] private ScoreFeedWidget scoreFeed = default!;

        private MatchStateController matchState = default!;

        private void Awake()
        {
            matchState = GameServiceLocator.Resolve<MatchStateController>();
            matchState.StateChanged += HandleMatchStateChanged;
            matchState.EliminationOccurred += HandleElimination;
            scoreWidget.Configure(0, 0, matchState.MatchLengthSeconds);
            UpdateHealthBar();
        }

        private void OnDestroy()
        {
            if (matchState != null)
            {
                matchState.StateChanged -= HandleMatchStateChanged;
                matchState.EliminationOccurred -= HandleElimination;
            }
        }

        private void Update()
        {
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            if (trackedHealth == null || healthSlider == null)
            {
                return;
            }

            healthSlider.maxValue = trackedHealth.MaxHealth;
            healthSlider.value = trackedHealth.CurrentHealth;
        }

        private void HandleMatchStateChanged(MatchState state)
        {
            if (state == MatchState.MatchEnded)
            {
                enabled = false;
            }
        }

        private void HandleElimination(string killer, string victim, TeamAlignment team)
        {
            scoreFeed?.PushEntry(killer, victim);
            if (team == TeamAlignment.Blue)
            {
                scoreWidget?.AddBluePoint();
            }
            else if (team == TeamAlignment.Red)
            {
                scoreWidget?.AddRedPoint();
            }
        }
    }
}
