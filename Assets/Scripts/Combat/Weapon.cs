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

        private float _cooldown;

        private void Update()
        {
            _cooldown -= Time.deltaTime;
        }

        public void Fire(Vector3 forward)
        {
            if (_cooldown > 0f)
            {
                return;
            }

            _cooldown = 1f / Mathf.Max(fireRate, 0.01f);
            AbilityRuntime.Spawn(ability, muzzle.position, forward);
            if (fireSfx != null)
            {
                AudioSource.PlayClipAtPoint(fireSfx, muzzle.position);
            }
        }
    }
}
