public class SaveProviderDefault : ISaveProvider
{
    public void SetInt(string key, int value) => CustomPlayerPrefs.SetInt(key, value);
    public int GetInt(string key, int def = 0) => CustomPlayerPrefs.GetInt(key, def);
    public void SetFloat(string key, float value) => CustomPlayerPrefs.SetFloat(key, value);
    public float GetFloat(string key, float def = 0f) => CustomPlayerPrefs.GetFloat(key, def);
    public void SetString(string key, string value) => CustomPlayerPrefs.SetString(key, value);
    public string GetString(string key, string def = "") => CustomPlayerPrefs.GetString(key, def);
}