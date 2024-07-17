using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CameraShake : MonoBehaviour
{
    public Camera mainCamera;
    public static Action shake;
    public static Action shakeharder;
    public static Action stopsk;
    
    Vector3 cameraPos;

    [SerializeField][Range(0.01f, 0.1f)] float shakeRange = 0.05f;
    [SerializeField][Range(0.1f, 1f)] float duration = 0.5f;

    public void Shake1()
    {
        cameraPos = mainCamera.transform.position;
        InvokeRepeating("StartShake", 0f, 0.005f);
        Debug.Log("Camerashake");
        Invoke("StopShake", duration);
    }
    public void Shake2()
    {

        cameraPos = mainCamera.transform.position;
        InvokeRepeating("StartShake2", 0f, 0.005f);
        Debug.Log("Camerashake");
        Invoke("StopShake", duration);
    }
    void StartShake()
    {
        float cameraPosX = UnityEngine.Random.value * shakeRange * 2 - shakeRange;
        float cameraPosY = UnityEngine.Random.value * shakeRange * 2 - shakeRange;
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x = cameraPosX;
        cameraPos.y = cameraPosY;
        mainCamera.transform.position = cameraPos;


    }
    void StartShake2()
    {
        float cameraPosX = UnityEngine.Random.value * shakeRange * 5 - shakeRange;
        float cameraPosY = UnityEngine.Random.value * shakeRange * 5 - shakeRange;
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x = cameraPosX;
        cameraPos.y = cameraPosY;
        mainCamera.transform.position = cameraPos;


    }
    void StopShake()
    {
        CancelInvoke("StartShake");
        mainCamera.transform.position = cameraPos;
    }
    void StopShake2()
    {
        CancelInvoke("StartShake2");
        mainCamera.transform.position = cameraPos;
    }


    void Awake()
    {
        shake = () => { Shake1(); };
        shakeharder= () => { Shake2(); };
        stopsk = () => { StopShake2(); };
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
