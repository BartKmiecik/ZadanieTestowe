using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AgentSpawner)), CanEditMultipleObjects]
public class CustomEditorAgentSpawner : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AgentSpawner spawner = (AgentSpawner)target;

        GUILayout.BeginHorizontal();

        spawner.timeRangeMin = EditorGUILayout.Slider("Min", spawner.timeRangeMin, 2, spawner.timeRangeMax);
        spawner.timeRangeMax = EditorGUILayout.Slider("Min", spawner.timeRangeMax, spawner.timeRangeMax, 10);

        GUILayout.EndHorizontal();
    }
}
