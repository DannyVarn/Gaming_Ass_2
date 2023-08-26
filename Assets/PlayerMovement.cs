using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public Rigidbody2D rb;
    public float movement =0f;
    float smooth = 5.0f;
    
    [SerializeField] public Animator animator;
    public float jumpAmount = 35;
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0 )
        {
                // Rotate the cube by converting the angles into a quaternion.
            rb.velocity = new Vector2(movement * moveSpeed,rb.velocity.y);
            
        }
        if (movement<0){
            rb.velocity = new Vector2(movement * moveSpeed,rb.velocity.y);

        }
        animator.SetFloat("Move Speed",Mathf.Abs(movement));

    }

    void FixedUpdate()
    {
        if (movement > 0 )
        {
                // Rotate the cube by converting the angles into a quaternion.
           
            float tiltAroundZ = 0;
            float tiltAroundX = 0;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        }
        if (movement<0){
           
            float tiltAroundZ = 180;
            float tiltAroundX = 180;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);

        }
        // if (movement.x > 0 || movement.x<0)
        // {
        //     rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        // }
            
    }
}
