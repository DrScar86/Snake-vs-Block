using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.z = Target.position.z - 2;
        transform.position = transformPosition;
    }
}
