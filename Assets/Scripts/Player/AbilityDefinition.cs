using UnityEngine;

namespace NovaArena.Player
{
    public enum AbilityType
    {
        Projectile,
        Area,
        Buff,
        Debuff,
        Mobility
    }

    [CreateAssetMenu(menuName = "NovaArena/Ability", fileName = "AbilityDefinition")]
    public sealed class AbilityDefinition : ScriptableObject
    {
        [SerializeField] private string displayName = "Pulse Shot";
        [SerializeField] private AbilityType abilityType = AbilityType.Projectile;
        [SerializeField] private float cooldown = 3f;
        [SerializeField] private float energyCost = 0f;
        [SerializeField] private GameObject abilityPrefab = default!;

        public string DisplayName => displayName;
        public AbilityType AbilityType => abilityType;
        public float Cooldown => cooldown;
        public float EnergyCost => energyCost;
        public GameObject AbilityPrefab => abilityPrefab;
    }
}
