using System.Collections.Generic;
using TMPro;
using UnityEngine;
using NovaArena.Progression;

namespace NovaArena.UI.Panels
{
    /// <summary>
    /// Renders the trophy road track with milestone rewards.
    /// </summary>
    public sealed class TrophyRoadPanelController : MonoBehaviour
    {
        [SerializeField]
        private TrophyRoadDefinition trophyRoad = default!;

        [SerializeField]
        private Transform nodeContainer = default!;

        [SerializeField]
        private TrophyRoadNodeWidget nodePrefab = default!;

        private readonly List<TrophyRoadNodeWidget> nodes = new();

        private void OnEnable()
        {
            BuildNodes();
        }

        private void OnDisable()
        {
            foreach (var widget in nodes)
            {
                if (widget != null)
                {
                    Destroy(widget.gameObject);
                }
            }

            nodes.Clear();
        }

        private void BuildNodes()
        {
            foreach (Transform child in nodeContainer)
            {
                Destroy(child.gameObject);
            }

            nodes.Clear();

            foreach (var milestone in trophyRoad.Milestones)
            {
                var node = Instantiate(nodePrefab, nodeContainer);
                node.Bind(milestone);
                nodes.Add(node);
            }
        }
    }
}
