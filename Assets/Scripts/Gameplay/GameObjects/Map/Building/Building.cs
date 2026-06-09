/*AliceVinnik*/

using System;
using Unity.VisualScripting;
using UnityEngine;

public enum BuildingType
{
    Default
}

public class Building : MonoBehaviour
{
    [Header("Components")]
    private Pooled pooled;
    private BuildingUI buildingUI;
    private BuildingProperties buildingProperties;

    [Header("Values")]
    public bool isHold = false;
    public BuildingType type;
    public int level = 1;

    public Tile tile;

    [Header("Game properties")]
    public HealthValue health;

    public Action<Building> onRemoved;

    [Header("Test")]
    public bool isReceiveDamage = true;

    void Awake()
    {
        pooled = GetComponent<Pooled>();
        buildingUI = GetComponent<BuildingUI>();
        buildingProperties = GetComponent<BuildingProperties>();

        health.onDeath += OnDeath;
        health.onValueUpdate += OnValueHealthUpdate;
    }

    public void Start()
    {
        buildingProperties.LoadValues();
    }

    void OnDestroy()
    {
        health.onDeath -= OnDeath;
        health.onValueUpdate -= OnValueHealthUpdate;
    }

    public void Restore()
    {
        if (tile)
            tile.building = null;
        tile = null;
        level = 1;

        buildingProperties.LoadValues();

        buildingUI.Refresh();
    }

    public void Place(Tile tile)
    {
        if (this.tile)
            this.tile.building = null;
        this.tile = tile;
    }

    public void Remove()
    {
        Restore();
        onRemoved?.Invoke(this);
        pooled.ReturnToPull();
    }

    public void RefreshPosition()
    {
        transform.position = tile.buildingPosition.position;
    }

    public bool IsCanCombine(Building building) => building.type == type && building.level == level;

    public void Combine(Building building)
    {
        level += 1;
        buildingProperties.LoadValues();

        buildingUI.Refresh();
    }

    public void Damage(float value)
    {
        if (isReceiveDamage)
            health.Decrease(value);
    }

    public void OnDeath()
    {
        Remove();
    }

    public void OnValueHealthUpdate()
    {
        buildingUI.RefreshHealth();
    }

    public void SetHealth(float value)
    {
        float currentPercent = health.GetPercentage();
        health = new HealthValue(value * currentPercent, value);
        health.onDeath += OnDeath;
        health.onValueUpdate += OnValueHealthUpdate;
    }
}
