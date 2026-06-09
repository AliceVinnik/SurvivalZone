using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonDailyRewardReceiveAndTimer : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;

    [Space]
    public string textReceive = "RECEIVE";
    [Space]
    public Color colorReady;
    public Color colorWait;

    public Action onButtonPress;

    void Update()
    {
        UpdateView();
    }

    public void UpdateView()
    {
        if (DailyRewardManager.IsAvailable())
        {
            text.text = textReceive;
            image.color = colorReady;
        }
        else
        {
            text.text = DailyRewardManager.Instance.GetTimeToNextReward();
            image.color = colorWait;
        }
    }

    public void OnButtonPress()
    {
        onButtonPress?.Invoke();
    }
}
