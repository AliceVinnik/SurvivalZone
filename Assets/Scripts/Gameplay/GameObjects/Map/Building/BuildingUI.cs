using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public TextMeshProUGUI textLevel;
    [Space]
    public Image indicatorHealth;
    public Image indicatorHealthFiller;

    private Building building;

    void Awake()
    {
        building = GetComponent<Building>();

        indicatorHealth.gameObject.SetActive(false);
    }

    public void Refresh()
    {
        RefreshLevel();
        RefreshHealth();
    }

    public void RefreshLevel()
    {
        textLevel.text = $"{building.level}";
    }

    public void RefreshHealth()
    {
        var isFull = building.health.IsFull();

        if (isFull)
        {
            indicatorHealth.gameObject.SetActive(false);
        }
        else
        {
            var percentage = building.health.GetPercentage();

            indicatorHealth.gameObject.SetActive(true);
            indicatorHealthFiller.fillAmount = percentage;
        }
    }
}
