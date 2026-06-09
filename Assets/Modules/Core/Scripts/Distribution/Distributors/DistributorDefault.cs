using UnityEngine;

public class DistributorDefault : Singleton<DistributorDefault>, IDistributor
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void Init() { }
    public void GameplayState(bool play) { }
    public void SplashOnSite() { }

    public string GetName() => "User";
    public string GetToken() => "";

    public bool IsAudioActive() => true;
    public bool IsInitialised() => true;
}
