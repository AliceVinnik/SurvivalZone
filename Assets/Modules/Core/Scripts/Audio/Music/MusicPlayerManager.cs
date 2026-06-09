/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerManager : Singleton<MusicPlayerManager>
{
    [HideInInspector] private AudioSource audioSource;

    #region Standart system methods

    protected override void Awake()
    {
        base.Awake();

        audioSource = GetComponent<AudioSource>();
    }

    #endregion

    public bool IsSoundOn()
    {
        if (DistributorManager.Instance != null && !DistributorManager.Instance.IsAudioActive()) return false;
        return Save.GetBool("music", true);
    }

    public void Load(MusicManager musicManager)
    {
        audioSource.volume = musicManager.volume;
        if (audioSource.clip != musicManager.clip)
        {
            audioSource.clip = musicManager.clip;

            if (IsSoundOn()) audioSource.Play();
            else audioSource.Stop();
        }
    }

    public void Pause(bool value)
    {
        if (value) audioSource.Pause();
        else audioSource.Play();
    }
}