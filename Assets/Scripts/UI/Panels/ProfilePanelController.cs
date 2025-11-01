using TMPro;
using UnityEngine;
using BrawlShooter.Player;

namespace BrawlShooter.UI.Panels
{
    /// <summary>
    /// Shows player name, trophies, and customizable banners for the profile screen.
    /// </summary>
    public sealed class ProfilePanelController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text playerNameLabel = default!;

        [SerializeField]
        private TMP_Text trophyLabel = default!;

        [SerializeField]
        private TMP_Text clubLabel = default!;

        [SerializeField]
        private TMP_Text rankLabel = default!;

        [SerializeField]
        private HeroRoster heroRoster = default!;

        [SerializeField]
        private TMP_Text favoriteHeroLabel = default!;

        private void OnEnable()
        {
            playerNameLabel.text = "Player";
            trophyLabel.text = "3500";
            clubLabel.text = "No Club";
            rankLabel.text = "GOLD II";
            favoriteHeroLabel.text = heroRoster.AllHeroes.Count > 0
                ? heroRoster.AllHeroes[0].DisplayName
                : "Random";
        }
    }
}
