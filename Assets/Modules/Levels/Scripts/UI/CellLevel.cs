using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CellLevel : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI textNumber;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDescription;
    public Image icon;
    public GameObject iconLock;
    public Animation animationIndicatorLocked;

    [Header("Data")]
    public LevelData data;
    public bool isLocked;

    public Action<LevelData> onLevelLocked;
    public Action<LevelData> onLevelSelected;

    public void Load(LevelData data)
    {
        isLocked = data.IsLocked();

        textNumber.text = $"{data.id + 1}";
        textName.text = data.name;
        textDescription.text = data.description;
        icon.sprite = data.icon;

        iconLock.SetActive(!isLocked);
    }

    public void OnButtonPress()
    {
        if (isLocked)
        {
            animationIndicatorLocked.Play();
            onLevelLocked?.Invoke(data);
        }
        else
        {
            onLevelSelected?.Invoke(data);
        }
    }
}
