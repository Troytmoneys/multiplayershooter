using TMPro;
using UnityEngine;
using BrawlShooter.Events;

namespace BrawlShooter.UI.Panels
{
    /// <summary>
    /// Small hero section on the home tab showing the highlighted event.
    /// </summary>
    public sealed class EventPreviewWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text nameLabel = default!;

        [SerializeField]
        private TMP_Text descriptionLabel = default!;

        [SerializeField]
        private TMP_Text remainingLabel = default!;

        private EventRotationController rotationController = default!;

        public void Initialize(EventRotationController controller)
        {
            rotationController = controller;
            Refresh();
        }

        private void Update()
        {
            Refresh();
        }

        private void Refresh()
        {
            if (rotationController == null || nameLabel == null || descriptionLabel == null)
            {
                return;
            }

            var active = rotationController.ActiveEvents.Count > 0
                ? rotationController.ActiveEvents[0]
                : null;

            if (active == null)
            {
                nameLabel.text = "NO EVENT";
                descriptionLabel.text = "Check back soon";
                if (remainingLabel != null)
                {
                    remainingLabel.text = string.Empty;
                }

                return;
            }

            nameLabel.text = active.DisplayName;
            descriptionLabel.text = active.Description;

            if (remainingLabel != null)
            {
                var remaining = rotationController.Remaining;
                remainingLabel.text = remaining <= System.TimeSpan.Zero
                    ? "NEW EVENT!"
                    : $"Ends in {remaining:hh\\:mm}";
            }
        }
    }
}
