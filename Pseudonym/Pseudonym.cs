﻿using System.Globalization;
using System;
using System.Reflection;

using BepInEx;
using BepInEx.Logging;

using HarmonyLib;

using static Pseudonym.PluginConfig;

namespace Pseudonym {
  [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
  public class Pseudonym : BaseUnityPlugin {
    public const string PluginGuid = "redseiko.valheim.pseudonym";
    public const string PluginName = "Pseudonym";
    public const string PluginVersion = "1.1.0";

    static ManualLogSource _logger;
    Harmony _harmony;

    void Awake() {
      _logger = Logger;
      BindConfig(Config);

      if (IsModEnabled.Value) {
        _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), harmonyInstanceId: PluginGuid);
      }
    }

    void OnDestroy() {
      _harmony?.UnpatchSelf();
    }

    public static void LogInfo(object o) {
      _logger.LogInfo($"[{DateTime.Now.ToString(DateTimeFormatInfo.InvariantInfo)}] {o}");
    }

    public static void LogError(object o) {
      _logger.LogError($"[{DateTime.Now.ToString(DateTimeFormatInfo.InvariantInfo)}] {o}");
    }
  }
}