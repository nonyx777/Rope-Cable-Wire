using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentPhysics : MonoBehaviour
{
    [Header("Segment Parameters")]
    [SerializeField] private Renderer rendererComponent;
    public Rigidbody rb;
    private Vector3 previous;
    private Vector2 current;
    private static bool display_segment;
    public int id;
    private Vector3 velocity;
    public static bool physics;
    public bool pinned;


    // Start is called before the first frame update
    void Start()
    {
        previous = rb.position + previous;
        display_segment = true;
    }

    // Update is called once per frame
    void Update()
    {
        rendererComponent.enabled = display_segment;
        rb.useGravity = physics && !pinned;
    }

    void FixedUpdate()
    {
        if (!physics || pinned)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            previous = rb.position;
            return;
        }
        integrate();
    }

    void integrate()
    {
        velocity = rb.position - previous;

        current = rb.position;

        rb.MovePosition(rb.position + velocity);

        previous = current;

        //reset
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
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
}
