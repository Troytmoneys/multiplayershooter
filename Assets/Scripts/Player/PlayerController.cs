using BrawlShooter.Combat;
using BrawlShooter.Core;
using UnityEngine;

namespace BrawlShooter.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private HeroDefinition heroDefinition = default!;
        [SerializeField] private Weapon equippedWeapon = default!;
        [SerializeField] private Transform aimPivot = default!;

        private CharacterController _characterController = default!;
        private IInputRouter _input = default!;
        private float _dashCooldownTimer;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _input = GameServiceLocator.Resolve<IInputRouter>();
            _input.PrimaryFire += OnPrimaryFire;
            _input.SuperAbility += OnSuperAbility;
            _input.Dash += OnDash;
            _input.Enable();
            _dashCooldownTimer = 0f;
        }

        private void OnDestroy()
        {
            if (_input != null)
            {
                _input.PrimaryFire -= OnPrimaryFire;
                _input.SuperAbility -= OnSuperAbility;
                _input.Dash -= OnDash;
                _input.Disable();
            }
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _input.Tick(deltaTime);
            _dashCooldownTimer -= deltaTime;

            var moveVector = new Vector3(_input.Movement.x, 0f, _input.Movement.y);
            _characterController.Move(moveVector * heroDefinition.MoveSpeed * deltaTime);

            if (_input.Aim.sqrMagnitude > 0.01f)
            {
                var forward = new Vector3(_input.Aim.x, 0f, _input.Aim.y);
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
                AbilityRuntime.Spawn(heroDefinition.SuperAbility, aimPivot.position, aimPivot.forward);
            }
        }

        private void OnDash()
        {
            if (_dashCooldownTimer > 0f)
            {
                return;
            }

            _dashCooldownTimer = heroDefinition.DashCooldown;
            var dashVector = aimPivot.forward * 5f;
            _characterController.Move(dashVector);
        }
    }
}
