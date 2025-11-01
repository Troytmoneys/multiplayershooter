using System.Collections.Generic;
using TMPro;
using UnityEngine;
using NovaArena.Events;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// Displays the rotating events list and countdown timers styled for Nova Arena's operations console.
    /// </summary>
    public sealed class EventPanelController : MonoBehaviour
    {
        [SerializeField]
        private EventRotationController rotationController = default!;

        [SerializeField]
        private Transform eventListContainer = default!;

        [SerializeField]
        private EventRowWidget eventRowPrefab = default!;

        [SerializeField]
        private TMP_Text countdownLabel = default!;

        private readonly List<EventRowWidget> rows = new();

        private void OnEnable()
        {
            rotationController.RotationChanged += Refresh;
            Refresh();
        }

        private void OnDisable()
        {
            rotationController.RotationChanged -= Refresh;
        }

        private void Update()
        {
            var remaining = rotationController.Remaining;
            countdownLabel.text = remaining <= System.TimeSpan.Zero
                ? "NEW EVENTS!"
                : $"NEW EVENTS IN {remaining:hh\\:mm}";
        }

        private void Refresh()
        {
            foreach (Transform child in eventListContainer)
            {
                Destroy(child.gameObject);
            }

            rows.Clear();

            foreach (var evt in rotationController.ActiveEvents)
            {
                var row = Object.Instantiate(eventRowPrefab, eventListContainer);
                row.Bind(evt);
                rows.Add(row);
            }
        }
    }
}
