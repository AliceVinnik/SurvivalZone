using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Components")]
    private EnemyAI enemyAI;
    private EnemyVisual enemyVisual;
    private EnemyAnimator enemyAnimator;
    private EnemyUI enemyUI;
    private Pooled pooled;

    [Header("Values")]
    public HealthValue health;
    public int coinsDrop;
    public bool isActive = false;

    public Action<Enemy> onEnemyDestroy;

    void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        enemyVisual = GetComponent<EnemyVisual>();
        enemyAnimator = GetComponent<EnemyAnimator>();
        enemyUI = GetComponent<EnemyUI>();
        pooled = GetComponent<Pooled>();
    }

    public void Load(EnemyData data)
    {
        health = new HealthValue(data.health, data.health);
        health.onDeath += OnDeath;
        coinsDrop = data.coinsDrop;

        enemyAI.speed = data.speed;
        enemyAI.damage = data.damage;
        enemyAI.distanceToAttack = data.distanceToAttack;

        enemyAI.FindTarget();
        enemyVisual.Set(data);

        enemyAnimator.PlayWalk();

        enemyUI.Refresh();
        isActive = true;
    }

    public void Restore()
    {
        enemyAI.Restore();
        enemyUI.Refresh();
    }

    public void ReceiveCoins()
    {
        CurrencyManager.Instance.Add("coin", coinsDrop);
    }

    #region Health

    public void Damage(float value)
    {
        if (!isActive) return;

        GameObjectsManager.Instance.SetParticleDamage(transform.position);

        health.Decrease(value);
        enemyUI.RefreshHealth();
    }

    public void Destroy()
    {
        Restore();
        onEnemyDestroy?.Invoke(this);
        enemyVisual.ReturnBodyToPool();
        pooled.ReturnToPull();
    }

    public void OnDeath()
    {
        if (isActive)
        {
            isActive = false;
            enemyAnimator.PlayDead();
            StartCoroutine(DestroyAfterAnimation("dead", true));
        }
    }

    public void FinalAttack()
    {
        if (isActive)
        {
            isActive = false;
            enemyAnimator.PlayAttack();
            StartCoroutine(DestroyAfterAnimation("attack"));
        }
    }

    public IEnumerator DestroyAfterAnimation(string name, bool receiveCoins = false)
    {
        yield return new WaitForSeconds(enemyAnimator.GetAnimationTime(name));

        if (name == "attack")
            enemyAI.Attack();
        if (receiveCoins)
            ReceiveCoins();
        Destroy();
    }

    #endregion
}
