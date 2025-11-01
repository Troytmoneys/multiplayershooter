using BrawlShooter.Player;
using UnityEngine;

namespace BrawlShooter.Combat
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Projectile : MonoBehaviour
    {
        [SerializeField] private float baseSpeed = 20f;
        [SerializeField] private float lifeSeconds = 3f;
        [SerializeField] private int baseDamage = 600;

        private Rigidbody _rigidbody = default!;
        private float _timer;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize(AbilityDefinition sourceAbility)
        {
            var speed = baseSpeed;
            if (sourceAbility != null)
            {
                speed *= Mathf.Lerp(0.5f, 1.5f, (int)sourceAbility.AbilityType / 4f);
            }

            _rigidbody.velocity = transform.forward * speed;
            _timer = lifeSeconds;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthComponent health))
            {
                health.ApplyDamage(baseDamage);
                Destroy(gameObject);
            }
        }
    }
}
