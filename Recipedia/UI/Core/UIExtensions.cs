﻿using System;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace ComfyLib {
  public static class CanvasGroupExtensions {
    public static CanvasGroup SetAlpha(this CanvasGroup canvasGroup, float alpha) {
      canvasGroup.alpha = alpha;
      return canvasGroup;
    }

    public static CanvasGroup SetBlocksRaycasts(this CanvasGroup canvasGroup, bool blocksRaycasts) {
      canvasGroup.blocksRaycasts = blocksRaycasts;
      return canvasGroup;
    }
  }

  public static class ContentSizeFitterExtensions {
    public static T SetHorizontalFit<T>(this T fitter, ContentSizeFitter.FitMode fitMode) where T : ContentSizeFitter {
      fitter.horizontalFit = fitMode;
      return fitter;
    }

    public static T SetVerticalFit<T>(this T fitter, ContentSizeFitter.FitMode fitMode) where T : ContentSizeFitter {
      fitter.verticalFit = fitMode;
      return fitter;
    }
  }

  public static class LayoutGroupExtensions {
    public static T SetChildControl<T>(
        this T layoutGroup, bool? width = null, bool? height = null) where T : HorizontalOrVerticalLayoutGroup {
      if (!width.HasValue && !height.HasValue) {
        throw new ArgumentException("Value for width or height must be provided.");
      }

      if (width.HasValue) {
        layoutGroup.childControlWidth = width.Value;
      }

      if (height.HasValue) {
        layoutGroup.childControlHeight = height.Value;
      }

      return layoutGroup;
    }

    public static T SetChildForceExpand<T>(
        this T layoutGroup, bool? width = null, bool? height = null) where T : HorizontalOrVerticalLayoutGroup {
      if (!width.HasValue && !height.HasValue) {
        throw new ArgumentException("Value for width or height must be provided.");
      }

      if (width.HasValue) {
        layoutGroup.childForceExpandWidth = width.Value;
      }

      if (height.HasValue) {
        layoutGroup.childForceExpandHeight = height.Value;
      }

      return layoutGroup;
    }

    public static T SetChildAlignment<T>(this T layoutGroup, TextAnchor alignment) where T : LayoutGroup {
      layoutGroup.childAlignment = alignment;
      return layoutGroup;
    }

    public static T SetPadding<T>(
        this T layoutGroup,
        int? left = null,
        int? right = null,
        int? top = null,
        int? bottom = null)
        where T : LayoutGroup {
      if (!left.HasValue && !right.HasValue && !top.HasValue && !bottom.HasValue) {
        throw new ArgumentException("Value for left, right, top or bottom must be provided.");
      }

      if (left.HasValue) {
        layoutGroup.padding.left = left.Value;
      }

      if (right.HasValue) {
        layoutGroup.padding.right = right.Value;
      }

      if (top.HasValue) {
        layoutGroup.padding.top = top.Value;
      }

      if (bottom.HasValue) {
        layoutGroup.padding.bottom = bottom.Value;
      }

      return layoutGroup;
    }

    public static T SetSpacing<T>(this T layoutGroup, float spacing) where T : HorizontalOrVerticalLayoutGroup {
      layoutGroup.spacing = spacing;
      return layoutGroup;
    }
  }

  public static class ImageExtensions {
    public static T SetColor<T>(this T image, Color color) where T : Graphic {
      image.color = color;
      return image;
    }

    public static T SetFillAmount<T>(this T image, float amount) where T : Image {
      image.fillAmount = amount;
      return image;
    }

    public static T SetFillCenter<T>(this T image, bool fillCenter) where T : Image {
      image.fillCenter = fillCenter;
      return image;
    }

    public static T SetFillMethod<T>(this T image, Image.FillMethod fillMethod) where T : Image {
      image.fillMethod = fillMethod;
      return image;
    }

    public static T SetFillOrigin<T>(this T image, Image.OriginHorizontal origin) where T : Image {
      image.fillOrigin = (int) origin;
      return image;
    }

    public static T SetFillOrigin<T>(this T image, Image.OriginVertical origin) where T : Image {
      image.fillOrigin = (int) origin;
      return image;
    }

    public static T SetMaskable<T>(this T image, bool maskable) where T : MaskableGraphic {
      image.maskable = maskable;
      return image;
    }

    public static T SetMaterial<T>(this T image, Material material) where T : Image {
      image.material = material;
      return image;
    }

    public static T SetPixelsPerUnitMultiplier<T>(this T image, float pixelsPerUnitMultiplier) where T : Image {
      image.pixelsPerUnitMultiplier = pixelsPerUnitMultiplier;
      return image;
    }

    public static T SetPreserveAspect<T>(this T image, bool preserveAspect) where T : Image {
      image.preserveAspect = preserveAspect;
      return image;
    }

    public static T SetRaycastTarget<T>(this T image, bool raycastTarget) where T : Graphic {
      image.raycastTarget = raycastTarget;
      return image;
    }

    public static T SetSprite<T>(this T image, Sprite sprite) where T : Image {
      image.sprite = sprite;
      return image;
    }

    public static T SetType<T>(this T image, Image.Type type) where T : Image {
      image.type = type;
      return image;
    }
  }

  public static class LayoutElementExtensions {
    public static T SetPreferred<T>(
        this T layoutElement, float? width = null, float? height = null) where T : LayoutElement {
      if (!width.HasValue && !height.HasValue) {
        throw new ArgumentException("Value for width or height must be provided.");
      }

      if (width.HasValue) {
        layoutElement.preferredWidth = width.Value;
      }

      if (height.HasValue) {
        layoutElement.preferredHeight = height.Value;
      }

      return layoutElement;
    }

    public static T SetFlexible<T>(
        this T layoutElement, float? width = null, float? height = null) where T : LayoutElement {
      if (!width.HasValue && !height.HasValue) {
        throw new ArgumentException("Value for width or height must be provided.");
      }

      if (width.HasValue) {
        layoutElement.flexibleWidth = width.Value;
      }

      if (height.HasValue) {
        layoutElement.flexibleHeight = height.Value;
      }

      return layoutElement;
    }

    public static T SetMinimum<T>(
        this T layoutElement, float? width = null, float? height = null) where T : LayoutElement {
      if (!width.HasValue && !height.HasValue) {
        throw new ArgumentException("Value for width or height must be provided.");
      }

      if (width.HasValue) {
        layoutElement.minWidth = width.Value;
      }

      if (height.HasValue) {
        layoutElement.minHeight = height.Value;
      }

      return layoutElement;
    }

    public static T SetIgnoreLayout<T>(this T layoutElement, bool ignoreLayout) where T : LayoutElement {
      layoutElement.ignoreLayout = ignoreLayout;
      return layoutElement;
    }
  }

  public static class MaskExtensions {
    public static T SetShowMaskGraphic<T>(this T mask, bool showMaskGraphic) where T : Mask {
      mask.showMaskGraphic = showMaskGraphic;
      return mask;
    }
  }

  public static class RectMask2DExtensions {
    public static T SetSoftness<T>(this T rectMask2d, Vector2Int softness) where T : RectMask2D {
      rectMask2d.softness = softness;
      return rectMask2d;
    }
  }

  public static class RectTransformExtensions {
    public static RectTransform SetAnchorMin(this RectTransform rectTransform, Vector2 anchorMin) {
      rectTransform.anchorMin = anchorMin;
      return rectTransform;
    }

    public static RectTransform SetAnchorMax(this RectTransform rectTransform, Vector2 anchorMax) {
      rectTransform.anchorMax = anchorMax;
      return rectTransform;
    }

    public static RectTransform SetAnchoredPosition(this RectTransform rectTransform, Vector2 position) {
      rectTransform.anchoredPosition = position;
      return rectTransform;
    }

    public static RectTransform SetPivot(this RectTransform rectTransform, Vector2 pivot) {
      rectTransform.pivot = pivot;
      return rectTransform;
    }

    public static RectTransform SetSizeDelta(this RectTransform rectTransform, Vector2 sizeDelta) {
      rectTransform.sizeDelta = sizeDelta;
      return rectTransform;
    }
  }

  public static class ScrollbarExtensions {
    public static T SetDirection<T>(this T scrollbar, Scrollbar.Direction direction) where T : Scrollbar {
      scrollbar.direction = direction;
      return scrollbar;
    }

    public static T SetHandleRect<T>(this T scrollbar, RectTransform handleRect) where T : Scrollbar {
      scrollbar.handleRect = handleRect;
      return scrollbar;
    }
  }

  public static class SelectableExtensions {
    public static T SetColors<T>(this T selectable, ColorBlock colors) where T : Selectable {
      selectable.colors = colors;
      return selectable;
    }

    public static T SetImage<T>(this T selectable, Image image) where T : Selectable {
      selectable.image = image;
      return selectable;
    }

    public static T SetInteractable<T>(this T selectable, bool interactable) where T : Selectable {
      selectable.interactable = interactable;
      return selectable;
    }

    public static T SetSpriteState<T>(this T selectable, SpriteState spriteState) where T : Selectable {
      selectable.spriteState = spriteState;
      return selectable;
    }

    public static T SetTargetGraphic<T>(this T selectable, Graphic graphic) where T : Selectable {
      selectable.targetGraphic = graphic;
      return selectable;
    }

    public static T SetTransition<T>(this T selectable, Selectable.Transition transition) where T : Selectable {
      selectable.transition = transition;
      return selectable;
    }
  }

  public static class ScrollRectExtensions {
    public static T SetScrollSensitivity<T>(this T scrollRect, float sensitivity) where T : ScrollRect {
      scrollRect.scrollSensitivity = sensitivity;
      return scrollRect;
    }

    public static T SetVerticalScrollbar<T>(this T scrollRect, Scrollbar verticalScrollbar) where T : ScrollRect {
      scrollRect.verticalScrollbar = verticalScrollbar;
      return scrollRect;
    }

    public static T SetVerticalScrollPosition<T>(this T scrollRect, float position) where T : ScrollRect {
      scrollRect.verticalNormalizedPosition = position;
      return scrollRect;
    }

    public static T SetViewport<T>(this T scrollRect, RectTransform viewport) where T : ScrollRect {
      scrollRect.viewport = viewport;
      return scrollRect;
    }

    public static T SetContent<T>(this T scrollRect, RectTransform content) where T : ScrollRect {
      scrollRect.content = content;
      return scrollRect;
    }

    public static T SetHorizontal<T>(this T scrollRect, bool horizontal) where T : ScrollRect {
      scrollRect.horizontal = horizontal;
      return scrollRect;
    }

    public static T SetVertical<T>(this T scrollRect, bool vertical) where T : ScrollRect {
      scrollRect.vertical = vertical;
      return scrollRect;
    }

    public static T SetMovementType<T>(this T scrollRect, ScrollRect.MovementType movementType) where T : ScrollRect {
      scrollRect.movementType = movementType;
      return scrollRect;
    }
  }

  public static class TextMeshProExtensions {
    public static T SetAlignment<T>(this T tmpText, TextAlignmentOptions alignment) where T : TMP_Text {
      tmpText.alignment = alignment;
      return tmpText;
    }

    public static T SetTextWrappingMode<T>(this T tmpText, TextWrappingModes textWrappingMode) where T : TMP_Text {
      tmpText.textWrappingMode = textWrappingMode;
      return tmpText;
    }

    public static T SetFont<T>(this T tmpText, TMP_FontAsset font) where T : TMP_Text {
      tmpText.font = font;
      return tmpText;
    }

    public static T SetFontSize<T>(this T tmpText, float fontSize) where T : TMP_Text {
      tmpText.fontSize = fontSize;
      return tmpText;
    }

    public static T SetFontMaterial<T>(this T tmpText, Material fontMaterial) where T : TMP_Text {
      tmpText.fontMaterial = fontMaterial;
      return tmpText;
    }

    public static T SetMargin<T>(this T tmpText, Vector4 margin) where T : TMP_Text {
      tmpText.margin = margin;
      return tmpText;
    }

    public static T SetOverflowMode<T>(this T tmpText, TextOverflowModes overflowMode) where T : TMP_Text {
      tmpText.overflowMode = overflowMode;
      return tmpText;
    }

    public static T SetRichText<T>(this T tmpText, bool richText) where T : TMP_Text {
      tmpText.richText = richText;
      return tmpText;
    }
  }

  public static class Texture2DExtensions {
    public static Texture2D SetWrapMode(this Texture2D texture, TextureWrapMode wrapMode) {
      texture.wrapMode = wrapMode;
      return texture;
    }

    public static Texture2D SetFilterMode(this Texture2D texture, FilterMode filterMode) {
      texture.filterMode = filterMode;
      return texture;
    }
  }
}
