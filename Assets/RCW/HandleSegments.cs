using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandleSegments : MonoBehaviour
{
    [Header("Rope Parameters")]
    [SerializeField] private GameObject Segment;
    [SerializeField] private int amount = 1;
    [SerializeField] private Transform spawn_position;
    [SerializeField] public static List<GameObject> segments = new List<GameObject>();
    GameObject segment_tempo;

    public void addSegment(){
        for(int i = 0; i < amount; i++){
            segment_tempo = Instantiate(Segment);
            segment_tempo.GetComponent<SegmentPhysics>().id = segments.Count;
            if(segments.Count >= 1)
                segment_tempo.transform.position = positionSegment();
            else
                segment_tempo.transform.position = spawn_position.position;
            segments.Add(segment_tempo);
        }
    }

    Vector3 positionSegment(){
        int size = segments.Count;
        Vector3 position = segments[size-1].transform.position + new Vector3(0f, -1f, 0f);
        return position;
    }

    public void clearSegment(){
	foreach(GameObject segment in segments)
		DestroyImmediate(segment);
	segments.Clear();
    }

}
