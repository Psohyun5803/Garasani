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

public class train1_dark : MonoBehaviour
{

    string[] station1talk = new string[5] { "지훈엄마!!","정민!","PL!","지훈살려주세요!!","지훈살려주세요!!!!" };
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject dark;
    public GameObject image01;
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
    public static int index = 0;
    int optnum = 0;
    int darkflag = 0;
    // Start is called before the first frame update
    void Start()
    {
        image01.SetActive(false);
        dark.SetActive(true);
        talksqu.SetActive(true);
        who.text = "지훈";
        content.text = "엄마!!";
        button.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttondown()
    {
        if(darkflag==1)
        {
            who.text = "system";
            content.fontSize = 3;
            content.text = "안내 말씀드립니다. 저희 열차는 ....";
            button.SetActive(false);
            //씬이동이 들어갈 곳 
        }
        else
        {
            index++;
            if (index > 4)
            {

                if (optnum == 0)
                {

                    who.text = "player";
                    content.text = "";
                    talksqu.SetActive(true);
                    options.SetActive(true);
                    option3_bt.SetActive(false);
                    option4_bt.SetActive(false);
                    option5_bt.SetActive(false);
                    option6_bt.SetActive(false);

                    button.SetActive(false);
                    option1.text = "> 우리가 꼭 찾아줄게";
                    option2.text = "> 이제 거의 다 왔어";
                }
                else
                {
                    talksqu.SetActive(false);


                    content.text = "";
                    dark.SetActive(false);
                    StartCoroutine(endofdark());
                    if(image01.activeSelf)
                    {
                        image01.SetActive(false);
                    }
                }





            }
            else
            {
                if (station1talk[index].Substring(0, 2) == "PL")
                {
                    who.text = "player";
                }
                else
                {
                    who.text = station1talk[index].Substring(0, 2);
                }
                content.text = station1talk[index].Substring(2);
                Debug.Log(content.text = station1talk[index].Substring(2));
            }
        }

            
    }
        


    
    public void opt2()

    {

        option1.text = "";
        option2.text = "";

        if (option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
        }
        if (option4_bt != null && option4_bt.activeSelf)
        {
            if (option4 != null)
            {
                option4.text = "";
            }
        }
        if (option5_bt != null && option5_bt.activeSelf)
        {
            if (option5 != null)
            {
                option5.text = "";
            }
        }
        if (option6_bt != null && option6_bt.activeSelf)
        {
            if (option6 != null)
            {
                option6.text = "";
            }
        }
        optnum = 1;
        who.text = "정민";
        content.text = "....";
        button.SetActive(true); 
    }
    public void opt1()
    {

        option1.text = "";
        option2.text = "";

        if (option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
        }
        if (option4_bt != null && option4_bt.activeSelf)
        {
            if (option4 != null)
            {
                option4.text = "";
            }
        }
        if (option5_bt != null && option5_bt.activeSelf)
        {
            if (option5 != null)
            {
                option5.text = "";
            }
        }
        if (option6_bt != null && option6_bt.activeSelf)
        {
            if (option6 != null)
            {
                option6.text = "";
            }
        }
        optnum = 2;
        image01.SetActive(true);
        who.text = "지훈";
        content.text = "....";
        button.SetActive(true);
    }
    private IEnumerator endofdark()
    {
        yield return new WaitForSeconds(2f);
        CameraShake.shake();
        talksqu.SetActive(true);
        options.SetActive(false);
        who.text = "system";
        content.fontSize=7;
        content.text = "쾅!";
        button.SetActive(true);
        darkflag = 1;
       
        
    }
}
