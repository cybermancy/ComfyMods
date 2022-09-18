﻿using System;
using System.Collections.Generic;
using System.Linq;

using BepInEx.Configuration;

using ComfyLib;

using UnityEngine;

namespace Chatter {
  public class PluginConfig {
    public static ConfigFile Config { get; private set; }

    public static ConfigEntry<bool> IsModEnabled { get; private set; }

    // Behaviour
    public static ConfigEntry<int> HideChatPanelDelay { get; private set; }
    public static ConfigEntry<float> HideChatPanelAlpha { get; private set; }

    // Content
    public static ConfigEntry<bool> ShowMessageHudCenterMessages { get; private set; }
    public static ConfigEntry<bool> ShowChatPanelMessageDividers { get; private set; }

    // Filters
    public static StringListConfigEntry ShoutTextFilterList { get; private set; }

    public static ConfigEntry<string> MessageHudTextFilter { get; private set; }
    public static StringListConfigEntry MessageHudTextFilterList { get; private set; }

    // Layout
    public static ConfigEntry<Chatter.MessageLayoutType> ChatMessageLayout { get; private set; }
    public static ConfigEntry<bool> ChatMessageShowTimestamp { get; private set; }

    // Style
    public static ConfigEntry<string> ChatMessageFont { get; private set; }
    public static ConfigEntry<int> ChatMessageFontSize { get; private set; }

    public static ConfigEntry<Color> ChatPanelBackgroundColor { get; private set; }
    public static ConfigEntry<Vector2> ChatPanelRectMaskSoftness { get; private set; }

    // Spacing
    public static ConfigEntry<float> ChatPanelContentSpacing { get; private set; }
    public static ConfigEntry<float> ChatPanelContentBodySpacing { get; private set; }
    public static ConfigEntry<float> ChatPanelContentSingleRowSpacing { get; private set; }

    // Panel
    public static ConfigEntry<Vector2> ChatPanelPosition { get; private set; }
    public static ConfigEntry<Vector2> ChatPanelSize { get; private set; }
    public static ConfigEntry<float> ChatContentWidthOffset { get; private set; }

    // Scrolling
    public static ConfigEntry<KeyboardShortcut> ScrollContentUpShortcut { get; private set; }
    public static ConfigEntry<KeyboardShortcut> ScrollContentDownShortcut { get; private set; }
    public static ConfigEntry<float> ScrollContentOffsetInterval { get; private set; }

    // Colors
    public static ConfigEntry<Color> ChatMessageTextDefaultColor { get; private set; }
    public static ConfigEntry<Color> ChatMessageTextSayColor { get; private set; }
    public static ConfigEntry<Color> ChatMessageTextShoutColor { get; private set; }
    public static ConfigEntry<Color> ChatMessageTextWhisperColor { get; private set; }
    public static ConfigEntry<Color> ChatMessageTextPingColor { get; private set; }
    public static ConfigEntry<Color> ChatMessageTextMessageHudColor { get; private set; }
    public static ConfigEntry<Color> ChatMessageTimestampColor { get; private set; }

    // Username
    public static ConfigEntry<string> ChatMessageUsernamePrefix { get; private set; }
    public static ConfigEntry<string> ChatMessageUsernamePostfix { get; private set; }

    public static void BindConfig(ConfigFile config) {
      Config = config;

      IsModEnabled ??= config.Bind("_Global", "isModEnabled", true, "Globally enable or disable this mod.");

      // Behaviour
      HideChatPanelDelay =
          config.Bind(
              "Behaviour",
              "hideChatPanelDelay",
              defaultValue: 10,
              new ConfigDescription(
                  "Delay (in seconds) before hiding the ChatPanel.", new AcceptableValueRange<int>(1, 180)));

      HideChatPanelAlpha ??=
          config.Bind(
              "Behaviour",
              "hideChatPanelAlpha",
              defaultValue: 0.2f,
              new ConfigDescription(
                  "Color alpha (in %) for the ChatPanel when hidden.", new AcceptableValueRange<float>(0f, 1f)));

      // Filters
      ShoutTextFilterList = new(config, "Filters", "shoutTextFilterList", "Filter list for Shout message texts.");

      MessageHudTextFilterList =
          new(config, "Filters", "messageHudTextFilterList", "Filter list for MessageHud.Center message texts.");
      MessageHudTextFilter = MessageHudTextFilterList.ConfigEntry;

      // Content
      ShowMessageHudCenterMessages =
          config.Bind(
              "Content",
              "showMessageHudCenterMessages",
              defaultValue: true,
              "Show messages from the MessageHud that display in the top-center (usually boss messages).");

      ShowChatPanelMessageDividers =
          config.Bind(
              "Content",
              "showChatPanelMessageDividers",
              defaultValue: true,
              "Show the horizontal dividers between groups of messages.");

      // Layout
      ChatMessageLayout ??=
          config.Bind(
              "Layout",
              "chatMessageLayout",
              Chatter.MessageLayoutType.WithHeaderRow,
              "Determines which layout to use when displaying a chat message.");

      ChatMessageShowTimestamp ??=
          config.Bind(
              "Layout",
              "chatMessageShowTimestamp",
              defaultValue: true,
              "Show a timestamp for each group of chat messages (except system/default).");

      // Style
      ChatPanelBackgroundColor ??=
          config.Bind(
              "Style",
              "chatPanelBackgroundColor",
              (Color) new Color32(0, 0, 0, 128),
              "The background color for the ChatPanel.");

      ChatPanelRectMaskSoftness ??=
          config.Bind(
              "Style", "chatPanelRectMaskSoftness", new Vector2(20f, 20f), "Softness of the ChatPanel's RectMask2D.");

      // Spacing
      ChatPanelContentSpacing =
          config.BindInOrder(
              "Spacing",
              "chatPanelContentSpacing",
              defaultValue: 10f,
              "Spacing (px) between `Content.Row` when using 'WithRowHeader` layout.",
              new AcceptableValueRange<float>(-100, 100));

      ChatPanelContentBodySpacing =
          config.BindInOrder(
              "Spacing",
              "chatPanelContentBodySpacing",
              defaultValue: 5f,
              "Spacing (px) between `Content.Row.Body` when using 'WithRowHeader' layout.",
              new AcceptableValueRange<float>(-100, 100));

      ChatPanelContentSingleRowSpacing =
          config.BindInOrder(
              "Spacing",
              "chatPanelContentSingleRowSpacing",
              defaultValue: 10f,
              "Spacing (in pixels) to use between rows when using 'SingleRow' layout.",
              new AcceptableValueRange<float>(-100, 100));

      // Username
      ChatMessageUsernamePrefix =
          config.BindInOrder(
              "Username",
              "chatMessageUsernamePrefix",
              defaultValue: string.Empty,
              "If non-empty, adds the text to the beginning of a ChatMesage username.");

      ChatMessageUsernamePostfix =
          config.BindInOrder(
              "Username",
              "chatMessageUsernamePostfix",
              defaultValue: string.Empty,
              "If non-empty, adds the text to the end of a ChatMessage username.");

      // Scrolling
      ScrollContentUpShortcut =
          config.BindInOrder(
              "Scrolling",
              "scrollContentUpShortcut",
              new KeyboardShortcut(KeyCode.PageUp),
              "Keyboard shortcut to scroll the ChatPanel content up.");

      ScrollContentDownShortcut =
          config.BindInOrder(
              "Scrolling",
              "scrollContentDownShortcut",
              new KeyboardShortcut(KeyCode.PageDown),
              "Keyboard shortcut to scroll the ChatPanel content down.");

      ScrollContentOffsetInterval =
          config.BindInOrder(
              "Scrolling",
              "scrollContentOffsetInterval",
              defaultValue: 200f,
              "Interval (in pixels) to scroll the ChatPanel content up/down.");

      // Colors
      ChatMessageTextDefaultColor ??=
          config.Bind(
              "Colors",
              "chatMessageTextDefaultColor",
              Color.white,
              new ConfigDescription(
                  "Color for default/system chat messages.",
                  acceptableValues: null,
                  new ConfigurationManagerAttributes { Order = 6 }));

      ChatMessageTextSayColor ??=
          config.Bind(
              "Colors",
              "chatMessageTextSayColor",
              Color.white,
              new ConfigDescription(
                  "Color for 'normal/say' chat messages.",
                  acceptableValues: null,
                  new ConfigurationManagerAttributes { Order = 5 }));

      ChatMessageTextShoutColor ??=
          config.Bind(
              "Colors",
              "chatMessageTextShoutColor",
              Color.yellow,
              new ConfigDescription(
                  "Color for 'shouting' chat messages.",
                  acceptableValues: null,
                  new ConfigurationManagerAttributes { Order = 4 }));

      ChatMessageTextWhisperColor ??=
          config.Bind(
              "Colors",
              "chatMessageTextWhisperColor",
              new Color(0.502f, 0f, 0.502f, 1f), // <color=purple> #800080
              new ConfigDescription(
                  "Color for 'whisper' chat messages.",
                  acceptableValues: null,
                  new ConfigurationManagerAttributes { Order = 3 }));

      ChatMessageTextPingColor ??=
          config.Bind(
              "Colors",
              "chatMessageTextPingColor",
              Color.cyan,
              new ConfigDescription(
                  "Color for 'ping' chat messages.",
                  acceptableValues: null,
                  new ConfigurationManagerAttributes { Order = 2 }));

      ChatMessageTextMessageHudColor ??=
          config.Bind(
              "Colors",
              "chatMessageTextMessageHudColor",
              new Color(1f, 0.647f, 0f, 1.0f), // <color=orange> #FFA500
              new ConfigDescription(
                  "Color for 'MessageHud' chat messages.",
                  acceptableValues: null,
                  new ConfigurationManagerAttributes { Order = 1 }));

      ChatMessageTimestampColor ??=
          config.Bind(
              "Colors",
              "chatMessageTimestampColor",
              (Color) new Color32(244, 246, 247, 255),
              new ConfigDescription(
                  "Color for any timestamp shown in the chat messages.",
                  acceptableValues: null,
                  new ConfigurationManagerAttributes { Order = 0 }));
    }

    public static float ContentRowSpacing {
      get {
        return ChatMessageLayout.Value switch {
          Chatter.MessageLayoutType.SingleRow => ChatPanelContentSingleRowSpacing.Value,
          _ => ChatPanelContentSpacing.Value,
        };
      }
    }

    public static float ContentRowBodySpacing {
      get {
        return ChatMessageLayout.Value switch {
          Chatter.MessageLayoutType.SingleRow => ChatPanelContentSingleRowSpacing.Value,
          _ => ChatPanelContentBodySpacing.Value,
        };
      }
    }

    static readonly Dictionary<string, Font> _fontCache = new();

    public static Font MessageFont {
      get {
        if (!_fontCache.TryGetValue(ChatMessageFont.Value, out Font font)) {
          font = Font.CreateDynamicFontFromOSFont(ChatMessageFont.Value, ChatMessageFontSize.Value);
          _fontCache[font.name] = font;
        }

        return font;
      }
    }

    public static void BindChatMessageFont(Font defaultFont) {
      foreach (Font font in Resources.FindObjectsOfTypeAll<Font>()) {
        _fontCache[font.name] = font;
      }

      string[] fontNames =
          _fontCache.Keys.OrderBy(f => f).Concat(Font.GetOSInstalledFontNames().OrderBy(f => f)).ToArray();

      ChatMessageFont ??=
          Config.Bind(
              "Style",
              "chatMessageFont",
              defaultFont.name,
              new ConfigDescription("The font to use for chat messages.", new AcceptableValueList<string>(fontNames)));

      ChatMessageFontSize ??=
          Config.Bind(
              "Style",
              "chatMessageFontSize",
              defaultFont.fontSize,
              new ConfigDescription("The font size to use for chat messages.", new AcceptableValueRange<int>(8, 64)));
    }

    public static void BindChatPanelSize(RectTransform chatWindowRectTransform) {
      ChatPanelPosition ??=
          Config.Bind(
              "Panel",
              "chatPanelPosition",
              chatWindowRectTransform.anchoredPosition,
              "The Vector2 position of the ChatPanel.");

      ChatPanelSize ??=
          Config.Bind(
              "Panel",
              "chatPanelSize",
              chatWindowRectTransform.sizeDelta - new Vector2(10f, 0f),
              "The size (width, height) of the ChatPanel.");

      ChatContentWidthOffset ??=
          Config.Bind(
              "Panel",
              "chatContentWidthOffset",
              -50f,
              new ConfigDescription(
                  "Offsets the width of a row in the ChatPanel content.",
                  new AcceptableValueRange<float>(-400, 400)));
    }
  }


  public sealed class StringListConfigEntry {
    public ConfigEntry<string> ConfigEntry { get; }

    public List<string> Values {
      get => ConfigEntry.Value.Split(_valuesSeparator).ToList();
    }

    public event EventHandler<List<string>> ValuesChangedEvent;

    public StringListConfigEntry(ConfigFile config, string section, string key, string description) {
      ConfigEntry = config.Bind(section, key, string.Empty, CreateConfigDescription(description));
    }

    ConfigDescription CreateConfigDescription(string description) {
      return new(
          description,
          acceptableValues: null,
          new ConfigurationManagerAttributes {
            CustomDrawer = Drawer,
            HideDefaultButton = true,
            HideSettingName = true
          });
    }

    readonly Lazy<GUIStyle> _labelStyle =
        new(() =>
            new(GUI.skin.label) {
              padding = new(left: 0, right: 5, top: 5, bottom: 5)
            });

    readonly Lazy<GUIStyle> _horizontalStyle =
        new(() =>
            new() {
              padding = new(left: 10, right: 10, top: 0, bottom: 0)
            });

    readonly Lazy<GUIStyle> _buttonStyle =
        new(() =>
            new(GUI.skin.button) {
              padding = new(left: 10, right: 10, top: 5, bottom: 5)
            });

    readonly Lazy<GUIStyle> _textFieldStyle =
        new(() =>
            new(GUI.skin.textField) {
              padding = new(left: 5, right: 5, top: 5, bottom: 5),
              wordWrap = false
            });

    static readonly char[] _valuesSeparator = new char[] { '\t' };

    readonly List<string> _valuesCache = new();

    void Drawer(ConfigEntryBase entry) {
      GUILayout.BeginVertical();

      GUILayout.BeginHorizontal(_horizontalStyle.Value);
      GUILayout.Label(entry.Definition.Key, GUILayout.ExpandWidth(false));
      GUILayout.FlexibleSpace();
      GUILayout.EndHorizontal();

      _valuesCache.Clear();

      if (!string.IsNullOrEmpty(entry.BoxedValue.ToString())) {
        _valuesCache.AddRange(entry.BoxedValue.ToString().Split(_valuesSeparator));
      }

      int deleteIndex = -1;
      bool valuesChanged = false;

      if (!string.IsNullOrEmpty(entry.BoxedValue.ToString())) {
        for (int i = 0; i < _valuesCache.Count; i++) {
          GUILayout.BeginHorizontal(_horizontalStyle.Value);
          GUILayout.Label($"#{i:D2}", _labelStyle.Value, GUILayout.ExpandWidth(false));
          GUILayout.Space(pixels: 5f);

          string name = $"{entry.Definition.Key}.{i}";
          string value = _valuesCache[i];

          if (ShowTextField(name, ref value)) {
            if (_valuesCache[i] != value) {
              ZLog.Log($"Applying value for {name}: {value}");
              _valuesCache[i] = value;
              valuesChanged = true;
            }
          }

          if (Event.current.type == EventType.MouseDown) {
            Rect rect = GUILayoutUtility.GetLastRect();

            if (!rect.Contains(Event.current.mousePosition) && GUI.GetNameOfFocusedControl() == name) {
              ZLog.Log($"Mouse clicked outside of {name} rect: {rect}");
            }
          }

          GUILayout.Space(pixels: 10f);

          if (GUILayout.Button("Delete", _buttonStyle.Value, GUILayout.ExpandWidth(false))) {
            deleteIndex = i;
            ZLog.Log($"Delete button hit: deleteIndex set to {deleteIndex}");
          }

          GUILayout.EndHorizontal();
        }
      }

      GUILayout.BeginHorizontal(_horizontalStyle.Value);

      if (GUILayout.Button("Add new entry", _buttonStyle.Value, GUILayout.ExpandWidth(false))) {
        ZLog.Log($"Adding new empty default value.");
        _valuesCache.Add("change me!");
        valuesChanged = true;
      }

      GUILayout.FlexibleSpace();
      GUILayout.EndHorizontal();
      GUILayout.EndVertical();

      if (deleteIndex >= 0 && deleteIndex < _valuesCache.Count) {
        ZLog.Log($"Removing value at {deleteIndex}: {_valuesCache[deleteIndex]}");
        _valuesCache.RemoveAt(deleteIndex);
        valuesChanged = true;
      }

      if (valuesChanged) {
        ZLog.Log($"Values have changed, updating ConfigEntry value from:\n{entry.BoxedValue}");
        entry.BoxedValue = string.Join("\t", _valuesCache);
        ZLog.Log($"To:\n{entry.BoxedValue}");
        ValuesChangedEvent?.Invoke(this, new(Values));
      }
    }

    string _lastFocusedControl;
    string _editingValue;

    bool ShowTextField(string name, ref string value) {
      GUI.SetNextControlName(name);

      if (GUI.GetNameOfFocusedControl() != name) {
        if (_lastFocusedControl == name) {
          //ZLog.Log($"Lost focus, applying value.");
          value = _editingValue;
          GUILayout.TextField(value, _textFieldStyle.Value, GUILayout.ExpandWidth(true));
          return true;
        }

        GUILayout.TextField(value, _textFieldStyle.Value, GUILayout.ExpandWidth(true));
        return false;
      }

      if (_lastFocusedControl != name) {
        _lastFocusedControl = name;
        _editingValue = value;
      }

      bool applyingValue = false;

      if (Event.current.isKey) {
        switch (Event.current.keyCode) {
          case KeyCode.Return:
          case KeyCode.KeypadEnter:
          case KeyCode.Escape:
            value = _editingValue;
            applyingValue = true;
            Event.current.Use();
            break;
        }
      }

      _editingValue = GUILayout.TextField(_editingValue, _textFieldStyle.Value, GUILayout.ExpandWidth(true));

      return applyingValue;
    }
  }

  internal sealed class ConfigurationManagerAttributes {
    public System.Action<ConfigEntryBase> CustomDrawer;

    public bool? HideDefaultButton;
    public bool? HideSettingName;

    public int? Order;
  }
}