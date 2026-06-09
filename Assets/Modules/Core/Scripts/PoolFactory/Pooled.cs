using UnityEngine;

public class Pooled : MonoBehaviour, IPooled
{
    private Pool pool;

    #region Pool

    public Pool AddPool { set { pool = value; } }

    public void ReturnToPull()
    {
        pool.ReturnObject(gameObject);
    }

    #endregion
}
