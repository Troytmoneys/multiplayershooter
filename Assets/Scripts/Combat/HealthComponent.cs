using BrawlShooter.Core;
using BrawlShooter.Player;
using UnityEngine;

namespace BrawlShooter.Combat
{
    public sealed class HealthComponent : MonoBehaviour
    {
        [SerializeField] private HeroDefinition heroDefinition = default!;

        public int CurrentHealth { get; private set; }

        private void Awake()
        {
            CurrentHealth = heroDefinition != null ? heroDefinition.Health : 2000;
        }

        public void ApplyDamage(int amount)
        {
            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
            GameServiceLocator.Resolve<ITelemetryService>().RecordEvent("DamageTaken", new System.Collections.Generic.Dictionary<string, object>
            {
                ["Target"] = name,
                ["Amount"] = amount,
                ["Remaining"] = CurrentHealth
            });

            if (CurrentHealth <= 0)
            {
                HandleElimination();
            }
        }

        private void HandleElimination()
        {
            gameObject.SetActive(false);
            GameServiceLocator.Resolve<ITelemetryService>().RecordEvent("Eliminated", new System.Collections.Generic.Dictionary<string, object>
            {
                ["Target"] = name
            });
        }
    }
}
