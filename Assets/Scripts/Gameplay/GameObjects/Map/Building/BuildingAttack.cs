/*AliceVinnik*/

using System.Collections;
using UnityEngine;

public enum AttackState
{
    Attack, Cooldown
}

public class BuildingAttack : MonoBehaviour
{
    private Building building;

    public AttackState state = AttackState.Attack;

    public float radius = 5f;
    public float speed = 5f;
    public float damage = 10f;
    public float cooldown = 0.3f;
    public float currentCooldown = 0.3f;

    void Awake()
    {
        building = GetComponent<Building>();
    }

    void Update()
    {
        if (!GameStateManager.Instance.IsPlayable()) return;
        if (building.isHold) return;

        TryToAttack();
        Cooldown();
    }

    public void TryToAttack()
    {
        if (state != AttackState.Attack) return;

        Attack();
    }

    public void Attack()
    {
        /*
        var target = EnemiesManager.Instance.GetCloserEnemy();
        if (target == null) return;

        var distance = Vector3.Distance(transform.position, target.transform.position);
        if (target != null && distance <= radius)
        {
            currentCooldown = cooldown;
            state = AttackState.Cooldown;

            var bullet = GameObjectsManager.Instance.bullets.Get().GetComponent<Bullet>();
            bullet.transform.position = transform.position;
            bullet.Load(target, speed, damage);
        }
        */
    }

    public void Cooldown()
    {
        if (state != AttackState.Cooldown) return;

        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            state = AttackState.Attack;
        }
    }
}
