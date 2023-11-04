using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSegments : MonoBehaviour
{
    [Header("Rope Parameters")]
    [SerializeField] private GameObject Segment;
    [SerializeField] private int amount = 1;
    [SerializeField] List<GameObject> segments = new List<GameObject>();
    GameObject segment_tempo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addSegment(){
        for(int i = 0; i < amount; i++){
            segment_tempo = Instantiate(Segment);
            if(segments.Count >= 1)
                segment_tempo.transform.position = positionSegment();
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
