/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnRun : MonoBehaviour
{
    void Awake()
    {
        var pooled = GetComponent<IPooled>();
        if (pooled != null)
            pooled.ReturnToPull();
        else
            Destroy(gameObject);
    }
}