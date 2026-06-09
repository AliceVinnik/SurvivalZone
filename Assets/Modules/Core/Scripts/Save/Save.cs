/*AliceVinnik*/

using UnityEngine;

public static class Save
{
    private static ISaveProvider _provider;

    public static ISaveProvider Provider
    {
        get => _provider ??= CreateProvider();
        set => _provider = value;
    }

    private static ISaveProvider CreateProvider()
    {
        switch (DistributorManager.Instance?.type)
        {
            case DistributorType.CrazyGames:
#if CRAZYGAMES_SDK
                return new SaveProviderCrazyGames();
#endif
                break;
        }

        return new SaveProviderDefault();
    }

    public static void SetInt(string key, int value) => Provider.SetInt(key, value);
    public static int GetInt(string key, int value = 0) => Provider.GetInt(key, value);

    public static void SetFloat(string key, float value) => Provider.SetFloat(key, value);
    public static float GetFloat(string key, float value = 0f) => Provider.GetFloat(key, value);

    public static void SetString(string key, string value) => Provider.SetString(key, value);
    public static string GetString(string key, string value = "") => Provider.GetString(key, value);

    public static void SetBool(string key, bool value) => SetInt(key, value ? 1 : 0);
    public static bool GetBool(string key, int value = 0) => GetInt(key) == 1;
    public static bool GetBool(string key, bool defaultValue) => GetInt(key, defaultValue ? 1 : 0) == 1;
}