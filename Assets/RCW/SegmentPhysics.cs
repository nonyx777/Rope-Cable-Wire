using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SegmentPhysics : MonoBehaviour
{
    [Header("Segment Parameters")]
    [SerializeField] private Vector3 gravity;
    [SerializeField] private Vector3 acceleration;
    [SerializeField] private Vector3 previous;
    private Vector3 current;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        integrate();
    }

    void integrate()
    {
        acceleration += gravity;

        current = transform.position;
        velocity = current - previous;
        transform.position += velocity + acceleration * Time.deltaTime * Time.deltaTime;
        previous = current;

        acceleration = new Vector3(0f, 0f, 0f);
    }
}
