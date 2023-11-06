using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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


    // Start is called before the first frame update
    void Start()
    {
        physics = false;
        previous = transform.position + previous;
    }

    // Update is called once per frame
    void Update()
    {
        if (!physics || id == 0 || pinned)
            return;

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
}
