using System.Collections.Generic;
using UnityEngine;

namespace NovaArena.Progression
{
    /// <summary>
    /// ScriptableObject describing trophy road progression with milestone rewards.
    /// </summary>
    [CreateAssetMenu(fileName = "TrophyRoad", menuName = "NovaArena/Trophy Road", order = 2)]
    public sealed class TrophyRoadDefinition : ScriptableObject
    {
        [SerializeField]
        private List<TrophyRoadNode> milestones = new();

        public IReadOnlyList<TrophyRoadNode> Milestones => milestones;
    }

    [System.Serializable]
    public sealed class TrophyRoadNode
    {
        [SerializeField]
        private int trophyRequirement;

        [SerializeField]
        private string rewardDescription = string.Empty;

        public int TrophyRequirement => trophyRequirement;
        public string RewardDescription => rewardDescription;
    }
}
