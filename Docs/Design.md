# Project Vision

Deliver a hero-driven, top-down multiplayer shooter that channels the lightning-fast rhythm of competitive arena brawlers while remaining unmistakably **Nova Arena**. The experience leans into neon sci-fi flair, richer social features, and live-ops depth. A single Unity 6.2 codebase serves Windows desktop and mobile, with unified accounts and an event-driven content pipeline.

## Design Pillars

1. **Team Tactics at Speed** – Matches last 2–4 minutes, rewarding snap decisions, space control, and coordinated ultimate bursts.
2. **Accessible Depth** – Pick-up-and-play controls with layered mastery from hero synergies, gadgets, and rotating arenas.
3. **Always Evolving** – Persistent events, seasonal Star Passes, and experimental game modes keep the meta fresh.
4. **Play Anywhere** – Cross-progression, adaptive UI layouts, and input parity between touch, controller, and KB/M.
5. **Social First** – Crews, parties, and spectating wired into the lobby shell from the first prototype.
6. **Original Identity** – Echo the appeal of top-down hero shooters without borrowing existing franchise terminology or assets.

## Core Loops

- **Engagement Loop**: Queue from lobby → battle for crystal nodes → earn trophies, mastery, and event currency → unlock cosmetics → dive back in.
- **Monetisation Loop**: Pick up Star Pass or shop bundles → complete quests to accelerate rewards → flaunt cosmetics in social spaces → spark further purchases.
- **Social Loop**: Form parties → scrim or queue ranked → review match recap → share highlights via crews/clubs.

## Gameplay Features

- 3v3 core mode with rotating rule sets (Crystal Clash, Payload Push, Data Heist, Sudden Knockout).
- Heroes wield primary fire, signature Nova Burst (ultimate), gadget, and passive augment combinations.
- Dynamic hero roles (Assault, Support, Vanguard, Control) influence matchmaking estimates and roster balance.
- Modern HUD with elimination feed, team score tracking, and hero health telemetry tuned for desktop clarity.
- Party lobby featuring hero carousel, ready checks, and simulated invite flow.

## Technical Architecture

- **Unity 6.2 + URP** for performant cross-platform rendering.
- **Netcode abstraction layer** with simulated latency, ready to swap for Unity Gaming Services, Mirror, or custom servers.
- **Addressables** for on-demand content and seasonal rotations.
- **ScriptableObject data** for heroes, abilities, matchmaking queues, Star Pass configuration, event rotation, quests, shop inventory, and trophy path milestones.
- **Service Locator + Dependency Injection** pattern keeps gameplay code testable and editor-friendly.

## UI/UX Systems

- Responsive main menu built on `MainMenuController`, `HeroCardView`, and `LobbyNavigationController` to showcase Nova Arena's home hub across desktop and mobile.
- Event tab that surfaces the live rotation feed using `EventRotationController`, `EventPanelController`, and `EventRowWidget`/`EventPreviewWidget`.
- Shop tab powered by `ShopPanelController` and `ShopOfferWidget` for featured, daily, and permanent offers with currency badges.
- Star Pass tab showcasing `BattlePassPanelController`, `BattlePassTierWidget`, and quest integration (`QuestPanelController`, `QuestTickerWidget`).
- Trophy Path tab using `TrophyRoadPanelController` and milestone widgets to visualise long-term progression.
- Profile and Club panels delivering social identity hooks with room to expand into full management tooling.
- Matchmaking flow with estimated wait, confirmation state, and cancellation controls (`MatchmakingPanel`).
- HUD overlay comprised of `TeamScoreWidget`, `ScoreFeedWidget`, and context-driven health/ability meters.
- Scene flow controller to manage transitions between lobby, match, and results scenes without breaking services.

## Backlog Snapshot

| Priority | Feature | Notes |
|----------|---------|-------|
| High | Ship hero roster MVP | Eight launch heroes spanning all roles |
| High | Implement Crystal Clash mode | Server-authoritative shard carrier tracking |
| High | Cross-platform input | Desktop twin-stick, mobile virtual joystick, controller navigation |
| High | Real matchmaking integration | Hook UI to live queue + confirmation events |
| Medium | Social hub | Crews, friend invites, spectate queues |
| Medium | Ranked ladder | Seasonal reset, divisions, matchmaking MMR |
| Medium | Shop and economy polish | Animated offers, localized pricing, promo slots |
| Medium | Quest/Star Pass live-ops | Dynamic quest injection, premium track unlocks |
| Low | Cosmetic shop extras | Preview skins on heroes, bundle upsells |
| Low | Replay system | Cloud saved matches with shareable links |

## Live-Ops Content Streams

- **Daily Events** – Rotating 3v3, Solo, and Duo playlists surfaced in the Events tab with countdown timers.
- **Season Pass** – 8-week cadence bundling quests, exclusive cosmetics, and currency injections.
- **Shop Rotations** – Featured hero skins, bundles, and currencies refreshed twice daily to encourage repeat visits.
- **Trophy Path** – Permanent milestone rewards that re-engage returning players and provide a sense of legacy progress.

## Art Direction

- Stylised low-poly characters with bold outlines and emissive accents.
- Bright, saturated palettes with dynamic gradients inspired by neon cityscapes.
- UI built from neumorphic cards, soft shadows, and animated transitions sized for mobile and desktop.

## Audio Direction

- Energetic electronic soundtrack with adaptive layers per match phase.
- Crisp, responsive SFX for shots, Nova Bursts, and UI interactions with emphasis on clarity on mobile speakers.

## Risks & Mitigations

- **Scope creep** → Lock seasonal goals, maintain live backlog, and guard against feature drift.
- **Network latency** → Implement client-side prediction, reconciliation, and latency compensation hooks.
- **Platform compliance** → Automate build validation for iOS, Android, Windows, and macOS.
- **Live-ops maintenance** → Build tooling to edit rotations, shop offers, and quests without full builds.

## Definition of Done (MVP)

- Stable 3v3 PvP gameplay across desktop and mobile builds.
- Hero roster with at least eight unique kits and unlock paths.
- Fully functional lobby shell with clubs, parties, matchmaking, events, shop, quests, trophy path, and profile entry points.
- Star Pass progression loop with daily quests and monetisation tracking.
- Analytics funnel for onboarding, engagement, and monetisation KPIs.
