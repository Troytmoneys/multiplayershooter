# Project Vision

Deliver a hero-driven, top-down multiplayer shooter that captures the quickfire intensity of Brawl Stars while modernising the
experience with richer social features, cross-platform polish, and live-ops depth. The game targets desktop and mobile with a
single Unity 6.2 codebase, unified account system, and event-driven content pipeline.

## Design Pillars

1. **Team Tactics at Speed** – Battles last 2–4 minutes, rewarding snap decisions and coordinated supers.
2. **Accessible Depth** – Easy-to-read controls with layered mastery from hero synergies, gadgets, and map rotations.
3. **Live and Evolving** – Persistent events, seasonal battle passes, and rotating game modes keep the meta fresh.
4. **Play Anywhere** – Cross-progression, adaptive UI layouts, and input parity between touch, controller, and KB/M.
5. **Social First** – Clubs, parties, and spectating baked into the lobby shell from day one.
6. **Familiar but Fresh** – Mirror Brawl Stars' structure while injecting new cosmetics, events, and UX refinements.

## Core Loops

- **Engagement Loop**: Queue from lobby → fight for objectives → earn trophies, mastery, and event currency → unlock cosmetics →
  re-enter the queue.
- **Monetisation Loop**: Buy battle pass or shop offers → complete quests to accelerate rewards → showcase cosmetics in social
  spaces → entice further purchases.
- **Social Loop**: Form parties → scrim or queue ranked → review match recap → share highlights via clubs.

## Gameplay Features

- 3v3 core mode with rotating rule sets (Gem Grab, Bounty, Heist, Knockout).
- Hero brawler kits composed of primary attack, super ability, gadget, and star power modifiers.
- Dynamic hero roles (Damage, Support, Tank, Controller) influence matchmaking estimates and roster balance.
- Modern HUD with elimination feed, team score tracking, and hero health telemetry.
- Party lobby featuring hero carousel, ready checks, and simulated invite flow.

## Technical Architecture

- **Unity 6.2 + URP** for performant cross-platform rendering.
- **Netcode abstraction layer** with simulated latency, ready to swap for Unity Gaming Services, Mirror, or custom servers.
- **Addressables** for on-demand content and event rotations.
- **ScriptableObject data** for heroes, abilities, matchmaking queues, battle pass configuration, event rotation, quests, shop
  inventory, and trophy road milestones.
- **Service Locator + Dependency Injection** pattern keeps gameplay code testable and editor-friendly.

## UI/UX Systems

- Responsive main menu built on `MainMenuController`, `HeroCardView`, and `LobbyNavigationController` to mirror Brawl Stars home
  screen beats across desktop and mobile.
- Event tab that mirrors the live rotation feed using `EventRotationController`, `EventPanelController`, and
  `EventRowWidget`/`EventPreviewWidget`.
- Shop tab powered by `ShopPanelController` and `ShopOfferWidget` for featured, daily, and permanent offers with currency badges.
- Brawl Pass tab showcasing `BattlePassPanelController`, `BattlePassTierWidget`, and quest integration (`QuestPanelController`,
  `QuestTickerWidget`).
- Trophy Road tab using `TrophyRoadPanelController` and milestone widgets to visualise long-term progression.
- Profile and Club panels delivering social identity hooks that can expand into full management tooling.
- Matchmaking flow with estimated wait, confirmation state, and cancellation controls (`MatchmakingPanel`).
- HUD overlay comprised of `TeamScoreWidget`, `ScoreFeedWidget`, and context-driven health/ability meters.
- Scene flow controller to manage transitions between lobby, match, and results scenes without breaking services.

## Backlog Snapshot

| Priority | Feature | Notes |
|----------|---------|-------|
| High | Ship hero roster MVP | 8 launch heroes spanning all roles |
| High | Implement Gem Grab mode | Server-authoritative gem carrier tracking |
| High | Cross-platform input | Desktop twin-stick, mobile virtual joystick, controller navigation |
| High | Real matchmaking integration | Hook UI to live queue + confirmation events |
| Medium | Social hub | Clubs, friend invites, spectate queues |
| Medium | Ranked ladder | Seasonal reset, divisions, matchmaking MMR |
| Medium | Shop and economy polish | Animated offers, localized pricing, promo slots |
| Medium | Quest/Brawl Pass live-ops | Dynamic quest injection, premium track unlocks |
| Low | Cosmetic shop extras | Preview skins on heroes, bundle upsells |
| Low | Replay system | Cloud saved matches with shareable links |

## Live-Ops Content Streams

- **Daily Events** – Rotating 3v3, Solo, and Duo playlists surfaced in the Events tab with countdown timers.
- **Season Pass** – 8-week cadence bundling quests, exclusive cosmetics, and currency injections.
- **Shop Rotations** – Featured hero skins, bundles, and currencies swapped twice daily to encourage repeat visits.
- **Trophy Road** – Permanent milestone rewards that re-engage returning players and provide a sense of legacy progress.

## Art Direction

- Stylised low-poly characters with bold outlines and emissive accents.
- Bright, saturated palettes with dynamic gradients mirroring Supercell's aesthetic.
- UI built from neumorphic cards, soft shadows, and animated transitions sized for mobile and desktop.

## Audio Direction

- Energetic electronic soundtrack with adaptive layers per match phase.
- Crisp, responsive SFX for shots, supers, and UI interactions with emphasis on clarity on mobile speakers.

## Risks & Mitigations

- **Scope creep** → Lock seasonal goals, maintain live backlog, and guard against feature drift.
- **Network latency** → Implement client-side prediction, reconciliation, and latency compensation hooks.
- **Platform compliance** → Automate build validation for iOS, Android, Windows, and macOS.
- **Live-ops maintenance** → Build tooling to edit rotations, shop offers, and quests without full builds.

## Definition of Done (MVP)

- Stable 3v3 PvP gameplay across desktop and mobile builds.
- Hero roster with at least eight unique kits and unlock paths.
- Fully functional lobby shell with clubs, parties, matchmaking, events, shop, quests, trophy road, and profile entry points.
- Battle pass progression loop with daily quests and monetisation tracking.
- Analytics funnel for onboarding, engagement, and monetisation KPIs.
