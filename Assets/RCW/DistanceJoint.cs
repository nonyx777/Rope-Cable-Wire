using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceJoint : MonoBehaviour
{
    [Header("Rope Parameters")]
    List<GameObject> segments = new List<GameObject>();
    [SerializeField] private GameObject Segment;
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
        segment_tempo = Instantiate(Segment);
        segments.Add(segment_tempo);
    }
}
