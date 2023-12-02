using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentPhysics : MonoBehaviour
{
    [Header("Segment Parameters")]
    [SerializeField] private float gravity;
    [SerializeField] private float damping;
    [SerializeField] private Renderer rendererComponent;
    [SerializeField] private Vector3 previous;
    private Vector3 acceleration;
    private static bool display_segment;
    public int id;
    private Vector3 velocity;
    public static bool physics;
    public bool pinned;

    // Start is called before the first frame update
    void Start()
    {
        // rendererComponent = GetComponent<Renderer>();
        physics = false;
        previous = transform.position + previous;
    }

    // Update is called once per frame
    void Update()
    {
        rendererComponent.enabled = display_segment;
    }

    void FixedUpdate()
    {
        if (!physics || pinned)
        {
            previous = transform.position;
            return;
        }
        integrate();
    }

    void integrate()
    {
        acceleration += gravity * Vector3.down;

        velocity = transform.position - previous;
        velocity *= 1f - damping * Time.deltaTime;

        previous = transform.position;

        transform.position += velocity + acceleration * Time.fixedDeltaTime * Time.fixedDeltaTime;

        acceleration = Vector3.zero;
    }

    public static void enablePhysics()
    {
        physics = true;
    }
    public static void disablePhysics()
    {
        physics = false;
    }
    public static void displaySegment()
    {
        display_segment = !display_segment;
    }

    public void pinSegment()
    {
        pinned = !pinned;
    }


    void OnTriggerEnter(Collider other)
    {
        penetrationResolution(other);
    }

    //TODO: when segment inside object, shoot segment outside
    void penetrationResolution(Collider other)
    {
        if (other.GetComponent<SphereCollider>())
        {
            Vector3 tempo = previous;
            previous = transform.position;
            transform.position = tempo;

            //storing radius of the objects
            //this object
            // float this_radius = transform.localScale.x / 2f;
            //other object
            // float other_radius = other.transform.localScale.x / 2f;

            // float minimal_distance = this_radius + other_radius;
            // Vector3 collision_normal = transform.position - other.transform.position;
            // float distance = collision_normal.magnitude;

            // if (distance < minimal_distance)
            // {
            //     Vector3 n = collision_normal / distance;
            //     Vector3 tempo2 = transform.position - 0.5f * n;
            //     previous = transform.position = tempo2;
            // }
        }
    }
}
