using UnityEngine;

[System.Serializable]
public class MissionProgressData
{
    public MissionData data;
    public int before;
    public int after;

    public MissionProgressData(MissionData data, int before, int after)
    {
        this.data = data;
        this.before = before;
        this.after = after;
    }
}
