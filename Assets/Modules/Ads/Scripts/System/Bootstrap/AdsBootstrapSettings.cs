/*AliceVinnik*/

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AdsBootstrapSettings", menuName = "Scriptable Objects/Bootstrap/AdsBootstrapSettings")]
public class AdsBootstrapSettings : ScriptableObject
{
    public List<GameObject> prefabs;

    public AdsType adType;
    public float timedInterstitial = 60f;
}