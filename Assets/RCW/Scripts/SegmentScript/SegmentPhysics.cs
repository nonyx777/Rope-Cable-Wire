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

    //.... :)
    private Vector3 constant_vector = new Vector3(1f, 1f, 1f);


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
        velocity *= (1f - damping * Time.deltaTime);

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
        print("Triggered");
    }

    //TODO: implement algorithm
    void penetrationResolution(Collider other)
    {
        //collision_normal = transform.position - other.position;
        //penetration_distance = (transform.radius + other.radius) - displacement.magnitude();
        //penetration_resolution_vector = collision_normal.magnitude() * penetration_distance/this.mass + other.mass
        //transform.position = penetration_resolution_vector * this.inversemass;
        //other.position = penetration_resolition_vector * other.inversemass;
    }
}
