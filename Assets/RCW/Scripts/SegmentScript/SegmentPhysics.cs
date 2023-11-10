using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentPhysics : MonoBehaviour
{
    [Header("Segment Parameters")]
    [SerializeField] private Vector3 gravity;
    [SerializeField] private float damping;
    [SerializeField] private Vector3 acceleration;
    [SerializeField] private Vector3 previous;
    public int id;
    private Vector3 current;
    private Vector3 velocity;
    public static Boolean physics;
    public Boolean pinned;

    //temporary
    private const float masss = 5f;

    // Start is called before the first frame update
    void Start()
    {
        physics = false;
        previous = transform.position + previous;
    }

    // Update is called once per frame
    void Update()
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
        acceleration += gravity;

        current = transform.position;

        velocity = current - previous;
        velocity *= 1f - damping * Time.deltaTime;

        transform.position += velocity + acceleration * Time.deltaTime * Time.deltaTime;
        previous = current;

        acceleration = new Vector3(0f, 0f, 0f);
    }

    public static void enablePhysics()
    {
        physics = true;
    }
    public static void disablePhysics()
    {
        physics = false;
    }

    public void pinSegment()
    {
        pinned = !pinned;
    }

    void OnTriggerEnter(Collider other)
    {
        penetrationResolution(other);
    }

    //TODO: fix smoothness of the resolution
    void penetrationResolution(Collider other)
    {
        //storing radius and mass of the objects
        //this object
        float this_radius = GetComponent<SphereCollider>().radius;
        float this_mass = GetComponent<Rigidbody>().mass;
        //other object
        float other_radius = other.GetComponent<SphereCollider>().radius;
        float other_mass = other.GetComponent<Rigidbody>().mass;

        Vector3 collision_normal = transform.position - other.transform.position;
        float penetration_distance = (this_radius + other_radius) - collision_normal.magnitude;
        Vector3 penetration_resolution_vector = collision_normal.normalized * penetration_distance / (this_mass + other_mass);

        transform.position += -penetration_resolution_vector * 1/masss;
    }
}
