using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using BrawlShooter.Networking;
using BrawlShooter.Player;

namespace BrawlShooter.UI
{
    /// <summary>
    /// Controls the lobby experience by wiring hero selection, matchmaking, and social entry points
    /// into a single touch-friendly main menu similar to Brawl Stars.
    /// </summary>
    public sealed class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private HeroRoster heroRoster = default!;

        [SerializeField]
        private Transform heroCardContainer = default!;

        [SerializeField]
        private HeroCardView heroCardPrefab = default!;

        [SerializeField]
        private Button playButton = default!;

        [SerializeField]
        private Button clubButton = default!;

        [SerializeField]
        private Button shopButton = default!;

        [SerializeField]
        private MatchmakingPanel matchmakingPanel = default!;

        [SerializeField]
        private UnityEvent onClubTapped = default!;

        [SerializeField]
        private UnityEvent onShopTapped = default!;

        private readonly List<HeroCardView> activeCards = new();
        private HeroDefinition? selectedHero;
        private MatchmakingService matchmakingService = default!;

        private void Awake()
        {
            matchmakingService = MatchmakingLocator.Resolve();
            BuildHeroCards();
            playButton.onClick.AddListener(HandlePlayClicked);
            clubButton.onClick.AddListener(() => onClubTapped?.Invoke());
            shopButton.onClick.AddListener(() => onShopTapped?.Invoke());
        }

        private void BuildHeroCards()
        {
            foreach (Transform child in heroCardContainer)
            {
                Destroy(child.gameObject);
            }

            activeCards.Clear();

            foreach (var hero in heroRoster.AllHeroes)
            {
                var card = Instantiate(heroCardPrefab, heroCardContainer);
                card.Populate(hero, HandleHeroSelected);
                activeCards.Add(card);
            }

            if (heroRoster.AllHeroes.Count > 0)
            {
                SelectHero(heroRoster.AllHeroes[0]);
            }
        }

        private void HandlePlayClicked()
        {
            if (selectedHero == null)
            {
                Debug.LogWarning("Play clicked without a hero selection.");
                return;
            }

            matchmakingPanel.gameObject.SetActive(true);
            matchmakingPanel.BeginQueue(selectedHero, matchmakingService);
        }

        private void HandleHeroSelected(HeroDefinition hero)
        {
            SelectHero(hero);
        }

        private void SelectHero(HeroDefinition hero)
        {
            selectedHero = hero;

            foreach (var card in activeCards)
            {
                card.SetSelected(card.RepresentedHero == hero);
            }
        }
    }
}
