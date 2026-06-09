using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    private EnemyAnimator enemyAnimator;

    public Animator animator;

    public GameObject body;

    void Awake()
    {
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    public void Set(EnemyData data)
    {
        body = EnemiesBodiesHolder.Instance.GetPrefab(data.body);
        body.transform.parent = transform;
        body.transform.localPosition = data.bodyShift;

        animator = body.GetComponent<Animator>();
        enemyAnimator.Set(animator);
    }

    public void ReturnBodyToPool()
    {
        EnemiesBodiesHolder.Instance.ReturnBody(body);
    }
}
