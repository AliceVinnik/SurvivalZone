using UnityEngine;

[CreateAssetMenu(fileName = "Sound_", menuName = "Scriptable Objects/SoundEntry")]
[System.Serializable]
public class SoundEntry : ScriptableObject
{
    public string key;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;
}