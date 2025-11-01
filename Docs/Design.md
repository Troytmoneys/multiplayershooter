# Project Vision

Build a hero-driven, top-down multiplayer shooter that captures the fast, session-based excitement of Brawl Stars while modernizing visuals, meta progression, and social systems. The game must ship on desktop and mobile with a single codebase and shared live-ops pipeline.

## Design Pillars

1. **Team Tactics at Speed** – Battles should last 2–4 minutes, rewarding quick decisions and smart teamwork.
2. **Accessible Depth** – Simple controls with layered mastery via hero synergies, map knowledge, and ability combos.
3. **Live and Evolving** – Persistent events, rotating modes, and seasonal rewards keep players engaged.
4. **Play Anywhere** – Seamless cross-progression between PC and mobile with adaptive inputs and UI.

## Core Loops

- **Engagement Loop**: Enter match → battle for objectives → earn trophies, currency, and hero mastery → unlock cosmetics and power-ups → queue again.
- **Monetization Loop**: Purchase battle pass or cosmetics → complete quests to accelerate rewards → show off in social spaces → entice additional purchases.

## Gameplay Features

- 3v3 core mode with rotating rulesets (Gem Grab, Bounty, Heist).
- Real-time hero swapping in pre-match to counter opponents.
- Modular ability loadouts: each hero has a primary attack, super ability, and two passives selected from a shared pool.
- Modern visual effects with stylized outlines, emissive projectiles, and dynamic lighting.

## Technical Architecture

- **Unity 6.2 + URP** for performant cross-platform rendering.
- **Netcode for Entities** for deterministic, server-authoritative multiplayer.
- **Addressables** for on-demand content delivery.
- **ScriptableObject data** for heroes, weapons, abilities, quests.
- **Service Locator + Dependency Injection** pattern to keep gameplay code testable.

## Backlog Snapshot

| Priority | Feature | Notes |
|----------|---------|-------|
| High | Build hero roster MVP | 6 heroes, each with unique primary, super, and passives |
| High | Implement Gem Grab mode | Server-authoritative objective tracking |
| High | Cross-platform input | Desktop twin-stick, mobile virtual joystick, gamepad |
| Medium | Social hub prototype | Clans, friend invites, spectating |
| Medium | Ranked ladder | Seasonal reset, divisions, matchmaking MMR |
| Low | Cosmetic shop | Gacha + direct purchase offers |
| Low | Replay system | Cloud-saved match replays |

## Art Direction

- Stylized low-poly characters with bold silhouettes.
- Bright, saturated palettes with emissive highlights.
- Clean UI with neumorphic cards and dynamic gradients.

## Audio Direction

- Energetic electronic soundtrack with adaptive layers per match phase.
- Snappy SFX for shots, hits, and supers; audio clarity prioritized.

## Risks & Mitigations

- **Scope creep** → Define seasonal roadmaps and lock feature sets per sprint.
- **Network latency** → Implement client-side prediction with reconciliation and lag compensation.
- **Platform compliance** → Automate build validation for iOS, Android, Windows, and macOS.

## Definition of Done (MVP)

- Stable 3v3 PvP gameplay across desktop and mobile builds.
- Hero roster with at least six unique kits.
- Fully functional battle pass and cosmetic shop.
- Analytics funnel for onboarding, engagement, and monetization KPIs.
