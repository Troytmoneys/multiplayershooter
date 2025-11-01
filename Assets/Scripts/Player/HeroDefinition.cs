using UnityEngine;

namespace BrawlShooter.Player
{
    [CreateAssetMenu(menuName = "BrawlShooter/Hero", fileName = "HeroDefinition")]
    public sealed class HeroDefinition : ScriptableObject
    {
        [Header("Identity")]
        [SerializeField] private string heroName = "Nova";
        [SerializeField, TextArea] private string description = "Versatile ranger with adaptive fire modes.";
        [SerializeField] private Sprite portrait = default!;

        [Header("Stats")]
        [SerializeField, Range(1000, 5000)] private int health = 2200;
        [SerializeField, Range(2f, 10f)] private float moveSpeed = 5.6f;
        [SerializeField, Range(0.1f, 1f)] private float dashCooldown = 0.35f;

        [Header("Abilities")]
        [SerializeField] private AbilityDefinition primaryAbility = default!;
        [SerializeField] private AbilityDefinition superAbility = default!;
        [SerializeField] private PassiveModifier[] passives = new PassiveModifier[0];

        public string HeroName => heroName;
        public string Description => description;
        public Sprite Portrait => portrait;
        public int Health => health;
        public float MoveSpeed => moveSpeed;
        public float DashCooldown => dashCooldown;
        public AbilityDefinition PrimaryAbility => primaryAbility;
        public AbilityDefinition SuperAbility => superAbility;
        public PassiveModifier[] Passives => passives;
    }
}
