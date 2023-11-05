using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DistanceJoint))]
public class SegmentPhysicsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(GUILayout.Button("Enable Physics"))
            SegmentPhysics.enablePhysics();
        if(GUILayout.Button("Disable Physics"))
            SegmentPhysics.disablePhysics();
    }
}
