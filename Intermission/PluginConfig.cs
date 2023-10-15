﻿using System;

using BepInEx.Configuration;

using ComfyLib;

using UnityEngine;

namespace Intermission {
  public static class PluginConfig {
    public static ConfigEntry<bool> IsModEnabled { get; private set; }

    public static ConfigEntry<Color> LoadingImageBaseColor { get; private set; }

    public static ConfigEntry<bool> LoadingImageUseScaleLerp { get; private set; }
    public static ConfigEntry<float> LoadingImageScaleLerpEndScale { get; private set; }
    public static ConfigEntry<float> LoadingImageScaleLerpDuration { get; private set; }

    public static ConfigEntry<bool> LoadingScreenShowPanelSeparator { get; private set; }
    public static ConfigEntry<Vector2> LoadingScreenPanelSeparatorPosition { get; private set; }

    public static ConfigEntry<Vector2> LoadingTipTextPosition { get; private set; }
    public static ConfigEntry<int> LoadingTipTextFontSize { get; private set; }
    public static ConfigEntry<Color> LoadingTipTextColor { get; private set; }

    public static void BindConfig(ConfigFile config) {
      IsModEnabled =
          config.BindInOrder(
              "_Global", "isModEnabled", true, "Globally enable or disable this mod (restart required).");

      // LoadingImage.Image
      LoadingImageBaseColor =
          config.BindInOrder(
              "LoadingImage.Image",
              "baseColor",
              Color.white,
              "The base color to apply to the loading image.");

      LoadingImageBaseColor.SettingChanged += OnLoadingImageConfigChanged;

      // LoadingImage.ScaleLerp
      LoadingImageUseScaleLerp =
          config.BindInOrder(
              "LoadingImage.ScaleLerp",
              "useScaleLerp",
              true,
              "If true, performs a scale lerp animation on the loading image.");

      LoadingImageScaleLerpEndScale =
          config.BindInOrder(
              "LoadingImage.ScaleLerp",
              "lerpEndScale",
              1.05f,
              "Image.scale ending factor for the scale lerp animation.",
              new AcceptableValueRange<float>(0.5f, 1.5f));

      LoadingImageScaleLerpDuration =
          config.BindInOrder(
              "LoadingImage.ScaleLerp",
              "lerpDuration",
              15f,
              "Duration for the scale lerp animation.");

      // LoadingTip.Text
      LoadingTipTextPosition =
          config.BindInOrder(
              "LoadingTip.Text",
              "textPosition",
              new Vector2(0f, 90f),
              "LoadingTip.Text.position value.");

      LoadingTipTextPosition.SettingChanged += OnLoadingTipConfigChanged;

      LoadingTipTextFontSize =
          config.BindInOrder(
              "LoadingTip.Text",
              "textFontSize",
              24,
              "LoadingTip.Text.fontSize value.",
              new AcceptableValueRange<int>(0, 64));

      LoadingTipTextFontSize.SettingChanged += OnLoadingTipConfigChanged;

      LoadingTipTextColor =
          config.BindInOrder(
              "LoadingTip.Text",
              "textColor",
              Color.white,
              "LoadingTip.Text.color value.");

      LoadingTipTextColor.SettingChanged += OnLoadingTipConfigChanged;

      // LoadingScreen.PanelSeparator
      LoadingScreenShowPanelSeparator =
          config.BindInOrder(
              "LoadingScreen.PanelSeparator",
              "showPanelSeparator",
              true,
              "Show the panel separator image on the loading screen.");

      LoadingScreenShowPanelSeparator.SettingChanged += OnPanelSeparatorConfigChanged;

      LoadingScreenPanelSeparatorPosition =
          config.BindInOrder(
              "LoadingScreen.PanelSeparator",
              "panelSeparatorPosition",
              new Vector2(0f, 150f),
              "The position of the panel separator image on the loading screen.");

      LoadingScreenPanelSeparatorPosition.SettingChanged += OnPanelSeparatorConfigChanged;
    }

    static void OnLoadingImageConfigChanged(object sender, EventArgs args) {
      Intermission.SetupLoadingImage();
    }

    static void OnLoadingTipConfigChanged(object sender, EventArgs args) {
      Intermission.SetupTipText();
    }

    static void OnPanelSeparatorConfigChanged(object sender, EventArgs args) {
      Intermission.SetupPanelSeparator();
    }
  }
}
