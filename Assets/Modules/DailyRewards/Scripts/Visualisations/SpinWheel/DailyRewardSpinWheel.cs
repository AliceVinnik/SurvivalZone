/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DailyRewardSpinWheel : Static<DailyRewardSpinWheel>
{
    public List<DailyRewardData> data;

    public Action<DailyRewardData> onReceive;

    void Start()
    {
        CanvasDailyRewardSpinWheel.Instance.Load(data);
    }

    public void SpinStart()
    {
        if (DailyRewardManager.IsAvailable())
        {
            CanvasDailyRewardSpinWheel.Instance.StartSpin();
        }
    }

    public void SpinFinished(DailyRewardData data)
    {
        onReceive?.Invoke(data);
    }
}