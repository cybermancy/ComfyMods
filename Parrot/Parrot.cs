﻿namespace Parrot;

using System;
using System.Globalization;
using System.Reflection;

using BepInEx;
using BepInEx.Logging;

using BetterZeeRouter;

using HarmonyLib;

using static PluginConfig;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
[BepInDependency(BetterZeeRouter.PluginGuid, BepInDependency.DependencyFlags.HardDependency)]
public sealed class Parrot : BaseUnityPlugin {
  public const string PluginGUID = "redseiko.valheim.parrot";
  public const string PluginName = "Parrot";
  public const string PluginVersion = "1.3.0";

  static ManualLogSource _logger;
  Harmony _harmony;

  void Awake() {
    _logger = Logger;
    BindConfig(Config);

    _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), harmonyInstanceId: PluginGUID);

    ChatMessageHandler.Register(RoutedRpcManager.Instance);
    SayHandler.Register(RoutedRpcManager.Instance);
  }

  void OnDestroy() {
    _harmony?.UnpatchSelf();
  }

  public static void LogInfo(string message) {
    _logger.LogInfo($"[{DateTime.Now.ToString(DateTimeFormatInfo.InvariantInfo)}] {message}");
  }

  public static void LogError(string message) {
    _logger.LogError($"[{DateTime.Now.ToString(DateTimeFormatInfo.InvariantInfo)}] {message}");
  }
}
