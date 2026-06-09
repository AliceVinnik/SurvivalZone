/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Static<MusicManager>
{
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;

    protected override void Awake()
    {
        base.Awake();

        Load();
    }

    public void Load()
    {
        MusicPlayerManager.Instance?.Load(this);
    }

    public void Play()
    {
        MusicPlayerManager.Instance?.Pause(false);
    }

    public void Pause()
    {
        MusicPlayerManager.Instance?.Pause(true);
    }
}