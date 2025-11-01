using System.Collections.Generic;
using BrawlShooter.Core;
using UnityEngine;

namespace BrawlShooter.Progression
{
    [CreateAssetMenu(menuName = "BrawlShooter/Battle Pass", fileName = "BattlePass")]
    public sealed class BattlePassManager : ScriptableObject
    {
        [SerializeField] private List<BattlePassTier> tiers = new();
        [SerializeField] private AnimationCurve xpCurve = AnimationCurve.Linear(0, 0, 100, 100);

        public IReadOnlyList<BattlePassTier> Tiers => tiers;
        public AnimationCurve XpCurve => xpCurve;

        public BattlePassTier GetTierForXp(int totalXp)
        {
            for (var i = tiers.Count - 1; i >= 0; --i)
            {
                if (totalXp >= tiers[i].RequiredXp)
                {
                    return tiers[i];
                }
            }

            return tiers.Count > 0 ? tiers[0] : default;
        }
    }

    [System.Serializable]
    public sealed class BattlePassTier
    {
        [SerializeField] private int requiredXp = 0;
        [SerializeField] private string freeRewardId = string.Empty;
        [SerializeField] private string premiumRewardId = string.Empty;

        public int RequiredXp => requiredXp;
        public string FreeRewardId => freeRewardId;
        public string PremiumRewardId => premiumRewardId;
    }
}
