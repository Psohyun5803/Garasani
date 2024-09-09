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

    string[] station1talk = new string[5] { "지훈3엄마!!","정민1!","PL!","지훈3살려주세요!!","지훈3살려주세요!!!!" };
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject dark;
    public GameObject image01;
    public GameObject image02;

    public GameObject gif01;
    public GameObject gif02;
    public Image gif03;
    public GameObject button;
    public TMP_Text who;
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;
    public TMP_Text option4;
    public TMP_Text option5;
    public TMP_Text option6;
    //
    public static int jihoonemodark =0;
    public static int jungminemodark = 0;
    //public TMP_Text exit;

    public GameObject options;
    public GameObject option3_bt;
    public GameObject option4_bt;
    public GameObject option5_bt;
    public GameObject option6_bt;
    public static int index = 0;
    int optnum = 0;
    int darkflag = 0;
    public float fadeDuration = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("에잉?");
        image01.SetActive(false);
        image02.SetActive(false);
        dark.SetActive(true);
        talksqu.SetActive(true);
        who.text = "지훈";
        content.text = "엄마!!";
        jihoonemodark = 3;
        textani.npconClickAction();
        button.SetActive(true);
        Player.moveflag = 0;
        
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
          
            StartCoroutine(TransitionToScene());
            //씬이동이 들어갈 곳 
        }
        else
        {
            index++;
            if (index > 4)
            {

                if (optnum == 0)
                {

                    who.text = customize.playername;
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
                    who.text = customize.playername;
                    content.text = station1talk[index].Substring(2);
                }
                else
                {
                    who.text = station1talk[index].Substring(0, 2);
                    if(who.text=="정민")
                    {
                        jungminemodark = int.Parse(station1talk[index].Substring(2, 1));
                        content.text = station1talk[index].Substring(3);
                      
                        
                    }
                    else if(who.text=="지훈")
                    {
                        jihoonemodark = int.Parse(station1talk[index].Substring(2, 1));
                        content.text = station1talk[index].Substring(3);
                        
                    }
                  
                   
                }
               
            }
        }

            
    }
    IEnumerator TransitionToScene()
    {

        // 2초 대기
        
        yield return new WaitForSeconds(2f);
        talksqu.SetActive(false);
        image02.SetActive(true);
        StartCoroutine(gifplayer());
        StartCoroutine(FadeInAndOut());
        // 지정된 씬으로 이동
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator gifplayer()
    {

        // 2초 대기
        yield return new WaitForSeconds(0.2f);
        gif02.SetActive(false);
        gif01.SetActive(true);
        // 지정된 씬으로 이동
        yield return new WaitForSeconds(0.2f);
        gif02.SetActive(true);
        gif01.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        
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
        image01.SetActive(true);
        who.text = "정민";
        content.text = "....";
        jungminemodark = 5;
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
        jihoonemodark = 1;
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
    IEnumerator FadeInAndOut()
    {
        // 페이드 인
        yield return StartCoroutine(FadeIn());

        // 페이드 아웃
        yield return StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = gif03.color;
        color.a = 0f; // 초기 알파 값 0 (투명)
        gif03.color = color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            gif03.color = color;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = gif03.color;
        color.a = 1f; // 초기 알파 값 1 (불투명)
        gif03.color = color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1f - elapsedTime / fadeDuration);
            gif03.color = color;
            yield return null;
        }
    }
}

