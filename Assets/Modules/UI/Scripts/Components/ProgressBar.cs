/*AliceVinnik*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image filler;

    [Space()]
    public bool isAnimated = true;
    public float animationSpeed = 0.0005f;
    [Space()]
    public float targetValue = 0f;

    public event Action<float> OnValueChanged;
    public event Action OnComplete;

    private bool _completeFired = false;

    private void Awake()
    {
        if (filler == null)
            Debug.LogWarning($"[ProgressBar] '{name}' has no filler Image assigned.");
    }

    private void Update()
    {
        if (isAnimated)
            UpdateValues();
    }

    public void SetValue(float value)
    {
        targetValue = Mathf.Clamp01(value);
        _completeFired = false;

        if (!isAnimated)
            SnapToTarget();
    }

    public void SetValueInstant(float value)
    {
        targetValue = Mathf.Clamp01(value);
        SnapToTarget();
    }

    public float GetValue() => filler != null ? filler.fillAmount : 0f;
    public float GetTargetValue() => targetValue;

    private void UpdateValues()
    {
        if (filler == null) return;

        var previous = filler.fillAmount;
        filler.fillAmount = Mathf.MoveTowards(filler.fillAmount, targetValue, animationSpeed);

        if (!Mathf.Approximately(filler.fillAmount, previous))
            OnValueChanged?.Invoke(filler.fillAmount);

        if (Mathf.Approximately(filler.fillAmount, targetValue) && !_completeFired)
        {
            _completeFired = true;
            OnComplete?.Invoke();
        }
    }

    private void SnapToTarget()
    {
        if (filler == null) return;

        filler.fillAmount = targetValue;
        OnValueChanged?.Invoke(filler.fillAmount);

        if (!_completeFired)
        {
            _completeFired = true;
            OnComplete?.Invoke();
        }
    }
}