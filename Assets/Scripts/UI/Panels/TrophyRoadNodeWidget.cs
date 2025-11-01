using TMPro;
using UnityEngine;
using BrawlShooter.Progression;

namespace BrawlShooter.UI.Panels
{
    /// <summary>
    /// UI tile representing a trophy road milestone.
    /// </summary>
    public sealed class TrophyRoadNodeWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text trophyRequirementLabel = default!;

        [SerializeField]
        private TMP_Text rewardLabel = default!;

        public void Bind(TrophyRoadNode node)
        {
            trophyRequirementLabel.text = $"{node.TrophyRequirement}🏆";
            rewardLabel.text = node.RewardDescription;
        }
    }
}
