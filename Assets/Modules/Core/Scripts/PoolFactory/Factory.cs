/*AliceVinnik*/

using UnityEngine;

public class Factory : MonoBehaviour
{
    private Pool pool;
    public GameObject obj;
    public Transform holder;
    [Space]
    public int poolSize;

    public void Initialize(Transform holder = null)
    {
        if (holder != null)
            this.holder = holder;

        pool = new Pool(poolSize, obj, this.holder);
    }

    public GameObject Get()
    {
        var obj = pool.GetObject(holder);

        var pooledObject = obj.GetComponent<IPooled>();
        if (pooledObject != null)
            pooledObject.AddPool = pool;

        return obj;
    }
}