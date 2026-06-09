/*AliceVinnik*/

using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class LevelDataHolder
{
    private LevelData[] data;

    public void Load()
    {
        data = Resources.LoadAll<ScriptableObject>("Levels").OfType<LevelData>().OrderBy(d => d.id).ToArray();

        Debug.Log($"[LevelDataHolder] Loaded: {data.Length} levels.");
    }

    public LevelData Get(int id)
    {
        if (id < data.Length)
            return data[id];
        return null;
    }

    public LevelData[] GetAll() => data;
}
