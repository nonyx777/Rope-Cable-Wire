using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DistanceJoint : MonoBehaviour
{
    [Header("Distance-Joint Parameters")]
    [SerializeField] private float length = 5f;
    [SerializeField] private float strength;
    void Start(){

    }
    
    void Update(){
        for(int i = 0; i < HandleSegments.segments.Count; i++){
            if(i+1 >= HandleSegments.segments.Count)
                return;
            int j = i+1;
            Vector3 offsetVec = distanceResolver(HandleSegments.segments[i].transform.position,
                                HandleSegments.segments[j].transform.position);

            if(HandleSegments.segments[i].GetComponent<SegmentPhysics>().id != 0)
                HandleSegments.segments[i].transform.position += offsetVec * strength;;
            HandleSegments.segments[j].transform.position += -offsetVec * strength;
        }
    }

    Vector3 distanceResolver(Vector3 pos1, Vector3 pos2){
        Vector3 displacement = pos1 - pos2;
        float distance = Vector3.Magnitude(displacement);
        float offsetFloat = (length - distance)/100f/2f;
        Vector3 offsetVec = displacement * offsetFloat;

        return offsetVec;
    }
}
