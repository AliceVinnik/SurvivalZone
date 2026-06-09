/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneratorPoint
{
    private float current;
    [SerializeField] private float start = 0f;
    [SerializeField] private float distance = 20f;
    [SerializeField] private float shift = 1f;

    public GeneratorPoint()
    {
        current = start;
    }

    public float Get() => current;

    public bool IsReachDistance(float value, bool isIncrease)
    {
        if (isIncrease)
            return value + distance > current;
        else
            return value - distance < current;
    }

    public void Change() => current += shift;
    public void Change(float value) => current += value;
}