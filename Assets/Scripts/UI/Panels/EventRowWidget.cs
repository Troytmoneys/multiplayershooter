using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BrawlShooter.Events;

namespace BrawlShooter.UI.Panels
{
    /// <summary>
    /// Renders one event tile with art, description, and badges.
    /// </summary>
    public sealed class EventRowWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text nameLabel = default!;

        [SerializeField]
        private TMP_Text descriptionLabel = default!;

        [SerializeField]
        private TMP_Text tagLabel = default!;

        [SerializeField]
        private Image keyArtImage = default!;

        [SerializeField]
        private Image modeIconImage = default!;

        public void Bind(EventDefinition definition)
        {
            nameLabel.text = definition.DisplayName;
            descriptionLabel.text = definition.Description;
            tagLabel.text = definition.Type.ToString().ToUpperInvariant();
            keyArtImage.sprite = definition.EventKeyArt;
            modeIconImage.sprite = definition.ModeIcon;
        }
    }
}
