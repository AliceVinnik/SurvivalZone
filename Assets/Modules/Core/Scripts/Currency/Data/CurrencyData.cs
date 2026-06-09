using UnityEngine;

[CreateAssetMenu(fileName = "Currency", menuName = "Scriptable Objects/CurrencyData")]
[System.Serializable]
public class CurrencyData : ScriptableObject
{
    private static string KEY_SAVE = "currency_";

    public string key = "";
    public string name = "";
    public string namePlural = "";
    public Sprite icon;

    [Space]
    public bool save = true;

    public int Get() => Save.GetInt($"{KEY_SAVE}{key}", 0);

    public void Set(int value)
    {
        Save.SetInt($"{KEY_SAVE}{key}", value);
        CurrencyManager.Instance?.OnValueChanged(key, 0);
    }

    public void Add(int value)
    {
        var result = Get() + value;
        Save.SetInt($"{KEY_SAVE}{key}", result);

        CurrencyManager.Instance?.OnValueChanged(key, value);
    }

    public void Remove(int value)
    {
        var result = Get() - value;
        Save.SetInt($"{KEY_SAVE}{key}", result);

        CurrencyManager.Instance?.OnValueChanged(key, -value);
    }

    public bool IsEnought(int value) => value <= Get();
}
