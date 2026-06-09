using UnityEngine;
using System.Linq;
using System;

public class GameStateManager : Static<GameStateManager>
{
    public GameStateData[] data;
    public GameStateData current;

    public Action<GameStateData> onStateChange;

    void Awake()
    {
        Load();
    }

    public void Load()
    {
        data = Resources.LoadAll<ScriptableObject>("States").OfType<GameStateData>().ToArray();

        Debug.Log($"[GameStateManager] Loaded: {data.Length} states.");
    }

    public void Set(string key)
    {
        foreach (var component in data)
            if (component.key == key)
            {
                Set(component);
                return;
            }
    }

    public void Set(GameStateData state)
    {
        current = state;

        onStateChange?.Invoke(current);
    }

    public string GetKey() => current.key;

    public void Pause() => Set(GetKey() == "pause" ? "game" : "pause");

    public bool IsPlayable() => current.isPlayable;
    public bool IsWorldActive() => current.isWorldActive;
}
