using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonWithPrice : MonoBehaviour
{
    public Image imageButton;
    public TextMeshProUGUI textTitle;
    public TextMeshProUGUI textCost;

    [Space]
    public Color colorActive = Color.white;
    public Color colorDisable = Color.gray;

    [Space]
    public int price;
    public string currency = "coin";

    void Start()
    {
        if (CurrencyManager.Instance != null)
            CurrencyManager.Instance.onValueChanged += OnValueChanged;

        RefreshState();
    }

    void OnDestroy()
    {
        if (CurrencyManager.Instance != null)
            CurrencyManager.Instance.onValueChanged -= OnValueChanged;
    }

    public void Set(int price)
    {
        this.price = price;
        textCost.text = $"{price}";
        RefreshState();
    }

    public void OnValueChanged(string key, int amount)
    {
        if (key == currency)
            RefreshState();
    }

    public void RefreshState()
    {
        var available = CurrencyManager.Instance.IsEnought("coin", price);

        imageButton.color = available ? colorActive : colorDisable;
    }
}
