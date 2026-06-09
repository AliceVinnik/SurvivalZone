using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasLaunchManager : Static<CanvasLaunchManager>
{
    public List<GameObject> enabled;
    public List<GameObject> disabled;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Prepare()
    {
        PrepareObjects(enabled, true);
        PrepareObjects(disabled, false);
    }

    public void PrepareObjects(List<GameObject> objects, bool enabled)
    {
        foreach (var obj in objects)
            obj.SetActive(true);

        if (!enabled)
            StartCoroutine(Disable(objects));
    }

    public IEnumerator Disable(List<GameObject> objects)
    {
        yield return null;

        foreach (var obj in objects)
            obj.SetActive(false);
    }
}
