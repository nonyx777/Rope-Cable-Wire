using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DistanceJoint : MonoBehaviour
{
    [Header("Distance-Joint Parameters")]
    [SerializeField] private float length;

    void FixedUpdate()
    {
        for (int i = 0; i < 20; i++)
            handleResolver();
    }

    Vector3 distanceResolver(Vector3 pos1, Vector3 pos2)
    {
        Vector3 displacement = pos1 - pos2;
        float distance = Vector3.Magnitude(displacement);
        float offsetFloat = (length - distance) / 2f;
        Vector3 offsetVec = displacement.normalized * offsetFloat;

        return offsetVec;
    }

    void handleResolver()
    {
        for (int i = 0; i < HandleSegments.segments.Count; i++)
        {
            if (i + 1 >= HandleSegments.segments.Count)
                return;
            int j = i + 1;
            Vector3 position1 = HandleSegments.segments[i].GetComponent<SegmentPhysics>().rb.position;
            Vector3 position2 = HandleSegments.segments[j].GetComponent<SegmentPhysics>().rb.position;


            Vector3 offsetVec = distanceResolver(position1, position2);

            if (HandleSegments.segments[i].GetComponent<SegmentPhysics>().pinned == false)
            {
                HandleSegments.segments[i].GetComponent<SegmentPhysics>().rb.MovePosition(position1 + offsetVec);
            }
            if (HandleSegments.segments[j].GetComponent<SegmentPhysics>().pinned == false)
            {
                HandleSegments.segments[j].GetComponent<SegmentPhysics>().rb.MovePosition(position2 - offsetVec);
            }
        }
    }
}
