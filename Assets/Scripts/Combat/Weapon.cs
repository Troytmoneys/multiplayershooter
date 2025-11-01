using BrawlShooter.Player;
using UnityEngine;

namespace BrawlShooter.Combat
{
    public sealed class Weapon : MonoBehaviour
    {
        [SerializeField] private AbilityDefinition ability = default!;
        [SerializeField] private Transform muzzle = default!;
        [SerializeField] private float fireRate = 3f;
        [SerializeField] private AudioClip fireSfx = default!;
        [SerializeField] private string instigatorNameOverride = string.Empty;

        private float cooldown;

        private void Update()
        {
            cooldown -= Time.deltaTime;
        }

        public void Fire(Vector3 forward)
        {
            if (cooldown > 0f)
            {
                return;
            }

            cooldown = 1f / Mathf.Max(fireRate, 0.01f);
            var instigator = string.IsNullOrEmpty(instigatorNameOverride) ? transform.root.name : instigatorNameOverride;
            AbilityRuntime.Spawn(ability, muzzle.position, forward, instigator);
            if (fireSfx != null)
            {
                AudioSource.PlayClipAtPoint(fireSfx, muzzle.position);
            }
        }
    }
}
