using TMPro;
using UnityEngine;

namespace NovaArena.UI
{
    /// <summary>
    /// Presents team scores, countdown, and objective progress for the HUD overlay.
    /// </summary>
    public sealed class TeamScoreWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text blueScoreLabel = default!;

        [SerializeField]
        private TMP_Text redScoreLabel = default!;

        [SerializeField]
        private TMP_Text timerLabel = default!;

        private int blueScore;
        private int redScore;
        private float timer;
        private bool running;

        public void Configure(int initialBlue, int initialRed, float matchLength)
        {
            blueScore = initialBlue;
            redScore = initialRed;
            timer = matchLength;
            running = true;
            Refresh();
        }

        public void AddBluePoint()
        {
            blueScore++;
            Refresh();
        }

        public void AddRedPoint()
        {
            redScore++;
            Refresh();
        }

        private void Update()
        {
            if (!running)
            {
                return;
            }

            timer = Mathf.Max(0f, timer - Time.deltaTime);
            if (timer <= 0f)
            {
                running = false;
            }

            RefreshTimer();
        }

        private void Refresh()
        {
            blueScoreLabel.text = blueScore.ToString();
            redScoreLabel.text = redScore.ToString();
            RefreshTimer();
        }

        private void RefreshTimer()
        {
            var minutes = Mathf.FloorToInt(timer / 60f);
            var seconds = Mathf.FloorToInt(timer % 60f);
            timerLabel.text = $"{minutes:00}:{seconds:00}";
        }
    }
}
