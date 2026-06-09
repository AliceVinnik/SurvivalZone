using System;
using UnityEngine;

public class MissionsManager : Singleton<MissionsManager>
{
    private static string KEY_MISSION_CURRENT = "MISSION_CURRENT";
    private static string KEY_MISSION_PROGRESS = "MISSION_PROGRESS";

    public MissionsHolder missions;
    public MissionData current;

    public bool isAutoCompleate = true;

    public Action<MissionData> onMissionStarted;
    public Action<MissionData, int, int> onMissionProgress;
    public Action<MissionData> onMissionCompleated;

    protected override void Awake()
    {
        base.Awake();

        missions = new MissionsHolder();
        missions.Load();

        Load();
    }

    private void Load()
    {
        current = missions.Get(Save.GetString(KEY_MISSION_CURRENT, ""));
        if (current == null)
            StartNew();
    }

    public void StartNew()
    {
        current = missions.GetRandom(Save.GetString(KEY_MISSION_CURRENT, ""));
        if (current != null)
        {
            Save.SetString(KEY_MISSION_CURRENT, current.id);
            Save.SetInt(KEY_MISSION_PROGRESS, 0);

            MissionsManager.Instance?.NewMissionStarted();
        }
        else
            Debug.Log("[MissionsHolder] Cannot started new mission, mission is null");
    }

    public void Compleate(string key, int value)
    {
        if (current.key == key)
        {
            var before = Save.GetInt(KEY_MISSION_PROGRESS, 0);
            var result = before + value;
            Save.SetInt(KEY_MISSION_PROGRESS, result);

            if (result >= current.target)
            {
                onMissionCompleated?.Invoke(current);

                if (isAutoCompleate)
                {
                    ReceiveReward();
                    StartNew();
                }
            }
            else
                onMissionProgress?.Invoke(current, before, result);
        }
    }

    public bool IsCompleated() => current.IsCompleated();

    public void ReceiveReward()
    {
        current.Receive();
    }

    public void NewMissionStarted()
    {
        onMissionStarted?.Invoke(current);
    }
}
