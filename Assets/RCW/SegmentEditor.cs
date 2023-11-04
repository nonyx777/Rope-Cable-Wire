using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DistanceJoint))]
public class SegmentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DistanceJoint distanceJoint = (DistanceJoint) target;
        if(GUILayout.Button("Add Segment"))
            distanceJoint.addSegment();
	if(GUILayout.Button("Clear Segment"))
	    distanceJoint.clearSegment();
    }
}
