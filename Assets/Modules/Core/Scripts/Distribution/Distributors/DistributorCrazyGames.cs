/*AliceVinnik*/

#if CRAZYGAMES_SDK
using UnityEngine;
using System.Threading.Tasks;
using CrazyGames;

public class DistributorCrazyGames : Singleton<DistributorCrazyGames>, IDistributor
{
    [Header("Values")]
    public bool isInitialised = false;

    [Header("Runtime")]
    public PortalUser currentUser;
    public string userName;
    public string userToken;
    public string osType;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Init()
    {
        CrazySDK.Init(() =>
        {
            isInitialised = true;
            GetUser();
            GetSystemInfo();
            CrazySDKAds.instance.DetectAdBlock();
        });
    }

    public void GameplayState(bool play)
    {
        if (CrazySDK.IsAvailable)
        {
            if (start) CrazySDK.Game.GameplayStart();
            else CrazySDK.Game.GameplayStop();
        }
    }

    public void SplashOnSite()
    {
        if (CrazySDK.IsAvailable)
            CrazySDK.Game.HappyTime();
    }

    public bool IsAudioActive()
    {
        if (CrazySDK.IsAvailable)
            return !CrazySDK.Game.Settings.muteAudio;
        return true;
    }

    public bool IsInitialised() => isInitialised;

    public string GetName() => userName;
    public string GetToken() => userToken;

    #region User

    public bool IsUserAvailable()
    {
        if (CrazySDK.IsAvailable) return CrazySDK.User.IsUserAccountAvailable;
        return false;
    }

    public void GetUser()
    {
        if (IsUserAvailable())
        {
            CrazySDK.User.GetUser(user =>
            {
                if (user != null)
                {
                    currentUser = user;
                    userName = currentUser.username;

                    GetUserToken();
                }
                else
                    ShowAuthPrompt();
            });
        }
    }

    public async void GetUserToken() => userToken = await CrazySDK.User.GetUserTokenAsync();

    public void GetSystemInfo()
    {
        var systemInfo = CrazySDK.User.SystemInfo;
        osType = systemInfo.os.version;
    }

    public void ShowAuthPrompt()
    {
        CrazySDK.User.ShowAuthPrompt((error, user) =>
        {
            if (error != null)
            {
                Debug.LogError("Show auth prompt error: " + error);
                return;
            }
            Debug.Log("Auth prompt user: " + user);
        });
    }

    #endregion
}
#endif