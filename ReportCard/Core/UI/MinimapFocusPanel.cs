﻿namespace ReportCard;

using UnityEngine;

public sealed class MinimapFocusPanel : MonoBehaviour {
  void Update() {
    Minimap.m_instance.m_wasFocused = true;
  }

  void OnDisable() {
    Minimap.m_instance.m_wasFocused = false;
  }

  void OnEnable() {
    Minimap.m_instance.m_wasFocused = true;
  }
}
