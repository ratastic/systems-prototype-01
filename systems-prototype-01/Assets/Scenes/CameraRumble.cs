using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class CameraRumble : MonoBehaviour
{
    public static CameraRumble instance;
    [SerializeField] private float shakeForce = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CameraShaking(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(shakeForce);
    }
}
