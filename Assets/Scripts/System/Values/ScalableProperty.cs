using UnityEngine;

[System.Serializable]
public class ScalableProperty
{
    public float minValue = 200f;
    public float maxValue = 2000f;
    public AnimationCurve change;
    public int maxLevel = 10;

    [Tooltip("Flat increase per level beyond maxLevel")]
    public float overflowIncreasePerLevel = 100f;

    public float Get(int level)
    {
        if (level <= 1)
            return minValue;

        if (change == null || change.length == 0)
            return minValue;

        if (level <= maxLevel)
        {
            float t = maxLevel > 1 ? Mathf.Clamp01((float)(level - 1) / (maxLevel - 1)) : 1f;
            return Mathf.Lerp(minValue, maxValue, change.Evaluate(t));
        }

        // Beyond maxLevel: maxValue + flat increase per extra level
        int overflowLevels = level - maxLevel;
        return maxValue + overflowLevels * overflowIncreasePerLevel;
    }
}

#if UNITY_EDITOR
[UnityEditor.CustomPropertyDrawer(typeof(ScalableProperty))]
public class ScalablePropertyDrawer : UnityEditor.PropertyDrawer
{
    private static readonly System.Collections.Generic.Dictionary<string, bool> foldouts = new();
    private static readonly System.Collections.Generic.Dictionary<string, int> testLevels = new();

    public override void OnGUI(Rect position, UnityEditor.SerializedProperty property, GUIContent label)
    {
        UnityEditor.EditorGUI.BeginProperty(position, label, property);

        float lineH = UnityEditor.EditorGUIUtility.singleLineHeight;
        float spacing = UnityEditor.EditorGUIUtility.standardVerticalSpacing;

        string key = property.propertyPath + "_" + property.serializedObject.targetObject.GetInstanceID();

        if (!foldouts.ContainsKey(key)) foldouts[key] = false;
        if (!testLevels.ContainsKey(key)) testLevels[key] = 1;

        Rect foldoutRect = new Rect(position.x, position.y, position.width, lineH);
        foldouts[key] = UnityEditor.EditorGUI.Foldout(foldoutRect, foldouts[key], label, true);

        if (foldouts[key])
        {
            UnityEditor.EditorGUI.indentLevel++;

            int row = 1;

            Rect minValueRect = new Rect(position.x, position.y + (lineH + spacing) * row++, position.width, lineH);
            UnityEditor.EditorGUI.PropertyField(minValueRect, property.FindPropertyRelative("minValue"), new GUIContent("Min Value (Lvl 1)"));

            Rect maxValueRect = new Rect(position.x, position.y + (lineH + spacing) * row++, position.width, lineH);
            UnityEditor.EditorGUI.PropertyField(maxValueRect, property.FindPropertyRelative("maxValue"), new GUIContent("Max Value (Lvl Max)"));

            Rect maxLevelRect = new Rect(position.x, position.y + (lineH + spacing) * row++, position.width, lineH);
            UnityEditor.EditorGUI.PropertyField(maxLevelRect, property.FindPropertyRelative("maxLevel"));

            Rect curveRect = new Rect(position.x, position.y + (lineH + spacing) * row++, position.width, lineH);
            UnityEditor.EditorGUI.PropertyField(curveRect, property.FindPropertyRelative("change"), new GUIContent("Curve (Min → Max)"));

            Rect overflowRect = new Rect(position.x, position.y + (lineH + spacing) * row++, position.width, lineH);
            UnityEditor.EditorGUI.PropertyField(overflowRect, property.FindPropertyRelative("overflowIncreasePerLevel"), new GUIContent("Overflow Per Level"));

            // Separator
            Rect sepRect = new Rect(position.x, position.y + (lineH + spacing) * row++, position.width, lineH);
            UnityEditor.EditorGUI.LabelField(sepRect, "— Test —", UnityEditor.EditorStyles.centeredGreyMiniLabel);

            // Test slider — allow going beyond maxLevel to test overflow
            int maxLevelVal = property.FindPropertyRelative("maxLevel").intValue;
            int testMax = maxLevelVal + 20;
            Rect testLevelRect = new Rect(position.x, position.y + (lineH + spacing) * row++, position.width, lineH);
            testLevels[key] = UnityEditor.EditorGUI.IntSlider(testLevelRect, "Test Level", testLevels[key], 1, testMax);

            // Label showing overflow indicator
            bool isOverflow = testLevels[key] > maxLevelVal;
            string levelLabel = isOverflow ? $"  (overflow +{testLevels[key] - maxLevelVal})" : "";
            if (isOverflow)
            {
                Rect overflowLabelRect = new Rect(position.x, position.y + (lineH + spacing) * row++, position.width, lineH);
                UnityEditor.EditorGUI.LabelField(overflowLabelRect, $"Beyond Max Level{levelLabel}", UnityEditor.EditorStyles.centeredGreyMiniLabel);
            }

            // Evaluate result
            float result = property.FindPropertyRelative("minValue").floatValue;
            var targetObject = property.serializedObject.targetObject;
            var field = targetObject.GetType().GetField(property.propertyPath,
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);

            if (field != null && field.GetValue(targetObject) is ScalableProperty sp)
                result = sp.Get(testLevels[key]);

            Rect resultRect = new Rect(position.x, position.y + (lineH + spacing) * row++, position.width, lineH);
            GUI.enabled = false;
            UnityEditor.EditorGUI.FloatField(resultRect, "Test Result", result);
            GUI.enabled = true;

            UnityEditor.EditorGUI.indentLevel--;
        }

        UnityEditor.EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(UnityEditor.SerializedProperty property, GUIContent label)
    {
        float lineH = UnityEditor.EditorGUIUtility.singleLineHeight;
        float spacing = UnityEditor.EditorGUIUtility.standardVerticalSpacing;

        string key = property.propertyPath + "_" + property.serializedObject.targetObject.GetInstanceID();

        if (!foldouts.TryGetValue(key, out bool expanded) || !expanded)
            return lineH;

        int maxLevelVal = property.FindPropertyRelative("maxLevel")?.intValue ?? 10;
        bool isOverflow = testLevels.TryGetValue(key, out int tl) && tl > maxLevelVal;

        int rows = isOverflow ? 10 : 9;
        return (lineH + spacing) * rows;
    }
}
#endif