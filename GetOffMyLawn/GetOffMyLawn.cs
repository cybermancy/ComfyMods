﻿using System.Reflection;

using BepInEx;
using BepInEx.Logging;

using HarmonyLib;

using static GetOffMyLawn.PluginConfig;

namespace GetOffMyLawn {
  [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
  public class GetOffMyLawn : BaseUnityPlugin {
    public const string PluginGUID = "redseiko.valheim.getoffmylawn";
    public const string PluginName = "GetOffMyLawn";
    public const string PluginVersion = "1.6.0";

    public static ManualLogSource PluginLogger { get; private set; }
    Harmony _harmony;

    void Awake() {
      PluginLogger = Logger;
      BindConfig(Config);

      _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), harmonyInstanceId: PluginGUID);
    }

    void OnDestroy() {
      _harmony?.UnpatchSelf();
    }

    public static readonly int HealthHashCode = "health".GetStableHashCode();
  }
}
