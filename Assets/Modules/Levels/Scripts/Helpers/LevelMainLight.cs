using UnityEngine;

public class LevelMainLight : MonoBehaviour
{
    public void Load(LevelMainLightData data)
    {
        var light = GetComponent<Light>();
        if (light)
        {
            light.intensity = data.intencity;
            light.color = data.color;
        }
    }
}
