/*AliceVinnik*/

using System;
using System.Collections;
using UnityEngine;

public enum AdsType
{
    Non, CrazyGames
}

public class AdManager : Singleton<AdManager>
{
    public AdsType type;
    public float timedInterstitial = 60f;
    public bool isAvailableTimedInterstitial = true;

    public AdsRewardData rewardData;

    public Action onInterstitialStarted;
    public Action onInterstitialHidden;

    public Action onRewardStarted;
    public Action<AdsRewardData> onRewardReceive;
    public Action onRewardCanceled;

    private static IAdsProvider _provider;
    public static IAdsProvider Provider
    {
        get => _provider ??= CreateProvider();
        set => _provider = value;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private static IAdsProvider CreateProvider()
    {
        switch (Instance.type)
        {
            case AdsType.CrazyGames:
#if CRAZYGAMES_SDK
                return new AdsProviderCrazyGames();
#endif
                break;
        }

        return null;
    }

    public void LoadType(AdsBootstrapSettings settings)
    {
        type = settings.adType;
        timedInterstitial = settings.timedInterstitial;

        Init();
    }

    public void Init()
    {
        if (Provider != null) Provider.Init();
    }

    #region Banner

    public void BannerShow()
    {
        if (Provider != null) Provider.Init();
    }

    public void BannerHide()
    {
        if (Provider != null) Provider.Init();
    }

    #endregion

    #region Interstitial

    public void TryToStartTimedInterstitial()
    {
        if (isAvailableTimedInterstitial)
        {
            isAvailableTimedInterstitial = false;
            InterstitialShow();

            StartCoroutine(RefreshTimedInterstitial());
        }
    }

    public IEnumerator RefreshTimedInterstitial()
    {
        yield return new WaitForSeconds(timedInterstitial);

        isAvailableTimedInterstitial = true;
    }

    public void InterstitialShow()
    {
        if (Provider != null) Provider.Init();
    }

    public void InterstitialStarted()
    {
        MusicPlayerManager.Instance?.Pause(true);

        onInterstitialStarted?.Invoke();
    }

    public void InterstitialHidden()
    {
        MusicPlayerManager.Instance?.Pause(false);

        onInterstitialHidden?.Invoke();
    }

    #endregion

    #region Rewards

    public void RewardAdShow(AdsRewardData data)
    {
        if (Provider != null)
        {
            rewardData = data;
            Provider.Init();
        }
    }

    public void RewardAdStarted()
    {
        MusicPlayerManager.Instance?.Pause(true);

        onRewardStarted?.Invoke();
    }

    public void RewardAdReceive()
    {
        MusicPlayerManager.Instance?.Pause(false);

        onRewardReceive?.Invoke(rewardData);
    }

    public void RewardAdCanceled()
    {
        MusicPlayerManager.Instance?.Pause(false);

        onRewardCanceled?.Invoke();
    }

    #endregion
}