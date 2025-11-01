using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BrawlShooter.Networking;
using BrawlShooter.Player;

namespace BrawlShooter.UI
{
    /// <summary>
    /// Handles player queueing, countdown, and cancel flows for multiplayer matchmaking.
    /// </summary>
    public sealed class MatchmakingPanel : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text statusLabel = default!;

        [SerializeField]
        private TMP_Text estimatedTimeLabel = default!;

        [SerializeField]
        private Button cancelButton = default!;

        [SerializeField]
        private GameObject findingMatchState = default!;

        [SerializeField]
        private GameObject loadingState = default!;

        private Coroutine? pollingRoutine;
        private MatchmakingService? activeService;

        private void Awake()
        {
            cancelButton.onClick.AddListener(() => CancelSearch().Forget());
        }

        public void BeginQueue(HeroDefinition hero, MatchmakingService matchmaking)
        {
            activeService = matchmaking;
            statusLabel.text = $"Queued as {hero.DisplayName}";
            estimatedTimeLabel.text = $"{matchmaking.GetEstimatedTime(hero.Class):0.0}s";
            findingMatchState.SetActive(true);
            loadingState.SetActive(false);

            pollingRoutine = StartCoroutine(Poll(matchmaking));
        }

        private IEnumerator Poll(MatchmakingService matchmaking)
        {
            while (true)
            {
                var state = matchmaking.TickQueue();
                statusLabel.text = state.StatusMessage;
                estimatedTimeLabel.text = $"{state.TimeRemaining:0.0}s";

                if (state.IsMatchReady)
                {
                    findingMatchState.SetActive(false);
                    loadingState.SetActive(true);
                    yield return new WaitForSeconds(0.75f);
                    matchmaking.ConfirmMatch();
                    break;
                }

                yield return new WaitForSeconds(0.5f);
            }

            gameObject.SetActive(false);
        }

        private async Task CancelSearch()
        {
            if (pollingRoutine != null)
            {
                StopCoroutine(pollingRoutine);
                pollingRoutine = null;
            }

            if (activeService != null)
            {
                await activeService.CancelAsync();
            }

            gameObject.SetActive(false);
        }
    }

    internal static class TaskExtensions
    {
        public static async void Forget(this Task task)
        {
            try
            {
                await task;
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
            }
        }
    }
}
