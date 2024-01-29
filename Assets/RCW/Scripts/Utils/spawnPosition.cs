using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPosition : MonoBehaviour
{
    [SerializeField] private Color color = Color.green;
    [Range(1, 10)]
    [SerializeField] private float radius = 1f;

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
