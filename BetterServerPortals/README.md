﻿# BetterServerPortals

*Now you're thinking with portals.*

## Notes

  * BetterServerPortal icon created by [@jenniely](https://twitter.com/jenniely) (jenniely.com).

## Changelog

### 1.4.0

  * Updated for `v0.217.14` patch.
  * Removed `ZDOMan` patch that manually added in stone `portal` prefab for connection, as logic is now in vanilla.

### 1.3.1

  * Re-add several patches for portal prefab caching logic as vanilla only checks for vanilla 'portal_wood' prefab.
  * Removed the `portalPrefabNames` config option to reduce complexity and support only 'stone' portals for now.

### 1.3.0

  * Fixed for `v0.216.7` PTB patch.
  * Removed all `ZDOMan` patches as portal prefab caching logic is now in vanilla.
  * Extracted the portal connection logic out of `ConnectPortalsCoroutine()` and into new method `ConnectPortals()`.
  * Added a `Game.ConnectPortals()` prefix-patch to ignore the vanilla call and direct into the new method above.

### 1.2.0

  * Changed PluginGuid to `redseiko.valheim.betterserverportals`.
  * Extracted plugin config and patche into separate classes.
  * Added `manifest.json`, and `README.md`.
  * Added new icon created by [@jenniely](https://twitter.com/jenniely).
  * Modified the project file to automatically create a versioned Thunderstore package.

### 1.1.0

  * ???

### 1.0.0

  * Initial release.
