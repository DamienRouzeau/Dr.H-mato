using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLookAt : MonoBehaviour
{
    int speed = 1;
    Vector3 initialPosition;
    private void Start()
    {
        initialPosition = transform.position;
    }
    private void FixedUpdate()
    {
        transform.position += Vector3.forward * speed;
        if (transform.position.z >= initialPosition.z + 50)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Item"))
        {
            Destroy(this.gameObject);
        }
    }
}
