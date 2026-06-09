/*AliceVinnik*/

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionsBootstrapSettings", menuName = "Scriptable Objects/Bootstrap/MissionsBootstrapSettings")]
public class MissionsBootstrapSettings : ScriptableObject
{
    public List<GameObject> prefabs;

    public bool isAutoCompleate = true;
}