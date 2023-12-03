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
    public Rigidbody rb;
    [SerializeField] private Vector3 previous;
    private Vector3 acceleration;
    private static bool display_segment;
    public int id;
    private Vector3 velocity;
    public static bool physics;
    public bool pinned;

    private Vector3 contact_position;
    private Vector3 segment_position;


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

        Vector3 currentPosition = rb.position;

        rb.MovePosition(rb.position + velocity);

        previous = currentPosition;

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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(contact_position, 0.5f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(segment_position, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(previous, 0.5f);

    }
}
