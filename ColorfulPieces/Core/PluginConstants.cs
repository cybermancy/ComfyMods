﻿using System;

using UnityEngine;

namespace ColorfulPieces {
  public static class PluginConstants {
    public static readonly int ColorShaderId = Shader.PropertyToID("_Color");
    public static readonly int EmissionColorShaderId = Shader.PropertyToID("_EmissionColor");

    public static readonly int PieceColorHashCode = "PieceColor".GetStableHashCode();
    public static readonly int PieceEmissionColorFactorHashCode = "PieceEmissionColorFactor".GetStableHashCode();
    public static readonly int PieceLastColoredByHashCode = "PieceLastColoredBy".GetStableHashCode();
    public static readonly int PieceLastColoredByHostHashCode = "PieceLastColoredByHost".GetStableHashCode();

    public static readonly Vector3 NoColorVector3 = new(-1f, -1f, -1f);
    public static readonly float NoEmissionColorFactor = -1f;

    public static readonly Vector3 ColorBlackVector3 = new(0.00012345f, 0.00012345f, 0.00012345f);

    public static Vector3 ColorToVector3(Color color) {
      return color == Color.black ? ColorBlackVector3 : new(color.r, color.g, color.b);
    }

    public static Color Vector3ToColor(Vector3 vector3) {
      return vector3 == ColorBlackVector3 ? Color.black : new(vector3.x, vector3.y, vector3.z);
    }
  }
}
