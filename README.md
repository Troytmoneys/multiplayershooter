# Modern Brawl-Style Multiplayer Shooter

A Unity 6.2 project scaffold that mirrors the full-stack experience of **Brawl Stars** across desktop and mobile. The
repository ships with a ready-to-wire lobby, hero carousel, multiplayer-ready matchmaking simulation, and in-match HUD that
follows Supercell's presentation beats while remaining fully extensible.

## Highlights

- **Cross-platform ready** – Input abstraction works for keyboard/mouse, gamepad, and touch devices.
- **Hero-first design** – ScriptableObject-driven roster with rarity, rotation, unlock requirements, and ability loadouts.
- **Complete lobby flow** – Responsive main menu with hero cards, party roster, simulated invites, and queue UX.
- **Matchmaking & sessions** – Drop-in service layer that mimics live search/confirmation, plus realtime session manager hooks.
- **Modern HUD** – Score widgets, elimination feed, and ability to drive full match telemetry like the mobile original.

## Repository Structure

```
Assets/
  Scripts/
    Combat/         # Weapons, projectiles, health + elimination routing
    Core/           # Bootstrapping, services, match flow, scene transitions
    Networking/     # Matchmaking, realtime sessions, replicated state
    Player/         # Hero data, rosters, controllers
    Progression/    # Battle pass, quests, economy drivers
    UI/             # Lobby, party, matchmaking, HUD widgets
Docs/
  Design.md        # Design pillars, gameplay loops, roadmap
```

## Getting Started

1. **Install Unity 6.2** and clone this repository.
2. **Open the project** with the Unity Hub and let it generate missing project files.
3. **Enable the New Input System** and TextMeshPro packages (UI scripts reference them).
4. **Create a Bootstrap scene** containing `GameBootstrap`, `SceneFlowController`, `RealtimeSessionManager`, and UI prefabs.
5. **Build hero assets** via `Create > BrawlShooter > Hero` and assign them to a `HeroRoster` for the lobby.
6. **Press Play** to explore the main menu, queue flow, and simulated match HUD.

> **Note:** Networking code ships as deterministic simulations ready to be swapped for Unity Gaming Services, Mirror, or
> custom dedicated servers. Replace the internals while keeping the same surface API to maintain UI functionality.

## Next Steps

- Hook ability prefabs to `HeroDefinition` assets and author projectile VFX/SFX.
- Integrate real authentication + matchmaking providers (UGS, PlayFab, Photon, etc.).
- Add map select, ranked ladders, and seasonal events to the lobby shell.
- Flesh out club/social systems with chat, friend lists, and spectate support.
- Polish UX with responsive layout groups, controller navigation, and accessibility options.

## License

MIT
