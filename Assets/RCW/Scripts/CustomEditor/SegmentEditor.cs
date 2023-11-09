using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SegmentPhysics))]
public class SegmentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SegmentPhysics segmentPhysics = (SegmentPhysics) target;
        if(GUILayout.Button("Pin Segment"))
            segmentPhysics.pinSegment();
    }
}
