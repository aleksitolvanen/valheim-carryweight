# CarryWeight

Tiny BepInEx plugin for Valheim: sets the base max carry weight (default **1000**,
vanilla is 300). Client-side only — works on vanilla servers, each player opts in
independently. Bonuses like Megingjord still add on top.

## Install

1. Have BepInEx (via r2modman or manually).
2. Download `CarryWeight.dll` from the [latest release](../../releases/latest).
3. r2modman: *Settings → Import local mod* — or drop the DLL into `BepInEx/plugins/`.

Config appears after first launch: `needlemods.valheim.carryweight.cfg`,
one value `BaseCarryWeight`.

## Build

CI builds on every push (GitHub Actions, no game install needed — references come
from the `ValheimGameLibs` NuGet package). Tag `v*` to cut a release with the DLL
attached.

After a Valheim update: bump `ValheimGameLibs` in the csproj to the matching game
version if the build breaks, rebuild, retag. The patched method
(`Player.GetMaxCarryWeight`) has been stable for years.
