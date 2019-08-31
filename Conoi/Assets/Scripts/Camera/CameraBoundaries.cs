using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public float up, down, left, right;
    void Update()
    {
        LockCamera();
    }

    void LockCamera()
    {
        if (transform.position.y > up)
        {
            transform.position = new Vector3(transform.position.x, up, transform.position.z);
        }
        if (transform.position.y < down)
        {
            transform.position = new Vector3(transform.position.x, down, transform.position.z);
        }
        if (transform.position.x < left)
        {
            transform.position = new Vector3(left, transform.position.y, transform.position.z);
        }
        if (transform.position.x > right)
        {
            transform.position = new Vector3(right, transform.position.y, transform.position.z);
        }
    }
}
