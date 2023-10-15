# Keysential

*Server-side global key manager.*

## Changelog

### 1.5.0

  * Fixed for the `v0.217.22` patch.
  * Added new `GetEncodedGlobalKeys()` extension to enable specifying global keys with spaces by using `=` instead.
  * Added in temporary-fix to ensure `StopKeyManager` command actually restores original global keys.

### 1.4.0

  * Add new `GlobalKeysManager` and several new commands related to KeyManager starting and stopping.

### 1.3.0

  * Updated for `v0.217.14` patch.
  * Modified `ZoneSystem.Load()` patch to modify the globalkeys list with `globalKeysAllowedList` if specified.

### 1.2.0

  * Updated for `v0.216.8` PTB patch.
  * Modified `.csproj` to reference Valheim dedicated server DLLs.

### 1.1.1

  * Updated for `v0.216.5` PTB patch.

### 1.1.0

  * Fixed for the `v0.214.2` patch.
  * Added more egg puns for Haldor to say.

### 1.0.0

  * Initial release.
