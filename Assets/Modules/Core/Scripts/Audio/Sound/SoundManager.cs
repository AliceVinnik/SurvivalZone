/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public Factory audioPlayers;
    public SoundsHolder holder;

    protected override void Awake()
    {
        base.Awake();

        holder = new SoundsHolder();
        holder.Load();

        audioPlayers.Initialize();
    }

    public bool IsSoundOn()
    {
        if (holder == null) return false;
        if (DistributorManager.Instance != null && !DistributorManager.Instance.IsAudioActive()) return false;
        return Save.GetBool("sound", true);
    }

    public void Play(string key)
    {
        if (!IsSoundOn()) return;
        var entry = holder.Get(key);
        if (entry != null)
            StartCoroutine(CreateSoundPlayer(entry.clip, entry.volume));
    }

    public void Play(AudioClip audioClip, float volume = 1f)
    {
        if (!IsSoundOn()) return;
        if (audioClip != null)
            StartCoroutine(CreateSoundPlayer(audioClip, volume));
    }

    private IEnumerator CreateSoundPlayer(AudioClip clip, float volume = 1f)
    {
        var player = audioPlayers.Get().GetComponent<SoundAudioPlayer>();
        player.LoadAndPlay(clip);
        yield return null;
    }
}