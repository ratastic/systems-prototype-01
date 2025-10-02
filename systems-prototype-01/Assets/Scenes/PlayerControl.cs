using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashDuration = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;
    //public bool isGrounded = true;

    //private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        //moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.linearVelocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashDuration;
                //anim.SetBool("isSpinning", true);
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
    // public void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.gameObject.CompareTag("platform"))
    //     {
    //         Debug.Log("touching a platform");
    //         //isGrounded = true;
    //     }
    // }

    // void OnCollisionStay2D(Collision2D col)
    // {
    //     if (col.gameObject.CompareTag("platform"))
    //     {
    //         isGrounded = true;
    //     }
    // }

    // void OnCollisionExit2D(Collision2D col)
    // {
    //     if (col.gameObject.CompareTag("platform"))
    //     {
    //         isGrounded = false;
    //         Debug.Log("Left platform");
    //     }
    // }
}
