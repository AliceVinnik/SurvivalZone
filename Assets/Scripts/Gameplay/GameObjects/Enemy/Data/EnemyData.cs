using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Values")]
    public float health = 10f;
    public float speed = 1f;
    public float damage = 1f;
    public float distanceToAttack = 0.7f;
    public int coinsDrop = 10;

    [Header("Visual")]
    public GameObject body;
    public Vector3 bodyShift;
}
