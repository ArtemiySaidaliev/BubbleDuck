using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float movement;
    public float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
   

    void FixedUpdate()
    {
        movement = Input.acceleration.x;

         if(movement > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if(movement < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }


}
