/*AliceVinnik*/

using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
[System.Serializable]
public class LevelData : ScriptableObject
{
    private static string KEY_LOCKED = "LEVEL_LOCKED_";

    [Header("Properties")]
    public int id;

    [Space]
    public string name;
    public string description;
    public Sprite icon;

    [Space]
    public GameObject prefab;

    [Header("Custom Settings")]
    public LevelMainLightData light;
    public LevelSkyboxData skybox;
    public LevelFogData fog;
    public LevelPostProcessingData postProcessing;

    public void Load()
    {
        light.Load();
        skybox.Load();
        fog.Load();
        postProcessing.Load();

        DynamicGI.UpdateEnvironment();
    }

    public bool IsLocked() => Save.GetBool($"{KEY_LOCKED}{id}", id == 0 ? false : true);
}
