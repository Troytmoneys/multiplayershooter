using UnityEngine;

namespace NovaArena.Player
{
    public enum PassiveStat
    {
        Health,
        MoveSpeed,
        Damage,
        CooldownReduction,
        ShieldCapacity
    }

    [System.Serializable]
    public sealed class PassiveModifier
    {
        [SerializeField] private PassiveStat stat = PassiveStat.Health;
        [SerializeField] private float additiveBonus = 0f;
        [SerializeField] private float multiplicativeBonus = 1f;

        public PassiveStat Stat => stat;
        public float AdditiveBonus => additiveBonus;
        public float MultiplicativeBonus => multiplicativeBonus;
    }
}
