﻿using System;
using System.Collections.Generic;
using System.Reflection.Emit;

using HarmonyLib;

using static Atlas.PluginConfig;

namespace Atlas {
  [HarmonyPatch(typeof(ZoneSystem))]
  static class ZoneSystemPatch {
    [HarmonyPrefix]
    [HarmonyPatch(nameof(ZoneSystem.GenerateLocationsIfNeeded))]
    static bool GenerateLocationsIfNeededPrefix() {
      if (IgnoreGenerateLocationsIfNeeded.Value) {
        return false;
      }

      return true;
    }

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(ZoneSystem.Load))]
    static IEnumerable<CodeInstruction> LoadTranspiler(IEnumerable<CodeInstruction> instructions) {
      return new CodeMatcher(instructions)
          .MatchForward(
              useEnd: false,
              new CodeMatch(OpCodes.Ldloc_3),
              new CodeMatch(OpCodes.Ldarg_0),
              new CodeMatch(
                  OpCodes.Ldfld, AccessTools.Field(typeof(ZoneSystem), nameof(ZoneSystem.m_locationVersion))))
          .Advance(offset: 1)
          .InsertAndAdvance(
              new CodeInstruction(OpCodes.Ldarg_0),
              Transpilers.EmitDelegate<Func<int, ZoneSystem, int>>(CheckLocationVersionDelegate))
          .InstructionEnumeration();
    }

    static int CheckLocationVersionDelegate(int locationVersion, ZoneSystem zoneSystem) {
      if (IgnoreLocationVersion.Value) {
        PluginLogger.LogInfo(
            $"File locationVersion is: {locationVersion}, overriding to: {zoneSystem.m_locationVersion}");

        return zoneSystem.m_locationVersion;
      }

      return locationVersion;
    }
  }
}
