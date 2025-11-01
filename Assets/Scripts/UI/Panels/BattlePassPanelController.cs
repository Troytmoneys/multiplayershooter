using System.Collections.Generic;
using TMPro;
using UnityEngine;
using NovaArena.Progression;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// Displays the Star Pass track with free and premium rewards bespoke to Nova Arena's seasonal cadence.
    /// </summary>
    public sealed class BattlePassPanelController : MonoBehaviour
    {
        [SerializeField]
        private BattlePassManager battlePassManager = default!;

        [SerializeField]
        private Transform tierContainer = default!;

        [SerializeField]
        private BattlePassTierWidget tierWidgetPrefab = default!;

        [SerializeField]
        private TMP_Text levelLabel = default!;

        [SerializeField]
        private TMP_Text xpLabel = default!;

        private readonly List<BattlePassTierWidget> tierWidgets = new();

        private int simulatedXp = 2400;

        private void OnEnable()
        {
            levelLabel.text = "LEVEL 12";
            xpLabel.text = $"{simulatedXp} XP";
            BuildTrack();
        }

        private void OnDisable()
        {
            foreach (var widget in tierWidgets)
            {
                if (widget != null)
                {
                    Destroy(widget.gameObject);
                }
            }

            tierWidgets.Clear();
        }

        private void BuildTrack()
        {
            foreach (Transform child in tierContainer)
            {
                Destroy(child.gameObject);
            }

            tierWidgets.Clear();

            foreach (var tier in battlePassManager.Tiers)
            {
                var widget = Instantiate(tierWidgetPrefab, tierContainer);
                widget.Bind(tier, simulatedXp);
                tierWidgets.Add(widget);
            }
        }
    }
}
