# CarryWeight

Tiny BepInEx plugin for Valheim: sets the base max carry weight (default **1000**,
vanilla is 300). Client-side only — works on vanilla servers, each player opts in
independently. Bonuses like Megingjord still add on top.

## Install

1. Have BepInEx (via r2modman or manually).
2. Download `CarryWeight.dll` from the [latest release](../../releases/latest).
3. r2modman: *Settings → Import local mod* — or drop the DLL into `BepInEx/plugins/`.

**Verify:** open your inventory — the weight cap should read /1000 (or your
configured value). If it still shows /300, check `BepInEx/LogOutput.log` for the
CarryWeight line: it logs the applied patch count, and an error if the patch
failed to apply.

Config appears after first launch: `needlemods.valheim.carryweight.cfg`, one
value `BaseCarryWeight` (accepted range 300–10000).

## Build

CI builds on every push to master and on PRs (GitHub Actions, no game install
needed — game references come from the `Digitalroot.Valheim.Common.References`
NuGet package, which tracks live game versions). Tagging `v*` cuts a release
with the DLL attached; the release job fails if the tag doesn't match the csproj
`<Version>`, which is the single version source (BepInEx metadata comes from it
via `BepInEx.PluginInfoProps`).

After a Valheim update: bump `Digitalroot.Valheim.Common.References` to the
version matching the game, rebuild, retag. A green build proves the patched
method (`Player.GetMaxCarryWeight`) still exists with the same signature; the
real acceptance test is launching the game and checking the weight cap and the
patch-count log line.
