using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NovaArena.Core
{
    /// <summary>
    /// Centralises the navigation between bootstrap, lobby, match, and post-match scenes.
    /// Mirrors the flow found in mobile hero brawlers while staying editor-friendly.
    /// </summary>
    public sealed class SceneFlowController : MonoBehaviour
    {
        [SerializeField]
        private string lobbySceneName = "Lobby";

        [SerializeField]
        private string matchSceneName = "Match";

        [SerializeField]
        private string resultsSceneName = "Results";

        private readonly Dictionary<GameScene, string> sceneLookup = new();
        private GameScene activeScene;

        public event Action<GameScene>? SceneChanged;

        private void Awake()
        {
            sceneLookup[GameScene.Lobby] = lobbySceneName;
            sceneLookup[GameScene.Match] = matchSceneName;
            sceneLookup[GameScene.Results] = resultsSceneName;
            activeScene = GameScene.Lobby;
        }

        public void LoadLobby()
        {
            Load(GameScene.Lobby);
        }

        public void LoadMatch()
        {
            Load(GameScene.Match);
        }

        public void LoadResults()
        {
            Load(GameScene.Results);
        }

        private void Load(GameScene target)
        {
            if (activeScene == target || !sceneLookup.TryGetValue(target, out var sceneName))
            {
                return;
            }

            SceneManager.LoadScene(sceneName);
            activeScene = target;
            SceneChanged?.Invoke(activeScene);
        }
    }

    public enum GameScene
    {
        Lobby,
        Match,
        Results
    }
}
