using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerGetHit : MonoBehaviour
{
    private SpriteRenderer circle;
    private Rigidbody2D rb;
    public Color newColor;
    public GameObject restartButton;
    public CinemachineImpulseSource playerHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        circle = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("fire"))
        {
            circle.color = newColor;
            rb.gravityScale = 0;
            rb.bodyType = RigidbodyType2D.Static;
            restartButton.SetActive(true);
            CameraRumble.instance.CameraShaking(playerHit);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
