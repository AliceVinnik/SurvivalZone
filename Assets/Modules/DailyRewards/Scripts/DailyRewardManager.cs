/*AliceVinnik*/

using System;
using UnityEngine;

public class DailyRewardManager : Singleton<DailyRewardManager>
{
    public static string RECEIVED_DAILY_AT = "dailyReceivedAt";

    public Action<DailyRewardData> onReceiveReward;
    public Action onRewardNotReady;

    protected override void Awake()
    {
        base.Awake();
    }

    public void ReceiveReward(DailyRewardData data)
    {
        if (IsAvailable())
        {
            Save.SetString(RECEIVED_DAILY_AT, GetDate());
            onReceiveReward?.Invoke(data);
        }
        else
            onRewardNotReady?.Invoke();
    }

    #region State

    public static bool IsAvailable() => GetDate() != Save.GetString(RECEIVED_DAILY_AT, "");
    public static string GetDate() => DateTime.UtcNow.ToString("yyyy-MM-dd");

    public string GetTimeToNextReward()
    {
        var date = DateTime.UtcNow;
        var remaining = date.Date.AddDays(1) - date;

        var hours = remaining.Hours < 10 ? "0" + remaining.Hours.ToString() : remaining.Hours.ToString();
        var minutes = remaining.Minutes < 10 ? "0" + remaining.Minutes.ToString() : remaining.Minutes.ToString();
        var secounds = remaining.Seconds < 10 ? "0" + remaining.Seconds.ToString() : remaining.Seconds.ToString();

        return hours + ":" + minutes + ":" + secounds;
    }

    #endregion
}
