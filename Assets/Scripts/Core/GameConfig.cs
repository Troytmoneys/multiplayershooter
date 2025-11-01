using UnityEngine;

namespace BrawlShooter.Core
{
    [CreateAssetMenu(menuName = "BrawlShooter/Game Config", fileName = "GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [Header("Performance")]
        [SerializeField, Range(30, 240)] private int targetFrameRate = 120;
        [SerializeField] private bool enableVSync = true;

        [Header("Input")]
        [SerializeField] private float mobileJoystickDeadZone = 0.2f;
        [SerializeField] private float aimSmoothing = 12f;

        [Header("Match")] 
        [SerializeField, Range(60, 600)] private int matchDurationSeconds = 180;
        [SerializeField] private int maxPlayersPerMatch = 6;

        public int TargetFrameRate => targetFrameRate;
        public bool EnableVSync => enableVSync;
        public float MobileJoystickDeadZone => mobileJoystickDeadZone;
        public float AimSmoothing => aimSmoothing;
        public int MatchDurationSeconds => matchDurationSeconds;
        public int MaxPlayersPerMatch => maxPlayersPerMatch;
    }
}
