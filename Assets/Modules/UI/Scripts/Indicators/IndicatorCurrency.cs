using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class IndicatorCurrency : MonoBehaviour
{
    [Header("Components")]
    public Image icon;
    public TextMeshProUGUI text;

    [Header("Values")]
    public CurrencyData type;

    public Action onValueUpdated;
    public Action<int> onValueChangeBy;

    void Start()
    {
        if (CurrencyManager.Instance != null)
            CurrencyManager.Instance.onValueChanged += OnValueChanged;

        Load();
    }

    void OnDestroy()
    {
        if (CurrencyManager.Instance != null)
            CurrencyManager.Instance.onValueChanged -= OnValueChanged;
    }

    public void Load()
    {
        icon.sprite = type.icon;
        UpdateValue();
    }

    public void UpdateValue()
    {
        text.text = type.Get().ToString();
        onValueUpdated?.Invoke();
    }

    public void OnValueChanged(string key, int amount)
    {
        if (type.key == key)
        {
            UpdateValue();
            onValueChangeBy?.Invoke(amount);
        }
    }
}
