using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NovaArena.Shop;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// UI tile representing a purchasable shop offer.
    /// </summary>
    public sealed class ShopOfferWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text nameLabel = default!;

        [SerializeField]
        private TMP_Text descriptionLabel = default!;

        [SerializeField]
        private TMP_Text priceLabel = default!;

        [SerializeField]
        private Image artworkImage = default!;

        [SerializeField]
        private GameObject limitedTag = default!;

        public void Bind(ShopOffer offer)
        {
            nameLabel.text = offer.DisplayName;
            descriptionLabel.text = offer.Description;
            priceLabel.text = offer.Currency == CurrencyType.Gems
                ? $"{offer.Price}💎"
                : $"{offer.Price}";
            artworkImage.sprite = offer.Artwork;

            if (limitedTag != null)
            {
                limitedTag.SetActive(offer.IsLimited);
            }
        }
    }
}
