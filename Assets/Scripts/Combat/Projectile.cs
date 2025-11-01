using NovaArena.Player;
using UnityEngine;

namespace NovaArena.Combat
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Projectile : MonoBehaviour
    {
        [SerializeField] private float baseSpeed = 20f;
        [SerializeField] private float lifeSeconds = 3f;
        [SerializeField] private int baseDamage = 600;

        private Rigidbody physicsBody = default!;
        private float timer;
        private string instigatorName = "Unknown";

        private void Awake()
        {
            physicsBody = GetComponent<Rigidbody>();
        }

        public void Initialize(AbilityDefinition sourceAbility, string instigator)
        {
            instigatorName = instigator;
            var speed = baseSpeed;
            if (sourceAbility != null)
            {
                speed *= Mathf.Lerp(0.5f, 1.5f, (int)sourceAbility.AbilityType / 4f);
            }

            physicsBody.velocity = transform.forward * speed;
            timer = lifeSeconds;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthComponent health))
            {
                health.ApplyDamage(baseDamage, instigatorName);
                Destroy(gameObject);
            }
        }
    }
}
