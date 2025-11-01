using System;
using UnityEngine;

namespace NovaArena.Progression.Quests
{
    /// <summary>
    /// Serializable quest progress payload for syncing to UI.
    /// </summary>
    [Serializable]
    public sealed class QuestProgress
    {
        [SerializeField]
        private QuestDefinition quest = default!;

        [SerializeField]
        [Range(0, 999)]
        private int currentValue;

        public QuestDefinition Quest => quest;
        public int CurrentValue => currentValue;

        public float CompletionPercent => quest == null || quest.ObjectiveCount == 0
            ? 0f
            : Mathf.Clamp01((float)currentValue / quest.ObjectiveCount);

        public void Bind(QuestDefinition definition, int value)
        {
            quest = definition;
            currentValue = value;
        }
    }
}
