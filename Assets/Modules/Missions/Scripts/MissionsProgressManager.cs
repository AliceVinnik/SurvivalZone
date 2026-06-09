using System.Collections.Generic;
using UnityEngine;

public class MissionsProgressManager : MonoBehaviour
{
    public List<MissionProgressData> progress = new List<MissionProgressData>();

    public CellMissionProgress cell;
    public Transform cellHolder;

    void Start()
    {
        if (MissionsManager.Instance != null)
            MissionsManager.Instance.onMissionProgress += OnMissionProgress;
    }

    void OnDestroy()
    {
        if (MissionsManager.Instance != null)
            MissionsManager.Instance.onMissionProgress -= OnMissionProgress;
    }

    public void Clear()
    {
        progress = new List<MissionProgressData>();
    }

    public void OnMissionProgress(MissionData data, int before, int after)
    {
        if (IsExist(data))
            UpdateValue(data, after);
        else
            CreateNew(data, before, after);
    }

    #region Progress

    private bool IsExist(MissionData data)
    {
        foreach (var component in progress)
            if (component.data.id == data.id)
                return true;
        return false;
    }

    private void UpdateValue(MissionData data, int after)
    {
        foreach (var component in progress)
            if (component.data.id == data.id)
                component.after = after;
    }

    private void CreateNew(MissionData data, int before, int after)
    {
        var newComponent = new MissionProgressData(data, before, after);
        progress.Add(newComponent);
    }

    #endregion

    public void SpawnAllCells()
    {
        foreach (var component in progress)
        {
            var newCell = Instantiate(cell, cellHolder);
            newCell.Load(component.data);
            newCell.SnowAnimation(component.before, component.after);
        }
    }
}
