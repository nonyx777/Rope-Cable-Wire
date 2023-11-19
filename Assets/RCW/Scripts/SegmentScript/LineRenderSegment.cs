using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderSegment : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        updateLineRenderer();
    }

    public void updateLineRenderer()
    {
        lineRenderer.positionCount = HandleSegments.segments.Count;

        for (int i = 0; i < HandleSegments.segments.Count; i++)
        {
            lineRenderer.SetPosition(i, HandleSegments.segments[i].transform.position);
        }
    }
}
