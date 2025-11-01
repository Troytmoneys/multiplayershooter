using NovaArena.Networking;
using UnityEngine;

namespace NovaArena.Core
{
    /// <summary>
    /// Bootstraps core systems and ensures cross-platform configuration is applied at launch.
    /// Attach this to a GameObject in the bootstrap scene.
    /// </summary>
    public sealed class GameBootstrap : MonoBehaviour
    {
        [SerializeField]
        private GameConfig config = default!;

        [SerializeField]
        private RealtimeSessionManager sessionManager = default!;

        [SerializeField]
        private bool enableDebugHud = true;

        private void Awake()
        {
            Application.targetFrameRate = config.TargetFrameRate;
            QualitySettings.vSyncCount = config.EnableVSync ? 1 : 0;

            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                if (config.LockCursorOnDesktop)
                {
                    Cursor.lockState = config.DesktopCursorMode;
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            GameServiceLocator.Clear();
            GameServiceLocator.Register(config);

            var matchState = new MatchStateController();
            matchState.ConfigureMatchLength(config.MatchDurationSeconds);
            GameServiceLocator.Register(matchState);

            var inputRouter = new InputRouter(config);
            GameServiceLocator.Register<IInputRouter>(inputRouter);

            var analytics = new TelemetryService();
            GameServiceLocator.Register<ITelemetryService>(analytics);

            if (sessionManager != null)
            {
                DontDestroyOnLoad(sessionManager.gameObject);
            }

            if (enableDebugHud)
            {
                Debug.Log("Game bootstrap completed.");
            }
        }
    }
}
