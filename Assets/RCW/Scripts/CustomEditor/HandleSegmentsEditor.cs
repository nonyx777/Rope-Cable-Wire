using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HandleSegments))]
public class HandleSegmentsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        HandleSegments handleSegments = (HandleSegments)target;
        if (GUILayout.Button("Add Segment"))
            handleSegments.addSegment();
        if (GUILayout.Button("Clear Segment"))
            handleSegments.clearSegment();
        if (GUILayout.Button("Display Segment"))
            SegmentPhysics.displaySegment();
    }
}
