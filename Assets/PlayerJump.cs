using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{



    public Rigidbody2D rb;
    private float NextJump;
    public float jump_speed = 0.5f;
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 10;
    void Update()
    {
        if (Input.GetKeyDown("space")&& Time.time>NextJump)
        {
            NextJump = Time.time + jump_speed;
           rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }
        if(rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }
}



