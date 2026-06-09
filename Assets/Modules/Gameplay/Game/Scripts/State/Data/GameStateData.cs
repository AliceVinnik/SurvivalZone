using UnityEngine;

[CreateAssetMenu(fileName = "GameState_", menuName = "Scriptable Objects/GameState")]
[System.Serializable]
public class GameStateData : ScriptableObject
{
    public string key;

    [Space]
    public bool isPlayable;
    public bool isWorldActive;
}
