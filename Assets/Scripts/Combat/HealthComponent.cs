using System.Collections.Generic;
using BrawlShooter.Core;
using BrawlShooter.Player;
using UnityEngine;

namespace BrawlShooter.Combat
{
    public sealed class HealthComponent : MonoBehaviour
    {
        [SerializeField] private HeroDefinition heroDefinition = default!;
        [SerializeField] private TeamAlignment teamAlignment = TeamAlignment.Neutral;

        public int CurrentHealth { get; private set; }
        public int MaxHealth => heroDefinition != null ? heroDefinition.Health : 2000;

        private ITelemetryService telemetry = default!;
        private MatchStateController matchState = default!;

        private void Awake()
        {
            telemetry = GameServiceLocator.Resolve<ITelemetryService>();
            matchState = GameServiceLocator.Resolve<MatchStateController>();
            CurrentHealth = MaxHealth;
        }

        public void ApplyDamage(int amount, string instigator = "Unknown")
        {
            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
            telemetry.RecordEvent("DamageTaken", new Dictionary<string, object>
            {
                ["Target"] = name,
                ["Amount"] = amount,
                ["Remaining"] = CurrentHealth
            });

            if (CurrentHealth <= 0)
            {
                HandleElimination(instigator);
            }
        }

        private void HandleElimination(string instigator)
        {
            gameObject.SetActive(false);
            telemetry.RecordEvent("Eliminated", new Dictionary<string, object>
            {
                ["Target"] = name,
                ["Instigator"] = instigator
            });
            matchState.ReportElimination(instigator, name, teamAlignment);
        }

        public void Revive()
        {
            CurrentHealth = MaxHealth;
            gameObject.SetActive(true);
        }
    }
}
