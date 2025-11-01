using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NovaArena.UI
{
    /// <summary>
    /// Displays a rolling elimination feed themed for Nova Arena's broadcast-style match presentation.
    /// </summary>
    public sealed class ScoreFeedWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text templateLabel = default!;

        [SerializeField]
        private int maxEntries = 4;

        [SerializeField]
        private float entryLifetime = 6f;

        private readonly Queue<(TMP_Text label, float expiry)> activeEntries = new();

        private void Awake()
        {
            templateLabel.gameObject.SetActive(false);
        }

        public void PushEntry(string killer, string victim)
        {
            var label = Instantiate(templateLabel, templateLabel.transform.parent);
            label.gameObject.SetActive(true);
            label.text = $"{killer} eliminated {victim}";
            activeEntries.Enqueue((label, Time.time + entryLifetime));
            Trim();
        }

        private void Update()
        {
            if (activeEntries.Count == 0)
            {
                return;
            }

            while (activeEntries.Count > 0 && Time.time >= activeEntries.Peek().expiry)
            {
                var entry = activeEntries.Dequeue();
                Destroy(entry.label.gameObject);
            }
        }

        private void Trim()
        {
            while (activeEntries.Count > maxEntries)
            {
                var entry = activeEntries.Dequeue();
                Destroy(entry.label.gameObject);
            }
        }
    }
}
