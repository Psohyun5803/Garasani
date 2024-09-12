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

   
  
    public GameObject dark;
    public GameObject image01;
  
    public GameObject background;

   

    public static int gifnum = 0;
   
    //
    //public TMP_Text exit;

  
    public static int darkflag = 0;
    public float fadeDuration = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        dark.SetActive(true);
        image01.SetActive(false);
        background.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gifnum);
        if(gifnum==1)
        {
            image01.SetActive(true);
            background.SetActive(true);
            StartCoroutine(FadeOut(image01));
            StartCoroutine(FadeOut(background));
        }
        if(gifnum==0)
        {
            image01.SetActive(false);
            background.SetActive(false);
        }
        
        if(darkflag==2)
        {
            dark.SetActive(false);
        }
    }
   
    /*IEnumerator TransitionToScene()
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
    }*/

   




   
   
   /*Enumerator FadeIn()
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
    }*/

    IEnumerator FadeOut(GameObject root)
    {
        Image img = root.GetComponent<Image>();
        float elapsedTime =1;
        Color color = img.color;
        color.a = 1f; // 초기 알파 값 1 (불투명)
        img.color = color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1f - elapsedTime / fadeDuration);
            img.color = color;
           
            yield return null;
        }
    }
}

