using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NovaArena.UI
{
    /// <summary>
    /// Individual row in the party panel showing name, trophies, and ready state.
    /// </summary>
    public sealed class PartyMemberWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text nameLabel = default!;

        [SerializeField]
        private TMP_Text trophyLabel = default!;

        [SerializeField]
        private Image accentImage = default!;

        [SerializeField]
        private GameObject readyIndicator = default!;

        public void Populate(string displayName, Color themeColor, int trophies)
        {
            nameLabel.text = displayName;
            trophyLabel.text = trophies.ToString();
            accentImage.color = themeColor;
            readyIndicator.SetActive(Random.value > 0.5f);
        }
    }
}
