using BrawlShooter.Player;
using UnityEngine;

namespace BrawlShooter.Combat
{
    public static class AbilityRuntime
    {
        public static void Spawn(AbilityDefinition definition, Vector3 position, Vector3 forward, string instigator)
        {
            if (definition == null || definition.AbilityPrefab == null)
            {
                Debug.LogWarning("AbilityDefinition missing prefab; nothing spawned.");
                return;
            }

            var instance = Object.Instantiate(definition.AbilityPrefab, position, Quaternion.LookRotation(forward));
            if (instance.TryGetComponent(out Projectile projectile))
            {
                projectile.Initialize(definition, instigator);
            }
        }
    }
}
