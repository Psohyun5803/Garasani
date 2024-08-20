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

public class stair1 : MonoBehaviour
{
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject button;
    public TMP_Text who;
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;
    public TMP_Text option4;
    public TMP_Text option5;
    public TMP_Text option6;
    //
    //public TMP_Text exit;

    public GameObject options;
    public GameObject option3_bt;
    public GameObject option4_bt;
    public GameObject option5_bt;
    public GameObject option6_bt;
    // Start is called before the first frame update


    private void OnCollisionEnter2D(Collision2D collision)
    {


       
            if (gameObject.name == "1호선계단")
            {
               
                talksqu.SetActive(true);
                options.SetActive(false);
                option3_bt.SetActive(false);
                button.SetActive(true);
                who.text = "player";
                content.text = "열차를 타야할 것 같다.";
            }



        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
