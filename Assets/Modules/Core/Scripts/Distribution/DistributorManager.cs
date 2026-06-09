/*AliceVinnik*/

#if CRAZYGAMES_SDK
using CrazyGames;
#endif
using UnityEngine;

public enum DistributorType
{
    Non, CrazyGames
}

public class DistributorManager : Singleton<DistributorManager>
{
    private static IDistributor _distributor;

    public static IDistributor Distributor
    {
        get => _distributor ??= CreateProvider();
        set => _distributor = value;
    }

    private static IDistributor CreateProvider()
    {
        switch (DistributorManager.Instance?.type)
        {
            case DistributorType.CrazyGames:
#if CRAZYGAMES_SDK
                return DistributorManager.Instance.gameObject.AddComponent<DistributorCrazyGames>();
#endif
                break;
        }

        return DistributorManager.Instance.gameObject.AddComponent<DistributorDefault>();
    }

    public DistributorType type;

    void Awake()
    {
        Init();
    }

    public void Init() => Distributor.Init();

    public void GameplayState(bool play) => Distributor.GameplayState(play);
    public void SplashOnSite() => Distributor.SplashOnSite();

    public bool IsAudioActive() => Distributor.IsAudioActive();
    public bool IsInitialised() => Distributor.IsInitialised();

    public string GetName() => Distributor.GetName();
    public string GetToken() => Distributor.GetToken();
}