using UnityEngine;

public class MapManager : Static<MapManager>
{
    [Header("Components")]
    public ButtonWithPrice buttonIncrease;

    [Header("Values")]
    public bool isBoughtMode = false;
    public int increasedTimes = 1;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        RefreshIndicators();
    }

    public void BoughtMode(bool on)
    {
        if (isBoughtMode == on) return;
        isBoughtMode = on;

        if (isBoughtMode)
        {
            var tiles = Map.Instance?.GetDisabledNeighbours();
            foreach (var tile in tiles)
                tile.SetBought(true);
        }
        else
        {
            Map.Instance.DeactivateBoughtTiles();
        }
    }

    public bool TryToBought(Tile tile)
    {
        if (tile.state == TileState.Bought)
        {
            var price = GameDataManager.Instance.GetPriceIncreaseMap();
            if (CurrencyManager.Instance.IsEnought("coin", price))
            {
                CurrencyManager.Instance.Remove("coin", price);

                increasedTimes++;

                tile.Activate();
                MapManager.Instance.BoughtMode(false);

                RefreshIndicators();
                return true;
            }
        }
        return false;
    }

    public void RefreshIndicators()
    {
        var price = GameDataManager.Instance.GetPriceIncreaseMap();
        buttonIncrease.Set(price);
    }

    public void OnButtonIncreaseMap()
    {
        if (isBoughtMode == false)
            BoughtMode(true);
    }
}
