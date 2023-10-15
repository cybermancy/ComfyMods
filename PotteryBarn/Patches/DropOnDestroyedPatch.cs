﻿using System;
using System.Linq;

using HarmonyLib;

namespace PotteryBarn {
  [HarmonyPatch(typeof(DropOnDestroyed))]
  static class DropOnDestroyedPatch {
    [HarmonyPrefix]
    [HarmonyPatch(nameof(DropOnDestroyed.OnDestroyed))]
    static bool OnDestroyedPrefix(DropOnDestroyed __instance) {
      if (__instance.TryGetComponent(out Piece piece)
          && DvergrPieces.DvergrPrefabs.Keys.Contains(piece.m_description)
          && piece.IsPlacedByPlayer()) {
        return false;
      }

      if (PotteryBarn.IsDropTableDisabled) {
        PotteryBarn.IsDropTableDisabled = false;
        return false;
      }

      return true;
    }
  }
}
