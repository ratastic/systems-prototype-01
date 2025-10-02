using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalTrigger : MonoBehaviour
{
    public PlayerGetHit playerGetHit;
    public Rigidbody2D playerRb;
    public GameObject restartButton;
    public GameObject finalText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finalText.SetActive(false);
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
        restartButton.SetActive(true);
        finalText.SetActive(true);
    }
}
