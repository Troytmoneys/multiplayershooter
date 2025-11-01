using TMPro;
using UnityEngine;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// Basic placeholder for the Crews social hub aligned with Nova Arena's clubhouse presentation.
    /// </summary>
    public sealed class ClubPanelController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text headlineLabel = default!;

        [SerializeField]
        private TMP_Text descriptionLabel = default!;

        private void OnEnable()
        {
            headlineLabel.text = "FIND A CLUB";
            descriptionLabel.text = "Search clubs, manage members, and coordinate events.";
        }
    }
}
