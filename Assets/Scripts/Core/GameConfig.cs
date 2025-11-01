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

        [Header("Desktop Input")]
        [SerializeField] private bool lockCursorOnDesktop = true;
        [SerializeField] private CursorLockMode desktopCursorMode = CursorLockMode.Confined;
        [SerializeField, Range(0.25f, 4f)] private float desktopAimSensitivity = 1.1f;

        [Header("Match")] 
        [SerializeField, Range(60, 600)] private int matchDurationSeconds = 180;
        [SerializeField] private int maxPlayersPerMatch = 6;

        public int TargetFrameRate => targetFrameRate;
        public bool EnableVSync => enableVSync;
        public float MobileJoystickDeadZone => mobileJoystickDeadZone;
        public float AimSmoothing => aimSmoothing;
        public bool LockCursorOnDesktop => lockCursorOnDesktop;
        public CursorLockMode DesktopCursorMode => desktopCursorMode;
        public float DesktopAimSensitivity => desktopAimSensitivity;
        public int MatchDurationSeconds => matchDurationSeconds;
        public int MaxPlayersPerMatch => maxPlayersPerMatch;
    }
}
