/*AliceVinnik*/

#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MissionData))]
public class MissionDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();

        MissionData mission = (MissionData)target;

        if (GUILayout.Button("Generate ID"))
        {
            mission.id = Guid.NewGuid().ToString("N");
            EditorUtility.SetDirty(mission);
        }
    }
}

#endif