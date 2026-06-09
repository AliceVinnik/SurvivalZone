/*AliceVinnik*/
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FromToInt))]
public class FromToIntDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, label);

        var labelWidth = 30f;
        var fieldWidth = (position.width - labelWidth * 2) / 2;

        Draw(position, property, labelWidth, fieldWidth);

        EditorGUI.EndProperty();
    }

    private void Draw(Rect position, SerializedProperty property, float labelWidth, float fieldWidth)
    {
        var fromLabel = new Rect(position.x, position.y, labelWidth, position.height);
        var fromField = new Rect(position.x + labelWidth, position.y, fieldWidth, position.height);
        var toLabel = new Rect(fromField.xMax + 4, position.y, labelWidth, position.height);
        var toField = new Rect(toLabel.xMax, position.y, fieldWidth - 4, position.height);

        EditorGUI.LabelField(fromLabel, "From");
        EditorGUI.PropertyField(fromField, property.FindPropertyRelative("from"), GUIContent.none);
        EditorGUI.LabelField(toLabel, "To");
        EditorGUI.PropertyField(toField, property.FindPropertyRelative("to"), GUIContent.none);
    }
}

[CustomPropertyDrawer(typeof(FromToFloat))]
public class FromToFloatDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, label);

        var labelWidth = 30f;
        var fieldWidth = (position.width - labelWidth * 2) / 2;

        Draw(position, property, labelWidth, fieldWidth);

        EditorGUI.EndProperty();
    }

    private void Draw(Rect position, SerializedProperty property, float labelWidth, float fieldWidth)
    {
        var fromLabel = new Rect(position.x, position.y, labelWidth, position.height);
        var fromField = new Rect(position.x + labelWidth, position.y, fieldWidth, position.height);
        var toLabel = new Rect(fromField.xMax + 4, position.y, labelWidth, position.height);
        var toField = new Rect(toLabel.xMax, position.y, fieldWidth - 4, position.height);

        EditorGUI.LabelField(fromLabel, "From");
        EditorGUI.PropertyField(fromField, property.FindPropertyRelative("from"), GUIContent.none);
        EditorGUI.LabelField(toLabel, "To");
        EditorGUI.PropertyField(toField, property.FindPropertyRelative("to"), GUIContent.none);
    }
}
#endif