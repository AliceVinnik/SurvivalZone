/*AliceVinnik*/

using UnityEngine;

[System.Serializable]
public class LevelFogData : ILevelCustomSetting
{
    public bool isOn = false;
    public Color color;

    public bool isCustomDistance = false;
    public FromToFloat distances;

    public void Load()
    {
        if (!isOn) return;

        RenderSettings.fog = true;
        RenderSettings.fogColor = color;

        if (isCustomDistance)
        {
            RenderSettings.fogMode = FogMode.Linear;
            RenderSettings.fogStartDistance = distances.from;
            RenderSettings.fogEndDistance = distances.to;
        }
    }
}
