using System;
using UnityEngine;

namespace NovaArena.Progression.Quests
{
    /// <summary>
    /// Simple quest definition that feeds Nova Arena's seasonal Star Pass progression.
    /// </summary>
    [CreateAssetMenu(fileName = "QuestDefinition", menuName = "NovaArena/Quest Definition", order = 0)]
    public sealed class QuestDefinition : ScriptableObject
    {
        [SerializeField]
        private string questId = Guid.NewGuid().ToString();

        [SerializeField]
        private string displayName = "Win Battles";

        [SerializeField]
        private string description = "Win 3 battles in any mode.";

        [SerializeField]
        private int objectiveCount = 3;

        [SerializeField]
        private int rewardTokens = 100;

        [SerializeField]
        private Sprite icon = default!;

        public string QuestId => questId;
        public string DisplayName => displayName;
        public string Description => description;
        public int ObjectiveCount => objectiveCount;
        public int RewardTokens => rewardTokens;
        public Sprite Icon => icon;
    }
}
