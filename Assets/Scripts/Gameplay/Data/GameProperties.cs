using UnityEngine;

[CreateAssetMenu(fileName = "GameProperties", menuName = "Scriptable Objects/GameProperties")]
public class GameProperties : ScriptableObject
{
    [Header("Init values")]
    public int coinsAtStart = 150;

    [Header("Prices")]
    public ScalableProperty priceBuilding;
    public ScalableProperty priceIncreaseMap;
    public ScalableProperty priceHeal;

    [Header("Building")]
    public ScalableProperty buildingRadius;
    public ScalableProperty buildingBulletSpeed;
    public ScalableProperty buildingDamage;
    public ScalableProperty buildingHealth;
    public ScalableProperty buildingCooldown;

    [Header("End game")]
    public float coinsConvertToCrystals = 0.1f;
}
