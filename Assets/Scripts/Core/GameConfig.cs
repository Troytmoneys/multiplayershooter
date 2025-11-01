using UnityEngine;

namespace NovaArena.Core
{
    [CreateAssetMenu(menuName = "NovaArena/Game Config", fileName = "GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [Header("Performance")]
        [SerializeField, Range(30, 240)] private int targetFrameRate = 120;
        [SerializeField] private bool enableVSync = true;

        [Header("Input")]
        [SerializeField] private float mobileJoystickDeadZone = 0.2f;
        [SerializeField] private float aimSmoothing = 12f;
        [SerializeField, Range(0.01f, 1f)] private float mouseSensitivity = 0.15f;
        [SerializeField] private bool invertMouseY = false;
        [SerializeField] private bool lockCursorOnDesktop = true;
        [SerializeField] private bool confineCursorOnDesktop = false;

        [Header("Match")] 
        [SerializeField, Range(60, 600)] private int matchDurationSeconds = 180;
        [SerializeField] private int maxPlayersPerMatch = 6;

        public int TargetFrameRate => targetFrameRate;
        public bool EnableVSync => enableVSync;
        public float MobileJoystickDeadZone => mobileJoystickDeadZone;
        public float AimSmoothing => aimSmoothing;
        public float MouseSensitivity => mouseSensitivity;
        public bool InvertMouseY => invertMouseY;
        public bool LockCursorOnDesktop => lockCursorOnDesktop;
        public bool ConfineCursorOnDesktop => confineCursorOnDesktop;
        public int MatchDurationSeconds => matchDurationSeconds;
        public int MaxPlayersPerMatch => maxPlayersPerMatch;
    }
}
