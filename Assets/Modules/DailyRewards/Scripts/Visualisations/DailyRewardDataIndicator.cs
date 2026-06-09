using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DailyRewardDataIndicator : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI text;

    public DailyRewardData data;

    public void Load(DailyRewardData data)
    {
        this.data = data;

        icon.sprite = data.icon;
        text.text = $"{data.value}";
    }
}
