using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerGetHit : MonoBehaviour
{
    public SpriteRenderer circle;
    private Rigidbody2D rb;
    public Color newColor;
    public GameObject restartButton;
    public CinemachineImpulseSource playerHit;
    public AudioSource sizzle;
    public GameObject steamEffect;
    public JumpController jumpController;
    public bool evaporated = false;
    private Vector3 evaporatedWater = new Vector3(0f, 0f, 0f);
    public TextMeshProUGUI finalText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        circle = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        restartButton.SetActive(false);
        steamEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float currentScale = jumpController.trans.localScale.x; 
        UpdateStatus(currentScale);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        // death logic
        if (col.gameObject.CompareTag("fire") && evaporated == true)
        {
            circle.color = newColor;
            rb.gravityScale = 0;
            rb.bodyType = RigidbodyType2D.Static;
            restartButton.SetActive(true);
            CameraRumble.instance.CameraShaking(playerHit);
            sizzle.Play();
            steamEffect.SetActive(true);
        }
        // shrink logic
        if (col.gameObject.CompareTag("fire"))
        {
            jumpController.trans.localScale -= new Vector3(.5f, .5f, .5f);
            CameraRumble.instance.CameraShaking(playerHit);
            sizzle.Play();

            if (jumpController.trans.localScale == evaporatedWater)
            {
                evaporated = true;
                circle.color = newColor;
                rb.gravityScale = 0;
                rb.bodyType = RigidbodyType2D.Static;
                restartButton.SetActive(true);
                CameraRumble.instance.CameraShaking(playerHit);
                sizzle.Play();
                steamEffect.SetActive(true);
            }
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void UpdateStatus(float scale)
    {
        if (scale <= 1.5f)
        {
            finalText.text = "the flower appreciates your effort... smh";
        }
        else if (scale <= 3f)
        {
            finalText.text = "the flower is probably satisfied";
        }
        else if (scale <= 5f)
        {
            finalText.text = "the flower is decently watered";
        }
        else if (scale < 6.5f)
        {
            finalText.text = "the flower is nourished";
        }
        else if (scale >= 6.5f)
        {
            finalText.text = "the flower is nourished and happy";
        }
    }
}
