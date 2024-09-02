using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Net.Mail;
using TMPro;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System;

public class jihoonemo : MonoBehaviour
{

    private Image imageComponent;
    public Sprite[] sprite;
    public TMP_Text who;

    public GameObject talksqu;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
        imageComponent.enabled = false; // 이미지 컴포넌트 비활성화 
    }

    // Update is called once per frame
    void Update()
    {
        if (talksqu.activeSelf && who.text == "지훈")
        {
            imageComponent.enabled = true;
            imageComponent.sprite = sprite[1];
            Debug.Log("Parent is active .");
        }
        else
        {
            imageComponent.enabled = false;
        }
    }
}
