using UnityEngine;

namespace BrawlShooter.Core
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
        private bool enableDebugHud = true;

        private void Awake()
        {
            Application.targetFrameRate = config.TargetFrameRate;
            QualitySettings.vSyncCount = config.EnableVSync ? 1 : 0;

            GameServiceLocator.Clear();
            GameServiceLocator.Register(config);

            var matchState = new MatchStateController();
            GameServiceLocator.Register(matchState);

            var inputRouter = new InputRouter(config);
            GameServiceLocator.Register<IInputRouter>(inputRouter);

            var analytics = new TelemetryService();
            GameServiceLocator.Register<ITelemetryService>(analytics);

            if (enableDebugHud)
            {
                Debug.Log("Game bootstrap completed.");
            }
        }
    }
}
