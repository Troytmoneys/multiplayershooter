using BrawlShooter.Combat;
using BrawlShooter.Core;
using UnityEngine;
using UnityEngine.UI;

namespace BrawlShooter.UI
{
    public sealed class HudController : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider = default!;
        [SerializeField] private Text timerLabel = default!;
        [SerializeField] private HealthComponent trackedHealth = default!;

        private MatchStateController _matchState = default!;

        private void Awake()
        {
            _matchState = GameServiceLocator.Resolve<MatchStateController>();
            _matchState.StateChanged += OnMatchStateChanged;
            UpdateHealthBar();
        }

        private void OnDestroy()
        {
            if (_matchState != null)
            {
                _matchState.StateChanged -= OnMatchStateChanged;
            }
        }

        private void Update()
        {
            UpdateTimerLabel();
            UpdateHealthBar();
        }

        private void UpdateTimerLabel()
        {
            var elapsed = _matchState.Elapsed;
            var minutes = Mathf.FloorToInt(elapsed / 60f);
            var seconds = Mathf.FloorToInt(elapsed % 60f);
            timerLabel.text = $"{minutes:00}:{seconds:00}";
        }

        private void UpdateHealthBar()
        {
            if (trackedHealth == null || healthSlider == null)
            {
                return;
            }

            healthSlider.value = trackedHealth.CurrentHealth;
        }

        private void OnMatchStateChanged(MatchState newState)
        {
            timerLabel.color = newState == MatchState.SuddenDeath ? Color.red : Color.white;
        }
    }
}
