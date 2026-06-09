/*AliceVinnik*/

using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DailyRewardData", menuName = "Scriptable Objects/DailyRewardData")]
public class DailyRewardData : ScriptableObject
{
    public string name;
    public Sprite icon;

    [Space]
    public string key;
    public int value;

    [Space]
    public Action<string> onReceiveValue;

    public void Receive(float multiplier = 1f)
    {
        var received = (float)value * multiplier;
        var valueBefore = Save.GetInt(key, 0);
        Save.SetInt(key, valueBefore + (int)received);

        onReceiveValue?.Invoke(key);
    }
}