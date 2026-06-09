using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class CanvasDailyRewardSpinWheel : Static<CanvasDailyRewardSpinWheel>
{
    public Transform wheel;
    public List<DailyRewardDataIndicator> indicators;
    private List<DailyRewardData> datas;

    [Space]
    public float speed;
    public float velocity;
    public FromToFloat time;
    private float timeToSpin;
    private float currentSpeed;
    private bool isSpin = false;

    public void Load(List<DailyRewardData> datas)
    {
        this.datas = datas;

        for (var i = 0; i < indicators.Count; i++)
        {
            var indicator = indicators[i];
            var data = datas[i];

            indicator.Load(data);
        }
    }

    void FixedUpdate()
    {
        Spin();
    }

    public void StartSpin()
    {
        timeToSpin = time.GetRandom();
        isSpin = true;
    }

    public void Spin()
    {
        if (!isSpin) return;

        timeToSpin -= Time.fixedDeltaTime;
        if (timeToSpin > 0)
        {
            currentSpeed += velocity;
        }
        else
        {
            currentSpeed -= velocity;
            if (currentSpeed <= 0)
            {
                FinishSpin();
                return;
            }
        }

        wheel.transform.Rotate(Vector3.forward, Time.fixedDeltaTime * currentSpeed);
    }

    public void FinishSpin()
    {
        isSpin = false;
        DailyRewardSpinWheel.Instance.SpinFinished(GetReward());
    }

    public DailyRewardData GetReward()
    {
        var segmentsCount = indicators.Count;
        var segmentAngle = 360f / segmentsCount;
        var currentAngle = wheel.transform.eulerAngles.z;
        var limit = 0f;
        for (int i = 0; i < segmentsCount; i++)
        {
            if (limit + segmentAngle > currentAngle)
            {
                return datas[i];
            }
            limit += segmentAngle;
        }
        return null;
    }
}
