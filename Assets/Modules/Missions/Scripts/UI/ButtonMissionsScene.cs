
using System.Collections.Generic;
using UnityEngine;

public class ButtonMissionsScene : MonoBehaviour
{
    public List<GameObject> indicators;

    void Start()
    {
        UpdateIndicators();
    }

    public void UpdateIndicators()
    {
        if (MissionsManager.Instance)
            SetIndicatorState(MissionsManager.Instance.IsCompleated());
    }

    public void SetIndicatorState(bool active)
    {
        foreach (var indicator in indicators)
            indicator.SetActive(active);
    }
}
