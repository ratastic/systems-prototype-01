using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;

public class JumpController : MonoBehaviour
{
    public float jumpForce;
    public float moveForce;
    private Rigidbody2D rb2d;
    public bool isGrounded;
    private bool hasBoosted = false;
    public AudioSource slosh;
    public Transform trans;
    private Vector3 startScale = new Vector3(1f, 1f, 1f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        trans.localScale = startScale;
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
            hasBoosted = false;
            Debug.Log("player is grounded");
        }
        else
        {
            isGrounded = false;
        }

        if (col.gameObject.CompareTag("water"))
        {
            trans.localScale += new Vector3(.5f, .5f, .5f);
            slosh.Play();
            col.gameObject.SetActive(false);
        }
    }

    public void MovementOne()
    {
        if (Input.GetKeyDown("d"))
        {
            rb2d.linearVelocity = new Vector2(moveForce, rb2d.linearVelocity.y);
            //slosh.Play();
        }

        if (Input.GetKeyDown("a"))
        {
            rb2d.linearVelocity = new Vector2(-moveForce, rb2d.linearVelocity.y);
            //slosh.Play();
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            isGrounded = false;
            slosh.Play();
        }

        if (!isGrounded && !hasBoosted && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("shift is pressed");
            slosh.Play();
            float finalJumpForce = jumpForce;
            if (Input.GetKey(KeyCode.RightShift))
            {
                finalJumpForce *= .8f;
                Debug.Log("boost activated");
                hasBoosted = true;
            }
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, finalJumpForce);
            isGrounded = false;
        }
    }
}
