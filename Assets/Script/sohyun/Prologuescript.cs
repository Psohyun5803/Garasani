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

public class Prologuescript : MonoBehaviour
{
    string[] text = new string[4] { "아, 환승하기 귀찮다. 집에 가는 동안 눈 좀 붙여야지.", "아, 지하철 또 뭐가 문제야....", "어! 이거 왜 이래??!!", "악!!!!!!!!!!!!!!" };
    int textflag = 0;
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject spot; //???
    public GameObject Button1;
    public GameObject realdark;
    public GameObject dark;
    public TMP_Text nameplayer;

    public Transform playerFirst;

    AudioSource subwaySound;
    AudioSource subwayEnd;
    AudioSource subwayTalk;
    AudioSource kung1;
    AudioSource kung2;
    AudioSource kung3;
    AudioSource zipper; 


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(customize.playername);
        Debug.Log(customize.playerbirth);
        spot.SetActive(false);
        talksqu.SetActive(false);
        dark.SetActive(false);
        Invoke("proscript1", 2f);

        subwaySound = GameObject.Find("SubwaySoundObject").GetComponent<AudioSource>();
        subwayTalk = GameObject.Find("SubwayTalkObject").GetComponent<AudioSource>();
        //subwayEnd = GameObject.Find("SubwayEndObject").GetComponent<AudioSource>();
        kung1 = GameObject.Find("Kung1Object").GetComponent<AudioSource>();
        kung2 = GameObject.Find("Kung2Object").GetComponent<AudioSource>();
        kung3 = GameObject.Find("Kung3Object").GetComponent<AudioSource>();


        subwaySound.Play();
        subwayTalk.Play();
    }

    void proscript1()
    {
        talksqu.SetActive(true);
        content.text = text[textflag++];
        nameplayer.text = customize.playername;
        Player.sitdown = 1;


    }
    public void buttondown1() // content? ??? ??? 
    {
        Debug.Log("버튼 클릭");
        if (textflag > 3)
        {
            if(textflag == 4){
                kung2.Play();
            }
            else if(textflag == 5){
                kung3.Play();
            }
            talksqu.SetActive(false);
            CameraShake.stopsk();
            CancelInvoke("lighton");
            CancelInvoke("lightoff");
            dark.SetActive(true);
            customize.sceneflag = 2;
            Invoke("tutorialload", 1f);

            //?? ????? ???  
        }
        else
        {
            talksqu.SetActive(true);

            content.text = text[textflag];
            nameplayer.text = customize.playername;
            textflag++;
            if (textflag == 1) 
            {
                Player.playertrans(playerFirst.transform.position.x, playerFirst.transform.position.y+10);
                talksqu.SetActive(false);
                Player.sitdown = 0;
                Player.lookaround = 1;
                talksqu.SetActive(true);

            }
            if (textflag == 2) // ???? ?? 
            {
                Player.lookaround = 0;
                Player.sitdown = 1;
                talksqu.SetActive(false);
                CameraShake.shake();
                Debug.Log("???? ??");
                //customize.eyeo();
                Player.sitdown = 0;
                Player.shock = 1;
                spot.SetActive(true);
                Invoke("spot_nonActive", 1f);
                Invoke("talksqu_Active", 2f);

            }

            if (textflag == 3 )
            {
                kung1.Play();
                CameraShake.shakeharder();
                InvokeRepeating("lighton", 0f, 0.001f);
                InvokeRepeating("lightoff", 0f, 0.008f);

            }
        }
       
        
        
      
        
    }
    void lighton()
    {
        realdark.SetActive(false);
        
    }
    void lightoff()
    {
        realdark.SetActive(true);

    }
    
    void lightcont()
    {
        Invoke("lighton", 0.2f);
        Invoke("lightoff", 0.3f);
    }
    void tutorialload()
    {
        Player.shock = 0;
        Player.sitdown = 0;
        Player.lookaround = 0;
        SceneManager.LoadScene("Pro_map1 beta");
        //SceneManager.LoadScene("sohyuntest");
    }
    
    void talksqu_Active()
    {
        talksqu.SetActive(true);
    }

    void spot_nonActive()
    {
        spot.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
