using UnityEngine;

public class GameDataManager : Static<GameDataManager>
{
    public GameProperties current;

    protected override void Awake()
    {
        base.Awake();

        CurrencyManager.Instance.Set("coin", current.coinsAtStart);
    }

    public int GetPriceBuilding()
    {
        var level = BuildManager.Instance.buildedTimes;
        return (int)current.priceBuilding.Get(level);
    }

    public int GetPriceIncreaseMap()
    {
        var level = MapManager.Instance.increasedTimes;
        return (int)current.priceIncreaseMap.Get(level);
    }
}
