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
    //temporary
    private const float masss = 10f;

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

        transform.position += velocity + acceleration * Time.deltaTime * Time.deltaTime;

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
        collisionResolution(other);
    }

    //TODO: fix smoothness of the resolution
    void collisionResolution(Collider other)
    {
        //storing radius and mass of the objects
        //this object
        float this_radius = GetComponent<SphereCollider>().radius;
        float this_mass = GetComponent<Rigidbody>().mass;
        //other object
        float other_radius = other.GetComponent<SphereCollider>().radius;
        float other_mass = other.GetComponent<Rigidbody>().mass;

        Vector3 collision_normal = transform.position - other.transform.position;
        float penetration_distance = collision_normal.magnitude;

        Vector3 n = collision_normal.normalized;
        float delta = ((this_radius + other_radius) - penetration_distance);

        transform.position -= 0.5f * delta * n;
        // previous = transform.position;
    }
}
