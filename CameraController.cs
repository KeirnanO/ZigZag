using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    Vector3 offset;

    void Awake()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position .x + offset.x, offset.y, target.position.z + offset.z);
    }
}
