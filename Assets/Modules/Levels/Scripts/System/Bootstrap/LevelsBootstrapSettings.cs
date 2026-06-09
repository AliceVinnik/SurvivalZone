/*AliceVinnik*/

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DailyRewardBootstrapSettings", menuName = "Scriptable Objects/Bootstrap/LevelsBootstrapSettings")]
public class LevelsBootstrapSettings : ScriptableObject
{
    public List<GameObject> prefabs;
}