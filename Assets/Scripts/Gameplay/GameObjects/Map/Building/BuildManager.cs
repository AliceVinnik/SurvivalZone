using System.Collections.Generic;
using UnityEngine;

public class BuildManager : Static<BuildManager>
{
    [Header("Components")]
    public ButtonWithPrice buttonBuild;

    [Header("Values")]
    public List<Building> buildings = new List<Building>();
    public int buildedTimes = 1;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        RefreshIndicators();
    }

    public void TryToBuild()
    {
        if (!Map.Instance.IsEmptyTile()) return;
        var price = GameDataManager.Instance.GetPriceBuilding();
        if (CurrencyManager.Instance.IsEnought("coin", price))
        {
            var tile = Map.Instance.GetRandomEmpty();
            if (tile != null)
            {
                CurrencyManager.Instance.Remove("coin", price);

                var building = GameObjectsManager.Instance.buildings.Get().GetComponent<Building>();
                building.Restore();
                tile.Place(building);

                buildedTimes++;

                building.onRemoved += OnBuildingRemoved;
                buildings.Add(building);

                RefreshIndicators();
            }
        }
    }

    public void OnBuildingRemoved(Building building)
    {
        building.onRemoved -= OnBuildingRemoved;
        buildings.Remove(building);

        if (buildings.Count <= 0)
            GameManager.Instance.GameOver();
    }

    public void RefreshIndicators()
    {
        var price = GameDataManager.Instance.GetPriceBuilding();
        buttonBuild.Set(price);
    }

    #region  Actions

    public void OnButtonBuild()
    {
        TryToBuild();
    }

    #endregion

    #region Interactions

    public Building GetTarget()
    {
        return buildings[Random.Range(0, buildings.Count - 1)];
    }

    public void HealAllBuildings(float value)
    {
        foreach (var building in buildings)
            building.health.Increase(value);
    }

    #endregion
}
