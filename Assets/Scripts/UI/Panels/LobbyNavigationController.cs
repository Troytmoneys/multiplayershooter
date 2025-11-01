using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// Handles switching between lobby sub-panels (home, events, shop, brawl pass, profile).
    /// </summary>
    public sealed class LobbyNavigationController : MonoBehaviour
    {
        [System.Serializable]
        private sealed class TabDefinition
        {
            public string Name = string.Empty;
            public Button Button = default!;
            public GameObject Panel = default!;
            public UnityEvent OnSelected = new();
        }

        [SerializeField]
        private List<TabDefinition> tabs = new();

        private TabDefinition? active;

        private void Awake()
        {
            foreach (var tab in tabs)
            {
                var captured = tab;
                tab.Button.onClick.AddListener(() => Select(captured));
            }
        }

        private void Start()
        {
            if (tabs.Count > 0)
            {
                Select(tabs[0]);
            }
        }

        public void ShowTab(string name)
        {
            var tab = tabs.Find(t => t.Name == name);
            if (tab != null)
            {
                Select(tab);
            }
        }

        private void Select(TabDefinition tab)
        {
            if (active == tab)
            {
                return;
            }

            foreach (var candidate in tabs)
            {
                candidate.Panel.SetActive(candidate == tab);
            }

            active = tab;
            tab.OnSelected?.Invoke();
        }
    }
}
