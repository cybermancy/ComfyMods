﻿using System;
using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;

namespace ComfyLib {
  public class PanelResizer :
      MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
    CanvasGroup _canvasGroup;
    float _targetAlpha = 0f;

    Vector2 _lastMousePosition;
    Coroutine _lerpAlphaCoroutine;

    public RectTransform TargetRectTransform;
    public event EventHandler<Vector2> OnPanelEndResize;

    void Awake() {
      _canvasGroup = GetComponent<CanvasGroup>();
    }

    void SetCanvasGroupAlpha(float alpha) {
      if (_lerpAlphaCoroutine != null) {
        StopCoroutine(_lerpAlphaCoroutine);
        _lerpAlphaCoroutine = null;
      }

      if (_canvasGroup.alpha == alpha) {
        return;
      }

      _lerpAlphaCoroutine = StartCoroutine(LerpCanvasGroupAlpha(alpha, 0.25f));
    }

    IEnumerator LerpCanvasGroupAlpha(float targetAlpha, float lerpDuration) {
      float timeElapsed = 0f;
      float sourceAlpha = _canvasGroup.alpha;

      while (timeElapsed < lerpDuration) {
        float t = timeElapsed / lerpDuration;
        t = t * t * (3f - (2f * t));

        _canvasGroup.SetAlpha(Mathf.Lerp(sourceAlpha, targetAlpha, t));
        timeElapsed += Time.deltaTime;

        yield return null;
      }

      _canvasGroup.SetAlpha(targetAlpha);
    }

    public void OnPointerEnter(PointerEventData eventData) {
      _targetAlpha = 1f;
      SetCanvasGroupAlpha(_targetAlpha);
    }

    public void OnPointerExit(PointerEventData eventData) {
      _targetAlpha = 0f;

      if (!eventData.dragging) {
        SetCanvasGroupAlpha(_targetAlpha);
      }
    }

    Vector2 _originalPivot;

    public void OnBeginDrag(PointerEventData eventData) {
      SetCanvasGroupAlpha(1f);
      _lastMousePosition = eventData.position;
      _originalPivot = TargetRectTransform.pivot;
      SetPivot(TargetRectTransform, new(0f, 1f));
    }

    public void OnDrag(PointerEventData eventData) {
      Vector2 difference = _lastMousePosition - eventData.position;

      if (TargetRectTransform) {
        TargetRectTransform.sizeDelta += new Vector2(-1f * difference.x, difference.y);
      }

      SetCanvasGroupAlpha(1f);
      _lastMousePosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
      SetCanvasGroupAlpha(_targetAlpha);
      OnPanelEndResize?.Invoke(this, TargetRectTransform.sizeDelta);
      SetPivot(TargetRectTransform, _originalPivot);
    }

    void SetPivot(RectTransform rectTransform, Vector2 pivot) {
      Vector3 deltaPosition = rectTransform.pivot - pivot;
      deltaPosition.Scale(rectTransform.rect.size);
      deltaPosition.Scale(rectTransform.localScale);
      deltaPosition = rectTransform.rotation * deltaPosition;
      rectTransform.pivot = pivot;
      rectTransform.localPosition -= deltaPosition;
    }
  }
}
