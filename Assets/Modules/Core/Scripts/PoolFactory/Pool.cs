/*AliceVinnik*/

using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private List<GameObject> objects = new List<GameObject>();
    public GameObject poolObject;
    private Transform holder;
    [Space]
    public int size = 0;

    public Pool(int initSize, GameObject currentObject, Transform holder)
    {
        this.holder = holder;
        size = initSize;
        poolObject = currentObject;

        CreateInitialObjects(holder);
    }

    #region Get Set

    public GameObject GetObject(Transform holder)
    {
        if (objects.Count == 0)
            CreateObject(holder);

        var obj = objects[0];
        objects.RemoveAt(0);

        obj.SetActive(true);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.transform.parent = holder;
        obj.SetActive(false);
        objects.Add(obj);
    }

    #endregion

    #region Create objects

    private void CreateInitialObjects(Transform holder)
    {
        for (int i = 0; i < size; i++)
        {
            var obj = CreateObject(holder);
            obj.SetActive(false);
        }
    }

    private GameObject CreateObject(Transform holder)
    {
        if (holder == null)
        {
            var obj = GameObject.Instantiate(poolObject);
            objects.Add(obj);
            return obj;
        }
        else
        {
            var obj = GameObject.Instantiate(poolObject, holder);
            objects.Add(obj);
            return obj;
        }
    }

    #endregion
}