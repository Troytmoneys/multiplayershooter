using System;
using System.Collections.Generic;
using UnityEngine;

namespace NovaArena.Progression.Quests
{
    /// <summary>
    /// Tracks a player's active quests and broadcasts changes for UI components.
    /// </summary>
    public sealed class QuestManager : MonoBehaviour
    {
        [SerializeField]
        private List<QuestProgress> activeQuests = new();

        public event Action? QuestsUpdated;

        public IReadOnlyList<QuestProgress> ActiveQuests => activeQuests;

        public void InjectQuests(IEnumerable<(QuestDefinition definition, int value)> quests)
        {
            activeQuests.Clear();
            foreach (var (definition, value) in quests)
            {
                var progress = new QuestProgress();
                progress.Bind(definition, value);
                activeQuests.Add(progress);
            }

            QuestsUpdated?.Invoke();
        }
    }
}
