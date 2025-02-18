using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public float heightOffset = 0.01f;

    void Start()
    {
        Vector3 position = transform.position;
        position.y += heightOffset;
        transform.position = position;
    }

}
