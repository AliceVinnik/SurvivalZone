/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct FromToInt
{
    public int from;
    public int to;

    public FromToInt(int from, int to)
    {
        this.from = from;
        this.to = to;
    }

    #region Get

    public int GetRandom() => Random.Range(from, to);

    public float GetValuePercentage(int percentage)
    {
        var diff = Mathf.Abs(to - from);
        return from < to ? from + diff * percentage : from - diff * percentage;
    }

    #endregion

    public bool IsInRange(int value) => value >= from && value <= to;
}

[System.Serializable]
public struct FromToFloat
{
    public float from;
    public float to;

    public FromToFloat(float from, float to)
    {
        this.from = from;
        this.to = to;
    }

    #region Get

    public float GetRandom() => Random.Range(from, to);

    public float GetValuePercentage(float percentage)
    {
        var diff = Mathf.Abs(to - from);
        return from < to ? from + diff * percentage : from - diff * percentage;
    }

    #endregion

    public bool IsInRange(float value) => value >= from && value <= to;
}