# Nova Arena Clash – Cross-Platform Hero Shooter

A Unity 6.2 project scaffold that delivers a modern, cross-platform hero arena experience for PC and mobile. Built from the
ground up to evoke the fast, top-down action of hero-based battlers while introducing a fresh identity, the repository ships
with a ready-to-wire lobby, hero carousel, multiplayer-ready matchmaking simulation, and in-match HUD tailored for desktop
mouse/keyboard alongside touch input.

## Highlights

- **Desktop-first polish** – Keyboard, mouse, and gamepad bindings preconfigured for Windows, macOS, and Linux builds while still supporting touchscreens.
- **Hero-first design** – ScriptableObject-driven roster with rarity, rotation, unlock requirements, and ability loadouts.
- **Complete lobby flow** – Responsive main menu with hero cards, party roster, bottom navigation, and queue UX.
- **Live-ops suite** – Events tab, rotating supply drop shop, quest tracker, trophy trail, profile, and clubs designed around the Nova Arena theme.
- **Matchmaking & sessions** – Drop-in service layer that mimics live search/confirmation, plus realtime session manager hooks.
- **Modern HUD** – Score widgets, elimination feed, and ability telemetry mirroring the Nova Arena combat language.

## Repository Structure

```
Assets/
  Scripts/
    Combat/         # Weapons, projectiles, health + elimination routing
    Core/           # Bootstrapping, services, match flow, scene transitions
    Events/         # Event rotation definitions and controllers
    Networking/     # Matchmaking, realtime sessions, replicated state
    Player/         # Hero data, rosters, controllers
    Progression/    # Season pass, quests, trophy trail, economy drivers
    Shop/           # Shop offers and inventory assets
    UI/             # Lobby, navigation, matchmaking, HUD widgets
Docs/
  Design.md        # Design pillars, gameplay loops, roadmap
```

## Getting Started

1. **Install Unity 6.2** and clone this repository.
2. **Open the project** with the Unity Hub and let it generate missing project files.
3. **Enable the New Input System** and TextMeshPro packages (UI scripts reference them).
4. **Create a Bootstrap scene** containing `GameBootstrap`, `SceneFlowController`, `RealtimeSessionManager`, and UI prefabs.
5. **Author live-ops data** via `Create > NovaArena` menus for Heroes, Events, Shop Offers, Quests, Trophy Trail, and Season Pass.
6. **Press Play** to explore the main menu, queue flow, live-ops tabs, and simulated match HUD.

> **Note:** Networking code ships as deterministic simulations ready to be swapped for Unity Gaming Services, Mirror, or
> custom dedicated servers. Replace the internals while keeping the same surface API to maintain UI functionality.

## Next Steps

- Hook ability prefabs to `HeroDefinition` assets and author projectile VFX/SFX.
- Integrate real authentication + matchmaking providers (UGS, PlayFab, Photon, etc.).
- Populate shop offers, quest rotations, and event schedules from backend data stores.
- Flesh out club/social systems with chat, friend lists, and spectate support.
- Polish UX with responsive layout groups, controller navigation, and accessibility options.

## License

MIT
