using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    public PlayerGetHit playerGetHit;
    public Rigidbody2D playerRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        playerRb.gravityScale = 0;
        playerRb.bodyType = RigidbodyType2D.Static;
        playerGetHit.circle.color = playerGetHit.newColor;
    }
}
