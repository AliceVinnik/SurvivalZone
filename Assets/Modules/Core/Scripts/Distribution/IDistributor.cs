/*AliceVinnik*/
using UnityEngine;

public interface IDistributor
{
    void Init();
    void GameplayState(bool play);
    void SplashOnSite();

    bool IsInitialised();
    bool IsAudioActive();

    string GetName();
    string GetToken();
}
