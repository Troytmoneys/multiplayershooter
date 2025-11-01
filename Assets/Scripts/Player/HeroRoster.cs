using System.Collections.Generic;
using UnityEngine;

namespace BrawlShooter.Player
{
    /// <summary>
    /// Provides curated hero rotations, featured picks, and metadata used by the lobby UI.
    /// </summary>
    [CreateAssetMenu(menuName = "BrawlShooter/HeroRoster", fileName = "HeroRoster")]
    public sealed class HeroRoster : ScriptableObject
    {
        [SerializeField]
        private List<HeroDefinition> allHeroes = new();

        [SerializeField]
        private List<HeroDefinition> dailyRotation = new();

        public IReadOnlyList<HeroDefinition> AllHeroes => allHeroes;
        public IReadOnlyList<HeroDefinition> DailyRotation => dailyRotation;

        public HeroDefinition? FindByName(string heroName)
        {
            return allHeroes.Find(hero => hero.DisplayName == heroName);
        }
    }
}
