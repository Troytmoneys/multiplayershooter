using TMPro;
using UnityEngine;
using NovaArena.Progression.Quests;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// Compact widget summarizing current quest progress on the home tab.
    /// </summary>
    public sealed class QuestTickerWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text questLabel = default!;

        [SerializeField]
        private TMP_Text progressLabel = default!;

        private QuestManager questManager = default!;

        private void OnEnable()
        {
            if (questManager != null)
            {
                questManager.QuestsUpdated += Refresh;
            }
        }

        private void OnDisable()
        {
            if (questManager != null)
            {
                questManager.QuestsUpdated -= Refresh;
            }
        }

        public void Initialize(QuestManager manager)
        {
            if (questManager != null)
            {
                questManager.QuestsUpdated -= Refresh;
            }

            questManager = manager;

            if (questManager != null)
            {
                questManager.QuestsUpdated += Refresh;
            }

            Refresh();
        }

        private void Refresh()
        {
            if (questLabel == null || progressLabel == null)
            {
                return;
            }

            if (questManager == null || questManager.ActiveQuests.Count == 0)
            {
                questLabel.text = "No quests";
                progressLabel.text = string.Empty;
                return;
            }

            var quest = questManager.ActiveQuests[0];
            questLabel.text = quest.Quest.DisplayName;
            progressLabel.text = $"{quest.CurrentValue}/{quest.Quest.ObjectiveCount}";
        }
    }
}
