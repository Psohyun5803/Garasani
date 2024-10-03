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

public class jungminemo : MonoBehaviour
{
    private Image imageComponent;
    public Sprite[] sprite;
    public TMP_Text who;





    public GameObject talksqu;
    






    void Start()
    {
        imageComponent=GetComponent<Image>();
        imageComponent.enabled = false;
        //if()
        //talksqu=GameObject.Find("말풍선");
       
       
       

    }
  
    
  

    // Update is called once per frame
    void Update()
    {
        // 현재 오브젝트의 부모 오브젝트를 가져옵니다.
        if (talksqu != null && who.text != null)  // null 체크 추가
        {
            
            if (talksqu.activeSelf && who.text.TrimEnd()== "정민")
            {
                imageComponent.enabled = true;
                if (DialogueManager.jungminemoflag != null)
                {
                    imageComponent.sprite = sprite[DialogueManager.jungminemoflag];
                }
            }
            else
            {
                imageComponent.enabled = false;
            }
        }
        if(who.text!="정민")
        {
            imageComponent.enabled = false;
        }
/*
        if (talksqu.activeSelf && who.text.Trim() == "정민")
        {
            imageComponent.enabled = true;
            if (DialogueManager.jungminemoflag != null)
            {
                imageComponent.sprite = sprite[DialogueManager.jungminemoflag];
            }
          
        }
        else
        {
            imageComponent.enabled = false;
        }

        */




    }
}
