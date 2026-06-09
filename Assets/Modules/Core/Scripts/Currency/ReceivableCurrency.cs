using UnityEngine;

[System.Serializable]
public class ReceivableCurrency
{
    public CurrencyData data;
    public int amount;

    public void Receive() => data.Add(amount);
    public void Receive(int amount) => data.Add(amount);
}
