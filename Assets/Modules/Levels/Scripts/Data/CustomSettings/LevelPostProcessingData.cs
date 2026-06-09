/*AliceVinnik*/

using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class LevelPostProcessingData : ILevelCustomSetting
{
    public bool isOn = false;
    public VolumeProfile volumeProfile;

    public void Load()
    {
        if (!isOn) return;

        var volume = GameObject.FindFirstObjectByType<Volume>();
        if (volume != null)
        {
            volume.profile = volumeProfile;
        }
    }
}