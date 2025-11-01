using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NovaArena.Networking;

namespace NovaArena.UI
{
    /// <summary>
    /// Displays the current party roster, allowing invite and kick operations to emulate social play.
    /// </summary>
    public sealed class PartyPanel : MonoBehaviour
    {
        [SerializeField]
        private Transform memberContainer = default!;

        [SerializeField]
        private PartyMemberWidget memberPrefab = default!;

        [SerializeField]
        private Button inviteButton = default!;

        private readonly List<PartyMemberWidget> activeWidgets = new();
        private RealtimeSessionManager sessionManager = default!;

        private void Awake()
        {
            sessionManager = FindAnyObjectByType<RealtimeSessionManager>();
            inviteButton.onClick.AddListener(SimulateInvite);
            Refresh();
        }

        public void Refresh()
        {
            foreach (Transform child in memberContainer)
            {
                Destroy(child.gameObject);
            }

            activeWidgets.Clear();

            if (sessionManager == null)
            {
                return;
            }

            foreach (var player in sessionManager.ConnectedPlayers)
            {
                var widget = Instantiate(memberPrefab, memberContainer);
                widget.Populate(player.DisplayName, player.ThemeColor, player.Trophies);
                activeWidgets.Add(widget);
            }
        }

        private void SimulateInvite()
        {
            Debug.Log("Invite friend flow triggered");
        }
    }
}
