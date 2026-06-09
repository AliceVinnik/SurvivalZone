/*AliceVinnik*/

using UnityEngine;
using System.Linq;
using UnityEngine.AI;

[System.Serializable]
public class MissionsHolder
{
    public MissionData[] data;

    public void Load()
    {
        data = Resources.LoadAll<ScriptableObject>("Missions").OfType<MissionData>().ToArray();

        Debug.Log($"[MissionsHolder] Loaded: {data.Length} missions.");
    }

    public MissionData Get(string id)
    {
        foreach (var mission in data)
            if (mission.id == id)
                return mission;
        return null;
    }

    public MissionData GetRandom(string except)
    {
        var mission = data[Random.Range(0, data.Length)];
        if (mission.id == except)
            return GetRandom(except);
        return mission;
    }
}
