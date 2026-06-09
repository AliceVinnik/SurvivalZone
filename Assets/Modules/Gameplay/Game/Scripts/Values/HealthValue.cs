using System;
using UnityEngine;

[System.Serializable]
public class HealthValue
{
    public float health = 100f;
    public float max = 100f;

    public bool isDeath = false;

    public Action onDeath;
    public Action onValueUpdate;

    public HealthValue(float health, float max)
    {
        this.health = health;
        this.max = health;
    }

    public void Decrease(float value)
    {
        health -= value;

        if (health <= 0f)
        {
            health = 0f;
            isDeath = true;

            onDeath?.Invoke();
        }

        onValueUpdate?.Invoke();
    }

    public void Increase(float value)
    {
        health += value;

        if (health > max)
            health = max;

        onValueUpdate?.Invoke();
    }

    public void Restore()
    {
        health = max;
        isDeath = false;
    }

    public bool IsDeath() => isDeath;
    public bool IsFull() => health >= max;
    public float GetPercentage() => 1f / max * health;
}
