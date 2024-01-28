using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandleSegments : MonoBehaviour
{
    [Header("Rope Parameters")]
    [SerializeField] private GameObject Segment;
    [SerializeField] private Transform spawn_start;
    [SerializeField] private Transform spawn_end;
    [SerializeField] private GameObject segment_parent;
    public static List<GameObject> segments = new List<GameObject>();
    GameObject segment_tempo;

    public void addSegment()
    {
        //depends on whether there is a segment before or if it's the first
        Vector3 spawn_origin = segments.Count > 0 ? 
                segments[segments.Count - 1].transform.position : 
                spawn_start.position;

        //direction in which the segments will spawn towards
        //and other required vectors
        Vector3 displacement = spawn_end.position - spawn_origin;
        Vector3 spawn_direction = displacement.normalized;
        int distance = (int) Vector3.Magnitude(displacement);

        int num_of_segments = distance / (int) Segment.transform.localScale.y;

        for(int i = 0; i < num_of_segments; i++){
            segment_tempo = Instantiate(Segment);
            segment_tempo.GetComponent<SegmentPhysics>().id = segments.Count;

            segment_tempo.transform.position = positionSegment(spawn_direction);
            segment_tempo.transform.parent = segment_parent.transform;
            segments.Add(segment_tempo);
        }
    }

    Vector3 positionSegment(Vector3 spawn_direction)
    {
        int size = segments.Count;
        if(size < 1)
            return spawn_start.position;
        
        Vector3 position = segments[size - 1].transform.position + (spawn_direction * Segment.transform.localScale.y);
        return position;
    }

    public void clearSegment()
    {
        foreach (GameObject segment in segments)
            DestroyImmediate(segment);

        segments.Clear();
    }

}
