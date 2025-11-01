using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using NovaArena.Events;
using NovaArena.Networking;
using NovaArena.Player;
using NovaArena.Progression.Quests;
using NovaArena.UI.Panels;

namespace NovaArena.UI
{
    /// <summary>
    /// Controls the lobby experience by wiring hero selection, matchmaking, social entry points, and
    /// home tab widgets into a single touch-friendly Nova Arena home hub.
    /// </summary>
    public sealed class MainMenuController : MonoBehaviour
    {
        [Header("Hero Selection")]
        [SerializeField]
        private HeroRoster heroRoster = default!;

        [SerializeField]
        private Transform heroCardContainer = default!;

        [SerializeField]
        private HeroCardView heroCardPrefab = default!;

        [SerializeField]
        private Button playButton = default!;

        [Header("Navigation")]
        [SerializeField]
        private LobbyNavigationController navigationController = default!;

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

        [Header("Home Widgets")]
        [SerializeField]
        private TMP_Text coinLabel = default!;

        [SerializeField]
        private TMP_Text gemLabel = default!;

        [SerializeField]
        private TMP_Text tokenLabel = default!;

        [SerializeField]
        private EventRotationController rotationController = default!;

        [SerializeField]
        private EventPreviewWidget eventPreview = default!;

        [SerializeField]
        private QuestManager questManager = default!;

        [SerializeField]
        private QuestTickerWidget questTicker = default!;

        private readonly List<HeroCardView> activeCards = new();
        private HeroDefinition? selectedHero;
        private MatchmakingService matchmakingService = default!;

        private void Awake()
        {
            matchmakingService = MatchmakingLocator.Resolve();
            BuildHeroCards();
            playButton.onClick.AddListener(HandlePlayClicked);
            clubButton.onClick.AddListener(HandleClubTapped);
            shopButton.onClick.AddListener(HandleShopTapped);
            navigationController.gameObject.SetActive(true);
            onClubTapped.AddListener(() => navigationController.ShowTab("Clubs"));
            onShopTapped.AddListener(() => navigationController.ShowTab("Shop"));
        }

        private void Start()
        {
            coinLabel.text = "2 345";
            gemLabel.text = "210";
            tokenLabel.text = "560";
            if (rotationController != null && eventPreview != null)
            {
                eventPreview.Initialize(rotationController);
            }

            if (questManager != null && questTicker != null)
            {
                questTicker.Initialize(questManager);
            }
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

        private void HandleClubTapped()
        {
            onClubTapped?.Invoke();
        }

        private void HandleShopTapped()
        {
            onShopTapped?.Invoke();
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
