using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Enemy enemy;

    public Building target;

    public bool isFreeze = false;
    public float damage = 10f;
    public float speed = 5f;
    public float distanceToAttack = 0.5f;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    void FixedUpdate()
    {
        if (!GameStateManager.Instance.IsPlayable()) return;
        if (isFreeze) return;
        if (!enemy.isActive) return;

        Move();
    }

    public void Restore()
    {
        target = null;
    }

    public void FindTarget()
    {
        target = BuildManager.Instance.GetTarget();
    }

    public void Move()
    {
        if (target == null)
        {
            FindTarget();
            if (target == null)
                isFreeze = true;
        }

        var distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > distanceToAttack)
        {
            var moveTo = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.fixedDeltaTime * speed);

            var direction = (moveTo - transform.position).normalized;
            if (direction != Vector3.zero)
            {
                var targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * speed * 10);
            }
        }
        else
        {
            enemy.FinalAttack();
        }
    }

    public void Attack()
    {
        target.Damage(damage);
    }
}
