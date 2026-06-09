/*AliceVinnik*/

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Scriptable Objects/MissionData")]
[System.Serializable]
public class MissionData : ScriptableObject
{
    public string key = "";
    public string id = "";

    [Space]
    public Sprite icon;
    public string name = "";
    public string description = "";
    public int target = 1;

    [Space]
    public List<ReceivableCurrency> rewardsCurrency;

    public void Receive()
    {
        foreach (var reward in rewardsCurrency)
            reward.Receive();
    }

    public int GetTarget() => target;
    public int GetProgress() => Save.GetInt("MISSION_PROGRESS", 0);

    public float GetPercentage(float value) => 1f / (float)target * value;
    public float GetPercentage(int value) => GetPercentage((float)value);
    public float GetPercentage() => GetPercentage(GetProgress());

    public bool IsCompleated() => GetProgress() >= target;
}
