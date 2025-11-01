using System;
using UnityEngine;

namespace BrawlShooter.Shop
{
    /// <summary>
    /// Represents a single item in the rotating shop such as skins, coins, or power points.
    /// </summary>
    [CreateAssetMenu(fileName = "ShopOffer", menuName = "BrawlShooter/Shop Offer", order = 0)]
    public sealed class ShopOffer : ScriptableObject
    {
        [SerializeField]
        private string offerId = Guid.NewGuid().ToString();

        [SerializeField]
        private string displayName = "Mega Box";

        [SerializeField]
        private string description = "Contains 5x rewards.";

        [SerializeField]
        private Sprite artwork = default!;

        [SerializeField]
        private CurrencyType currencyType = CurrencyType.Gems;

        [SerializeField]
        private int price = 80;

        [SerializeField]
        private bool isLimited = false;

        [SerializeField]
        private int purchaseLimit = 1;

        public string OfferId => offerId;
        public string DisplayName => displayName;
        public string Description => description;
        public Sprite Artwork => artwork;
        public CurrencyType Currency => currencyType;
        public int Price => price;
        public bool IsLimited => isLimited;
        public int PurchaseLimit => purchaseLimit;
    }

    public enum CurrencyType
    {
        Coins,
        Gems,
        Tickets
    }
}
