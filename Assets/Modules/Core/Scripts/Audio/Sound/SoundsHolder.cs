using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class SoundsHolder
{
    public SoundEntry[] entries;

    public void Load()
    {
        entries = Resources.LoadAll<ScriptableObject>("Sounds").OfType<SoundEntry>().ToArray();

        Debug.Log($"[SoundsHolder] Loaded: {entries.Length} sounds.");
    }

    public virtual SoundEntry Get(string key)
    {
        foreach (var entry in entries)
            if (entry.key == key) return entry;
        return null;
    }
}
