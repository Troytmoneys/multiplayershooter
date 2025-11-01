using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NovaArena.Progression;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// Displays a single tier in the battle pass track with free and premium rewards.
    /// </summary>
    public sealed class BattlePassTierWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text tierLabel = default!;

        [SerializeField]
        private TMP_Text freeRewardLabel = default!;

        [SerializeField]
        private TMP_Text premiumRewardLabel = default!;

        [SerializeField]
        private Image completionBar = default!;

        public void Bind(BattlePassTier tier, int totalXp)
        {
            tierLabel.text = $"Tier {tier.RequiredXp}";
            freeRewardLabel.text = tier.FreeRewardId;
            premiumRewardLabel.text = tier.PremiumRewardId;
            completionBar.fillAmount = totalXp >= tier.RequiredXp ? 1f : 0.25f;
        }
    }
}
