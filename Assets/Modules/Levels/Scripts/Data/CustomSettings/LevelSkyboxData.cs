/*AliceVinnik*/

using UnityEngine;

[System.Serializable]
public class LevelSkyboxData : ILevelCustomSetting
{
    public bool isOn = false;
    public Material skybox;

    public void Load()
    {
        if (!isOn) return;

        RenderSettings.skybox = skybox;
    }
}
