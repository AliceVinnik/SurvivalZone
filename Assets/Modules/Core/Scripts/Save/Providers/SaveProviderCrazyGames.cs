/*AliceVinnik*/

#if CRAZYGAMES_SDK
using CrazyGames;

public class SaveProviderCrazyGames : ISaveProvider
{
    public void SetInt(string key, int value)
    {
        if (CrazySDK.IsAvailable)
            CrazySDK.Data.SetInt(key, value);
        else
            CustomPlayerPrefs.SetInt(key, value);
    }

    public int GetInt(string key, int def = 0)
    {
        if (CrazySDK.IsAvailable)
            return CrazySDK.Data.GetInt(key, value);
        return CustomPlayerPrefs.GetInt(key, value);
    }

    public void SetFloat(string key, float value)
    {
        if (CrazySDK.IsAvailable)
            CrazySDK.Data.SetFloat(key, value);
        else
            CustomPlayerPrefs.SetFloat(key, value);
    }

    public float GetFloat(string key, float def = 0f)
    {
        if (CrazySDK.IsAvailable)
            return CrazySDK.Data.GetFloat(key, value);
        return CustomPlayerPrefs.GetFloat(key, value);
    }

    public void SetString(string key, string value)
    {
        if (CrazySDK.IsAvailable)
            CrazySDK.Data.SetString(key, value);
        else
            CustomPlayerPrefs.SetString(key, value);
    }

    public string GetString(string key, string def = "")
    {
        if (CrazySDK.IsAvailable)
            return CrazySDK.Data.GetString(key, value);
        return CustomPlayerPrefs.GetString(key, value);
    }
}
#endif