/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAudioPlayer : MonoBehaviour, IPooled
{
    private AudioSource audioSource;
    private Pool pool;

    private float timeToRemove = 999.9f;
    private bool tryToRemove = false;

    #region Standart system methods

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (tryToRemove)
            TryToRemove();
    }

    #endregion

    public void LoadAndPlay(AudioClip newClip, float volume = 1f)
    {
        audioSource.clip = newClip;
        audioSource.volume = volume;
        audioSource.Play();

        timeToRemove = newClip.length;
        tryToRemove = true;
    }

    public void TryToRemove()
    {
        timeToRemove -= Time.deltaTime;
        if (timeToRemove < 0)
        {
            tryToRemove = false;
            ReturnToPull();
        }
    }

    #region Pool

    public Pool AddPool { set { pool = value; } }

    public void ReturnToPull()
    {
        pool.ReturnObject(gameObject);
    }

    #endregion
}