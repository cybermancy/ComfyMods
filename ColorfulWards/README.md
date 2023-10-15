# ColorfulWards

  * You can color the glow effect of any ward using RGB and HTML color codes!
  * Those without the mod installed will still see the default yellow glow.

## Instructions

### Changing ward glow effect color

  * In-game, press F1 to bring up the ConfigurationManager and navigate to the ColorfulWards section.
    * Change the target color using the RGB sliders or using an HTML color code.

  - Hover over any ward **that you are the owner of** and a prompt to change its color will appear.
    - This prompt can be hidden by disabling the `showChangeColorHoverText` setting.

  * Hit `LeftShift + E` (configurable) to change the color of the ward glow effect.

### Ward vertical radius

  * **Wards will now only extend/cover its default radius (30m) on the vertical/Y axis.**
    * Can be toggled on/off in configuration options.
  * In the vanilla game, the range is infinite on the Y axis and the default radius on the XZ axis.

## Notes

  * See source at: [GitHub](https://github.com/redseiko/ComfyMods/tree/main/ColorfulLights).
  * Looking for a chill Valheim server? [Comfy Valheim Discord](https://discord.gg/ameHJz5PFk)
  * Check out our community driven listing site at: [valheimlist.org](https://valheimlist.org/)

## Changelog

### 1.6.0

  * Fixed for the `v0.217.14` patch.
  * Extracted all patch logic into separate classes.
  * Created new `PrivateAreaColor` component to encapsulate and simplify ward coloring logic.
  * Rewrote the `PrivateArea.IsInside()` from a prefix-patch to transpiler.
  * `TargetWardColor` now uses new `ExtendedColorConfigEntry` used in other colorful mods.
  * Modified the keyboard shortcut logic to prevent further keypress if a the action was performed.

### 1.5.0

  * Updated for the `v0.216.9` patch.
  * Modified `Player.TakeInput()` transpiler to happen after `Player.UpdateHover()` and no longer block other inputs.
  * Modified `ChangeWardColor` to no longer be a coroutine.

### 1.4.1

  * Fixed a bug with the `Player.TakeInput()` transpiler blocking other inputs with the same keybind.

### 1.4.0

  * Moved change color code from `PrivateArea.Interact()` prefix to `Player.TakeInput()` transpiler with coroutine.
    * Can now configure the hot-key to change ward color.
  * Removed configuration option for `colorPromptFontSize` (UI overhaul coming later).
  * Extracted configuration options into new `PluginConfig` class.
  * Added `manifest.json`, `icon.png` and updated this `README.md`.
  * Modified the project file to automatically create a versioned Thunderstore package.

### 1.3.0

  * Updated for Hearth & Home.
  * Added `WardLastColoredBy` ZDO tag that is set to the last Player that modifies the Ward color.
  * Added an option to change the font-size for the text prompt on hover.

### 1.2.0

  * Fixed a memory-leak when caching PrivateArea/Wards.

### 1.1.0

  * Adding configuration setting to hide the 'change color' prompt over a ward.
  * Now saves the target color's **alpha** value to the ZDO and reads/uses this alpha value if present in the ZDO.
    * However, there isn't any apparent effect/use for color alpha for ward lights and particle systems.'

### 1.0.0

  * Initial release.