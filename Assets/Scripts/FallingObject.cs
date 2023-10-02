using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
            rb.isKinematic = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
            Debug.Log("Got you!");
    }

}
