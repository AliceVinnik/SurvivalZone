using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    private Enemy enemy;

    public Image indicatorHealth;
    public Image indicatorHealthFiller;

    void Awake()
    {
        enemy = GetComponent<Enemy>();

        indicatorHealth.gameObject.SetActive(false);
    }

    public void Refresh()
    {
        RefreshHealth();
    }

    public void RefreshHealth()
    {
        var isFull = enemy.health.IsFull();
        var isDead = enemy.health.IsDeath();

        if (isFull || isDead)
        {
            indicatorHealth.gameObject.SetActive(false);
        }
        else
        {
            var percentage = enemy.health.GetPercentage();

            indicatorHealth.gameObject.SetActive(true);
            indicatorHealthFiller.fillAmount = percentage;
        }
    }
}
