using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BrawlShooter.Progression.Quests;

namespace BrawlShooter.UI.Panels
{
    /// <summary>
    /// Renders quest progress including textual progress and reward tokens.
    /// </summary>
    public sealed class QuestRowWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text nameLabel = default!;

        [SerializeField]
        private TMP_Text descriptionLabel = default!;

        [SerializeField]
        private TMP_Text progressLabel = default!;

        [SerializeField]
        private TMP_Text rewardLabel = default!;

        [SerializeField]
        private Image questIcon = default!;

        [SerializeField]
        private Image progressFill = default!;

        public void Bind(QuestProgress progress)
        {
            var quest = progress.Quest;
            nameLabel.text = quest.DisplayName;
            descriptionLabel.text = quest.Description;
            progressLabel.text = $"{progress.CurrentValue}/{quest.ObjectiveCount}";
            rewardLabel.text = $"{quest.RewardTokens} Tokens";
            questIcon.sprite = quest.Icon;
            progressFill.fillAmount = progress.CompletionPercent;
        }
    }
}
