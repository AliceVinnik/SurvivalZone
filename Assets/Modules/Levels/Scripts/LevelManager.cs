/*AliceVinnik*/

using System;
using UnityEngine;

public class LevelManager : Static<LevelManager>
{
    public bool isLoadOnAwake = true;
    public Transform holder;

    [Space]
    public LevelData data;
    public GameObject prefab;

    [Space]
    public Action onLoaded;

    protected override void Awake()
    {
        base.Awake();

        if (isLoadOnAwake)
            Load();
    }

    public void Load()
    {
        data = LevelsHolderManager.Instance.Get();
        prefab = Instantiate(data.prefab, holder);
        data.Load();

        onLoaded?.Invoke();
    }
}
