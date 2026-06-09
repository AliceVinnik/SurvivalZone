/*AliceVinnik*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public bool isOn = true;
    public float time = 0.4f;

    #region Standart system methods

    void Update()
    {
        ChangeTimer();
    }

    #endregion

    #region Work with timer

    private void ChangeTimer()
    {
        time -= Time.deltaTime;

        if (time <= 0f)
        {
            var pooled = GetComponent<IPooled>();
            if (pooled != null)
                pooled.ReturnToPull();
            else
                Destroy(gameObject);
        }
    }

    #endregion
}