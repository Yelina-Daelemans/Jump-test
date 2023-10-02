using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class Walking : MonoBehaviour
{
    private bool isFacingRight = true;
    private Rigidbody2D Rb;

    [SerializeField] float Speed = 5f;
    [SerializeField] float gravityScale = 5f;
    [SerializeField] float Fall = 15f;
    [SerializeField] float Jumpheight = 5f;


    //public static event Action PointsPickedUp = delegate { };


    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Rb.velocity = new Vector2(Input.GetAxis("Horizontal")*Speed, Rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rb.gravityScale = gravityScale;
            float Jump = Mathf.Sqrt(Jumpheight * (Physics2D.gravity.y * Rb.gravityScale) * -2) * Rb.mass;
            Rb.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
        }
        if(Rb.velocity.y > 0)
        {
            Rb.gravityScale = gravityScale;
        }
        else
        {
            Rb.gravityScale = Fall;
        }
        Flip();
    }
    private void Flip()
    {
        if (isFacingRight && Rb.velocity.x < 0f || !isFacingRight && Rb.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }    
}
