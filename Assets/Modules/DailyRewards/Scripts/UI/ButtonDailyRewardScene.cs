using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDailyRewardScene : MonoBehaviour
{
    public List<GameObject> indicators;

    void Start()
    {
        UpdateIndicators();
    }

    public void UpdateIndicators()
    {
        SetIndicatorState(DailyRewardManager.IsAvailable());
    }

    public void SetIndicatorState(bool active)
    {
        foreach (var indicator in indicators)
            indicator.SetActive(active);
    }
}
