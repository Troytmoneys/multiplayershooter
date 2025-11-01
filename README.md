# Modern Brawl-Style Multiplayer Shooter

This repository contains a Unity 6.2 project scaffold for building a modernized, cross-platform twin-stick hero shooter inspired by **Brawl Stars**. The goal of the project is to provide a clean architecture, tooling, and sample gameplay code that targets both desktop and mobile builds while leaving room for custom content and monetization.

## Highlights

- **Cross-platform ready** – Input abstraction works for keyboard/mouse, gamepad, and touch devices.
- **Hero-centric gameplay** – ScriptableObject-driven hero definitions with configurable stats and abilities.
- **Modular combat** – Data-first weapons, projectiles, and abilities that can be mixed and matched across heroes.
- **Online-first architecture** – Network boundary classes prepared for dedicated server or peer-hosted topologies.
- **Live-ops friendly** – Battle pass hooks, analytics events, and feature toggles meant for rapid iteration.

## Repository Structure

```
Assets/
  Scripts/
    Combat/         # Weapons, projectiles, ability logic
    Core/           # Bootstrapping, service locator, match flow
    Networking/     # Matchmaking, netcode abstraction
    Player/         # Hero definitions, controllers, progression
    Progression/    # Battle pass, quests, economy drivers
    UI/             # HUD and front-end presentation
Docs/
  Design.md        # Design pillars, gameplay loops, backlog
```

## Getting Started

1. **Install Unity 6.2** and clone this repository.
2. **Open the project** with the Unity Hub and let it generate missing project files.
3. **Enable new Input System** and **Netcode for Entities** packages in the Unity Package Manager.
4. **Open the `Bootstrap` scene** (to be created) and attach the provided scripts to scene objects.
5. **Press Play** to run the prototype in the editor. Use WASD + mouse on desktop or the provided mobile controls.

> **Note:** The project is intentionally content-light. The focus is to provide a strong foundation that can be extended with bespoke heroes, maps, cosmetics, and monetization hooks.

## Next Steps

- Build hero-specific ability prefabs and hook them into `HeroDefinition` assets.
- Integrate Unity Gaming Services for authentication, matchmaking, and cloud saves.
- Implement authoritative dedicated server logic using DOTS Netcode.
- Add live events, seasonal battle pass content, and robust analytics.
- Polish UX with responsive UI, accessibility features, and high-quality VFX.

## License

MIT
