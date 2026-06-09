/*AliceVinnik*/

using UnityEngine;

public class BuildingProperties : MonoBehaviour
{
    private Building building;
    private BuildingAttack buildingAttack;

    void Awake()
    {
        building = GetComponent<Building>();
        buildingAttack = GetComponent<BuildingAttack>();
    }

    public void LoadValues()
    {
        var level = building.level;

        buildingAttack.radius = GameDataManager.Instance.current.buildingRadius.Get(level);
        buildingAttack.speed = GameDataManager.Instance.current.buildingBulletSpeed.Get(level);
        buildingAttack.damage = GameDataManager.Instance.current.buildingDamage.Get(level);
        buildingAttack.cooldown = GameDataManager.Instance.current.buildingCooldown.Get(level);

        building.SetHealth(GameDataManager.Instance.current.buildingHealth.Get(level));
    }
}
