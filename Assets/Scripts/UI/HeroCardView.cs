using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NovaArena.Player;

namespace NovaArena.UI
{
    /// <summary>
    /// Lightweight UI card representing a hero in the lobby carousel.
    /// Displays power level, role, and difficulty similar to modern hero shooters.
    /// </summary>
    public sealed class HeroCardView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text nameLabel = default!;

        [SerializeField]
        private TMP_Text classLabel = default!;

        [SerializeField]
        private TMP_Text difficultyLabel = default!;

        [SerializeField]
        private Image portraitImage = default!;

        [SerializeField]
        private Button selectButton = default!;

        [SerializeField]
        private GameObject selectedHighlight = default!;

        public HeroDefinition? RepresentedHero { get; private set; }

        private Action<HeroDefinition>? onSelected;

        private void Awake()
        {
            selectButton.onClick.AddListener(HandleClicked);
        }

        public void Populate(HeroDefinition hero, Action<HeroDefinition> selected)
        {
            RepresentedHero = hero;
            onSelected = selected;
            nameLabel.text = hero.DisplayName;
            classLabel.text = hero.Class.ToString();
            difficultyLabel.text = hero.Difficulty.ToString();
            portraitImage.sprite = hero.Portrait;
            SetSelected(false);
        }

        public void SetSelected(bool isSelected)
        {
            if (selectedHighlight != null)
            {
                selectedHighlight.SetActive(isSelected);
            }
        }

        private void HandleClicked()
        {
            if (RepresentedHero != null)
            {
                onSelected?.Invoke(RepresentedHero);
            }
        }
    }
}
