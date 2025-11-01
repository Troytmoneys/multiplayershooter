using BrawlShooter.Player;
using UnityEngine;

namespace BrawlShooter.Combat
{
    public static class AbilityRuntime
    {
        public static void Spawn(AbilityDefinition definition, Vector3 position, Vector3 forward)
        {
            if (definition == null || definition.AbilityPrefab == null)
            {
                Debug.LogWarning("AbilityDefinition missing prefab; nothing spawned.");
                return;
            }

            var instance = Object.Instantiate(definition.AbilityPrefab, position, Quaternion.LookRotation(forward));
            var projectile = instance.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.Initialize(definition);
            }
        }
    }
}
