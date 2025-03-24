using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StringSet))]
public class StringSetEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Clear List"))
            ((StringSet)target).Clear();
    }
}