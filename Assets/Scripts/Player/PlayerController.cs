using NovaArena.Combat;
using NovaArena.Core;
using UnityEngine;

namespace NovaArena.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private HeroDefinition heroDefinition = default!;
        [SerializeField] private Weapon equippedWeapon = default!;
        [SerializeField] private Transform aimPivot = default!;

        private CharacterController characterController = default!;
        private IInputRouter input = default!;
        private float dashCooldownTimer;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            input = GameServiceLocator.Resolve<IInputRouter>();
            input.PrimaryFire += OnPrimaryFire;
            input.SuperAbility += OnSuperAbility;
            input.Dash += OnDash;
            input.Enable();
            dashCooldownTimer = 0f;
        }

        private void OnDestroy()
        {
            if (input != null)
            {
                input.PrimaryFire -= OnPrimaryFire;
                input.SuperAbility -= OnSuperAbility;
                input.Dash -= OnDash;
                input.Disable();
            }
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            input.Tick(deltaTime);
            dashCooldownTimer -= deltaTime;

            var moveVector = new Vector3(input.Movement.x, 0f, input.Movement.y);
            characterController.Move(moveVector * heroDefinition.MoveSpeed * deltaTime);

            if (input.Aim.sqrMagnitude > 0.01f)
            {
                var forward = new Vector3(input.Aim.x, 0f, input.Aim.y);
                if (forward.sqrMagnitude > 0.01f)
                {
                    aimPivot.forward = Vector3.Lerp(aimPivot.forward, forward.normalized, deltaTime * 20f);
                }
            }
        }

        private void OnPrimaryFire()
        {
            if (equippedWeapon != null)
            {
                equippedWeapon.Fire(aimPivot.forward);
            }
        }

        private void OnSuperAbility()
        {
            if (heroDefinition.SuperAbility != null)
            {
                AbilityRuntime.Spawn(heroDefinition.SuperAbility, aimPivot.position, aimPivot.forward, heroDefinition.DisplayName);
            }
        }

        private void OnDash()
        {
            if (dashCooldownTimer > 0f)
            {
                return;
            }

            dashCooldownTimer = heroDefinition.DashCooldown;
            var dashVector = aimPivot.forward * 5f;
            characterController.Move(dashVector);
        }
    }
}
