using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Pooled pooled;

    public Enemy target;

    [Space]
    public float speed = 5f;
    public float damage = 10f;

    void Awake()
    {
        pooled = GetComponent<Pooled>();
    }

    void FixedUpdate()
    {
        if (!GameStateManager.Instance.IsPlayable()) return;

        Move();
    }

    public void Load(Enemy target, float speed, float damage)
    {
        this.target = target;
        this.speed = speed;
        this.damage = damage;
    }

    public void Restore()
    {
        target = null;
    }

    public void Destroy()
    {
        Restore();
        pooled.ReturnToPull();
    }

    public void Move()
    {
        if (target == null)
            Destroy();

        var distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 0.05f)
        {
            target.Damage(damage);
            Destroy();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.fixedDeltaTime * speed);
        }
    }
}
