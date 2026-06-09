using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasGameOver : Static<CanvasGameOver>
{
    public TextMeshProUGUI textTitle;
    public TextMeshProUGUI textWave;
    public TextMeshProUGUI textCrystals;
    public TextMeshProUGUI textResult;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Prepare()
    {
        var data = GameDataManager.Instance;

        /*
        textTitle.text = data.isCompleate ? "WIN" : "DEFEAT";
        textWave.text = $"Wave: {data.level}";
        textCrystals.text = $"{data.earnedCrystals}";
        textResult.text = data.isBestScore ? "It's a highest wave" : "";
        */
    }
}
