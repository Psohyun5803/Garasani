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


public class kwangemo : MonoBehaviour
{
    private Image imageComponent;
    public Sprite[] sprite;
    public TMP_Text who;

    public GameObject talksqu;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
        imageComponent.enabled = false; // ÀÌ¹ÌÁö ÄÄÆ÷³ÍÆ® ºñÈ°¼ºÈ­ 
    }

    // Update is called once per frame
    void Update()
    {

        if (talksqu.activeSelf && who.text == "±¤¼®¿±")
        {
            imageComponent.enabled = true;
            if (DialogueManager.kwangemoflag != null)
            {
                imageComponent.sprite = sprite[DialogueManager.kwangemoflag];
                Debug.Log(DialogueManager.kwangemoflag);
            }

        }
        else
        {
            imageComponent.enabled = false;
        }
    }

}
