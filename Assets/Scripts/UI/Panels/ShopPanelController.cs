using System.Collections.Generic;
using TMPro;
using UnityEngine;
using NovaArena.Shop;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// Displays rotating and permanent shop offers matching the Shop tab in Nova Arena Clash.
    /// </summary>
    public sealed class ShopPanelController : MonoBehaviour
    {
        [SerializeField]
        private ShopInventory inventory = default!;

        [SerializeField]
        private Transform featuredContainer = default!;

        [SerializeField]
        private Transform dailyContainer = default!;

        [SerializeField]
        private Transform permanentContainer = default!;

        [SerializeField]
        private ShopOfferWidget offerPrefab = default!;

        [SerializeField]
        private TMP_Text refreshLabel = default!;

        private readonly List<ShopOfferWidget> spawnedOffers = new();

        private void OnEnable()
        {
            BuildSection(inventory.FeaturedOffers, featuredContainer);
            BuildSection(inventory.DailyOffers, dailyContainer);
            BuildSection(inventory.PermanentOffers, permanentContainer);
            refreshLabel.text = "REFRESH IN 8H";
        }

        private void OnDisable()
        {
            foreach (var offer in spawnedOffers)
            {
                if (offer != null)
                {
                    Destroy(offer.gameObject);
                }
            }

            spawnedOffers.Clear();
        }

        private void BuildSection(IReadOnlyList<ShopOffer> offers, Transform parent)
        {
            foreach (var offer in offers)
            {
                var widget = Instantiate(offerPrefab, parent);
                widget.Bind(offer);
                spawnedOffers.Add(widget);
            }
        }
    }
}
