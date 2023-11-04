using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HandleSegments))]
public class SegmentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        HandleSegments handleSegments = (HandleSegments) target;
        if(GUILayout.Button("Add Segment"))
            handleSegments.addSegment();
        if(GUILayout.Button("Clear Segment"))
            handleSegments.clearSegment();
        }
}
