# Nova Arena Multiplayer Shooter

A Unity 6.2 project scaffold for **Nova Arena**, a fast-paced top-down hero shooter designed for PC and mobile parity. The project focuses on delivering a modernised arena combat experience with an original roster, desktop-ready controls, and a live-ops friendly shell inspired by competitive hero brawlers.

## Highlights

- **Desktop-first controls** – Refined keyboard and mouse bindings with configurable mouse sensitivity, while retaining gamepad and touch support for cross-play prototypes.
- **Original hero ecosystem** – ScriptableObject-driven roster with unique ultimates, passive modifiers, unlock requirements, and rarity tiers tailored to Nova Arena's lore.
- **Complete lobby flow** – Responsive main menu with hero cards, crew roster, bottom navigation, and queue UX that reflects Nova Arena's neon sci-fi branding.
- **Live-ops toolkit** – Event rotation, rotating shop, quests/Star Pass, trophy path, and profile/club panels wired for content pipelines without referencing existing IP.
- **Matchmaking & sessions** – Drop-in service layer that simulates live search/confirmation, plus realtime session manager hooks ready for dedicated servers.
- **Cinematic HUD** – Score widgets, elimination feed, and ability UI themed for Nova Arena's dual-stick combat pacing.

## Repository Structure

```
Assets/
  Scripts/
    Combat/         # Weapons, projectiles, health + elimination routing
    Core/           # Bootstrapping, services, match flow, scene transitions
    Events/         # Event rotation definitions and controllers
    Networking/     # Matchmaking, realtime sessions, replicated state
    Player/         # Hero data, rosters, controllers
    Progression/    # Star pass, quests, trophy path, economy drivers
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
5. **Author live-ops data** via `Create > NovaArena` menus for Heroes, Events, Shop Offers, Quests, Trophy Path, and Star Pass.
6. **Press Play** to explore the main menu, queue flow, live-ops tabs, and simulated match HUD.

> **Note:** Networking code ships as deterministic simulations ready to be swapped for Unity Gaming Services, Mirror, or custom dedicated servers. Replace the internals while keeping the same surface API to maintain UI functionality.

## Next Steps

- Hook ability prefabs to `HeroDefinition` assets and author projectile VFX/SFX.
- Integrate real authentication + matchmaking providers (UGS, PlayFab, Photon, etc.).
- Populate shop offers, quest rotations, and event schedules from backend data stores.
- Flesh out club/social systems with chat, friend lists, and spectate support.
- Polish UX with responsive layout groups, controller navigation, and accessibility options.

## License

MIT
