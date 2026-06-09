using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellMissionProgress : MonoBehaviour
{
    [Header("Components")]
    public ProgressBar progressBar;
    public Image icon;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDescription;
    public TextMeshProUGUI textProgress;

    [Header("Values")]
    public MissionData data;

    public void Load(MissionData data)
    {
        this.data = data;

        icon.sprite = data.icon;
        textName.text = data.name;
        textDescription.text = data.description;
        textProgress.text = "";
    }

    public void LoadCurrent()
    {
        Load(MissionsManager.Instance?.current);
    }

    public void SnowAnimation(int before, int after)
    {
        var target = data.target;
        var percentageBefore = data.GetPercentage(before);
        var percentageAfter = data.GetPercentage(after);

        progressBar.SetValueInstant(percentageBefore);
        progressBar.SetValue(percentageAfter);

        textProgress.text = $"{target}/{after}";
    }

    public void ShowCurrentProgress()
    {
        var target = data.target;
        var progress = data.GetPercentage();

        progressBar.SetValueInstant(progress);

        textProgress.text = $"{target}/{data.GetProgress()}";
    }
}
