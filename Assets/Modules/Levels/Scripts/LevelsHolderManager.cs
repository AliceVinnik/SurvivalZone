/*AliceVinnik*/

using System;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelsHolderManager : Singleton<LevelsHolderManager>
{
    private static string KEY_CURRENT = "LEVEL_CURRENT";
    private static string KEY_LOCKED = "LEVEL_LOCKED_";

    public LevelDataHolder data = new LevelDataHolder();

    public Action<int> onLevelUnlocked;

    protected override void Awake()
    {
        base.Awake();

        data.Load();
    }

    #region Get Set

    public void Set(int id) => Save.SetInt(KEY_CURRENT, id);

    public LevelData Get() => data.Get(GetID());
    public LevelData Get(int id) => data.Get(id);
    public LevelData[] GetAll() => data.GetAll();

    public int GetID() => Save.GetInt(KEY_CURRENT, 0);

    #endregion

    #region Unlock

    public bool IsLocked(int id) => Save.GetBool($"{KEY_LOCKED}{id}", id == 0 ? false : true);

    public void Unlock(int id)
    {
        Save.SetBool($"{KEY_LOCKED}{id}", true);
        onLevelUnlocked?.Invoke(id);
    }

    public void UnlockNext() => Unlock(GetID() + 1);

    #endregion
}
