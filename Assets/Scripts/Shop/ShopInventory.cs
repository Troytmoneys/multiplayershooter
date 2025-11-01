using System.Collections.Generic;
using UnityEngine;

namespace BrawlShooter.Shop
{
    /// <summary>
    /// ScriptableObject wrapper around the rotating and permanent shop offers.
    /// </summary>
    [CreateAssetMenu(fileName = "ShopInventory", menuName = "BrawlShooter/Shop Inventory", order = 1)]
    public sealed class ShopInventory : ScriptableObject
    {
        [SerializeField]
        private List<ShopOffer> featuredOffers = new();

        [SerializeField]
        private List<ShopOffer> dailyOffers = new();

        [SerializeField]
        private List<ShopOffer> permanentOffers = new();

        public IReadOnlyList<ShopOffer> FeaturedOffers => featuredOffers;
        public IReadOnlyList<ShopOffer> DailyOffers => dailyOffers;
        public IReadOnlyList<ShopOffer> PermanentOffers => permanentOffers;
    }
}
