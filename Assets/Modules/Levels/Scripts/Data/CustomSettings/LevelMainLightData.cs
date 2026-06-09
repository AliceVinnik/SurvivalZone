/*AliceVinnik*/

using UnityEngine;

[System.Serializable]
public class LevelMainLightData : ILevelCustomSetting
{
    public bool isOn = false;
    public float intencity = 1f;
    public Color color = Color.white;

    public void Load()
    {
        if (!isOn) return;

        var light = GameObject.FindFirstObjectByType<LevelMainLight>();
        light.Load(this);
    }
}