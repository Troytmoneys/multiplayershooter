using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BrawlShooter.Progression.Quests;

namespace BrawlShooter.UI.Panels
{
    /// <summary>
    /// Displays active quests and progress meters similar to the Brawl Pass quest screen.
    /// </summary>
    public sealed class QuestPanelController : MonoBehaviour
    {
        [SerializeField]
        private QuestManager questManager = default!;

        [SerializeField]
        private Transform questListContainer = default!;

        [SerializeField]
        private QuestRowWidget questRowPrefab = default!;

        [SerializeField]
        private TMP_Text seasonLabel = default!;

        private readonly List<QuestRowWidget> activeRows = new();

        private void OnEnable()
        {
            if (questManager != null)
            {
                questManager.QuestsUpdated += BuildList;
            }

            BuildList();
        }

        private void OnDisable()
        {
            if (questManager != null)
            {
                questManager.QuestsUpdated -= BuildList;
            }
        }

        private void BuildList()
        {
            foreach (Transform child in questListContainer)
            {
                Destroy(child.gameObject);
            }

            activeRows.Clear();

            if (questManager == null)
            {
                return;
            }

            foreach (var quest in questManager.ActiveQuests)
            {
                var row = Instantiate(questRowPrefab, questListContainer);
                row.Bind(quest);
                activeRows.Add(row);
            }

            if (seasonLabel != null)
            {
                seasonLabel.text = "STARR DROP SEASON";
            }
        }
    }
}
