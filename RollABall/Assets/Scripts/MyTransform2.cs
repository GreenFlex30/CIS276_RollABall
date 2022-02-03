using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTransform2 : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector3.zero);
    }
}
