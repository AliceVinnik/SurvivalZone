/*AliceVinnik*/

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DailyRewardBootstrapSettings", menuName = "Scriptable Objects/Bootstrap/CoreBootstrapSettings")]
public class CoreBootstrapSettings : ScriptableObject
{
    public List<GameObject> prefabs;

    public DistributorType distributorType = DistributorType.Non;
}