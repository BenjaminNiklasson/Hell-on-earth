using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 3f;
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
