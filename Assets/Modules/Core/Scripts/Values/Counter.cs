/*AliceVinnik*/

using System;

[System.Serializable]
public class Counter
{
    public int value;
    private int valueDefault;

    public Action<Counter> onValueChange;

    public Counter(int value)
    {
        this.value = value;
        valueDefault = value;
    }

    #region Work with value

    public bool Tick(bool restore = false)
    {
        if (value == 0) return false;

        value--;
        onValueChange?.Invoke(this);
        var done = value <= 0;
        if (restore) Restore();

        return value <= 0;
    }

    public void Restore() => value = valueDefault;
    public float GetPercentage() => 1f / (float)valueDefault * (float)value;

    #endregion
}