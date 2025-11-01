using TMPro;
using UnityEngine;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// Basic placeholder for the Clubs social hub replicating Nova Arena Clash' club listing UI.
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
