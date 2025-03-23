using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Raise Event"))
            ((GameEvent)target).Raise();
    }
}