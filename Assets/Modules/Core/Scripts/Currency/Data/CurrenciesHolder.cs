using UnityEngine;
using System.Linq;

[System.Serializable]
public class CurrenciesHolder
{
    public CurrencyData[] data;

    public void Load()
    {
        data = Resources.LoadAll<ScriptableObject>("Currencies").OfType<CurrencyData>().ToArray();

        Debug.Log($"[CurrenciesHolder] Loaded: {data.Length} currencies.");
    }

    public void Add(string key, int amount)
    {
        foreach (var currency in data)
        {
            if (currency.key == key)
            {
                currency.Add(amount);
                return;
            }
        }
    }

    public void Add(CurrencyData data, int amount) => Add(data.key, amount);

    public void Set(string key, int amount)
    {
        foreach (var currency in data)
        {
            if (currency.key == key)
            {
                currency.Set(amount);
                return;
            }
        }
    }

    public void Set(CurrencyData data, int amount) => Set(data.key, amount);

    public void Remove(string key, int amount)
    {
        foreach (var currency in data)
        {
            if (currency.key == key)
            {
                currency.Remove(amount);
                return;
            }
        }
    }

    public void Remove(CurrencyData data, int amount) => Remove(data.key, amount);

    public bool IsEnought(string key, int amount)
    {
        foreach (var currency in data)
            if (currency.key == key)
                return currency.IsEnought(amount);

        return false;
    }

    public bool IsEnought(CurrencyData data, int amount) => IsEnought(data.key, amount);
}
