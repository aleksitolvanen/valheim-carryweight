# CarryWeight

BepInEx plugin for Valheim: configurable base max carry weight (default 1000,
vanilla 300). Client-side, works on vanilla servers. Megingjord still adds on top.

## Install

1. BepInEx (r2modman or manual).
2. `CarryWeight.dll` from the [latest release](../../releases/latest) →
   r2modman *Import local mod*, or drop into `BepInEx/plugins/`.
3. Verify in-game: inventory weight cap reads /1000. Still /300 → check
   `BepInEx/LogOutput.log` for the CarryWeight line.

Config after first launch: `needlemods.valheim.carryweight.cfg`,
`BaseCarryWeight` (300–10000).

## Build

CI builds pushes/PRs; a `v*` tag cuts a release (tag must match csproj
`<Version>`). After a game update: bump `Digitalroot.Valheim.Common.References`
to the game's version, rebuild, retag. The real test is in-game.
