using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NovaArena.Core
{
    public interface IInputRouter
    {
        Vector2 Movement { get; }
        Vector2 Aim { get; }
        event Action PrimaryFire;
        event Action SuperAbility;
        event Action Dash;
        void Enable();
        void Disable();
        void Tick(float deltaTime);
    }

    /// <summary>
    /// Wraps the Unity Input System to support desktop, gamepad, and mobile controls.
    /// </summary>
    public sealed class InputRouter : IInputRouter
    {
        private readonly GameConfig _config;
        private readonly PlayerInputActions _actions;
        private Vector2 _aim;

        public InputRouter(GameConfig config)
        {
            _config = config;
            _actions = new PlayerInputActions();
        }

        public Vector2 Movement => _actions.Gameplay.Move.ReadValue<Vector2>();
        public Vector2 Aim => _aim;

        public event Action PrimaryFire = delegate { };
        public event Action SuperAbility = delegate { };
        public event Action Dash = delegate { };

        public void Enable()
        {
            _actions.Enable();
            _actions.Gameplay.Fire.performed += OnPrimaryFire;
            _actions.Gameplay.Super.performed += OnSuper;
            _actions.Gameplay.Dash.performed += OnDash;
        }

        public void Disable()
        {
            _actions.Gameplay.Fire.performed -= OnPrimaryFire;
            _actions.Gameplay.Super.performed -= OnSuper;
            _actions.Gameplay.Dash.performed -= OnDash;
            _actions.Disable();
        }

        public void Tick(float deltaTime)
        {
            if (Touchscreen.current != null)
            {
                var touch = GetPrimaryTouch();
                if (touch.HasValue)
                {
                    var normalized = touch.Value.delta;
                    _aim = Vector2.Lerp(_aim, normalized, deltaTime * _config.AimSmoothing);
                    return;
                }
            }

            var desktopAim = _actions.Gameplay.Aim.ReadValue<Vector2>() * _config.DesktopAimSensitivity;
            _aim = Vector2.Lerp(_aim, desktopAim, deltaTime * _config.AimSmoothing);
        }

        private static Touch? GetPrimaryTouch()
        {
            if (Touchscreen.current == null || Touchscreen.current.touches.Count == 0)
            {
                return null;
            }

            foreach (var control in Touchscreen.current.touches)
            {
                if (control.press.isPressed)
                {
                    return control.ReadValue();
                }
            }

            return null;
        }

        private void OnPrimaryFire(InputAction.CallbackContext context) => PrimaryFire.Invoke();
        private void OnSuper(InputAction.CallbackContext context) => SuperAbility.Invoke();
        private void OnDash(InputAction.CallbackContext context) => Dash.Invoke();
    }
}
