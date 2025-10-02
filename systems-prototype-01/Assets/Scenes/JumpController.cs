using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpController : MonoBehaviour
{
    public float jumpForce;
    public float moveForce;
    private Rigidbody2D rb2d;
    public bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementOne();
        //MovementTwo();

    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
            Debug.Log("player is grounded");
        }
        else
        {
            isGrounded = false;
        }
    }

    public void MovementOne()
    {
        if (Input.GetKeyDown("d"))
        {
            rb2d.linearVelocity = new Vector2(moveForce, rb2d.linearVelocity.y);
        }

        if (Input.GetKeyDown("a"))
        {
            rb2d.linearVelocity = new Vector2(-moveForce, rb2d.linearVelocity.y);
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("shift is pressed");
            float finalJumpForce = jumpForce;
            if (Input.GetKey(KeyCode.RightShift))
            {       
                finalJumpForce *= .8f;
                Debug.Log("boost activated");
            }
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, finalJumpForce);
            isGrounded = false;
        }
    }

    // public void MovementTwo()
    // {
    //     Vector2 moveDirection = Vector2.zero;

    //     if (Input.GetKey("d"))
    //     {
    //         moveDirection = Vector2.right;
    //     }
    //     else if (Input.GetKey("a"))
    //     {
    //         moveDirection = Vector2.left;
    //     }

    //     if (dashCounter > 0)
    //     {
    //         rb2d.linearVelocity = moveDirection * dashSpeed;
    //         dashCounter -= Time.deltaTime;

    //         if (dashCounter <= 0)
    //         {
    //             dashCoolCounter = dashCooldown;
    //         }
    //         } else {
    //             rb2d.linearVelocity = moveDirection * moveForce;
    //         }

    //     if (isGrounded && Input.GetKeyDown(KeyCode.Space))
    //     {
    //         rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
    //         isGrounded = false;
    //     }

    //     if (Input.GetKeyDown(KeyCode.RightShift))
    //     {
    //         if (dashCoolCounter <= 0 && dashCounter <= 0)
    //         {
    //             dashCounter = dashDuration;
    //         }
    //     }

    //     if (dashCoolCounter > 0)
    //     {
    //         dashCoolCounter -= Time.deltaTime;
    //     }
    // }
}
