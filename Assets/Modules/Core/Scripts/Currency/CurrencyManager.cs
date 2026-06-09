/*AliceVinnik*/

using System;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{
    public Action<string, int> onValueChanged;

    public CurrenciesHolder currencies;

    protected override void Awake()
    {
        base.Awake();

        currencies = new CurrenciesHolder();
        currencies.Load();
    }

    public void Add(string key, int amount) => currencies.Add(key, amount);
    public void Add(CurrencyData data, int amount) => currencies.Add(data, amount);

    public void Set(string key, int amount) => currencies.Set(key, amount);
    public void Set(CurrencyData data, int amount) => currencies.Set(data, amount);

    public void Remove(string key, int amount) => currencies.Remove(key, amount);
    public void Remove(CurrencyData data, int amount) => currencies.Remove(data, amount);

    public bool IsEnought(string key, int amount) => currencies.IsEnought(key, amount);
    public bool IsEnought(CurrencyData data, int amount) => currencies.IsEnought(data, amount);

    public void OnValueChanged(string key, int amount)
    {
        onValueChanged?.Invoke(key, amount);
    }
}