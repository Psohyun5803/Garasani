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
    string[] text = new string[5] { " 아, 환승하기 귀찮다. 집에 가는 동안 눈 좀 붙여야지.", " 막차 안내 방송", " 아, 지하철 또 뭐가 문제야...", "어! 이거 왜 이래??!!", "악!!!!!!!!!!!!!!" };
    int textflag = 0;
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject spot;//느낌표
    public GameObject Button1;
    public GameObject realdark;
    public GameObject dark;
    public TMP_Text nameplayer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(customize.playername);
        Debug.Log(customize.playerbirth);
        spot.SetActive(false);
        talksqu.SetActive(false);
        dark.SetActive(false);
        Invoke("proscript1", 2f);
       
    }
    void proscript1()
    {
        talksqu.SetActive(true);
        content.text = text[textflag++];
        nameplayer.text = customize.playername;
        Player.sitdown = 1;

    }
    public void buttondown1() // content가 이어서 나올 때
    {
        if (textflag > 4)
        {
            talksqu.SetActive(false);
            CameraShake.stopsk();
            CancelInvoke("lighton");
            CancelInvoke("lightoff");
            dark.SetActive(true);
            customize.sceneflag = 2;
            Invoke("tutorialload", 1f);

            //완전 블랙 이미지 활성화 
        }
        else
        {
            talksqu.SetActive(true);

            content.text = text[textflag];
            nameplayer.text = customize.playername;
            textflag++;
            if (textflag == 2) // lookaround 거리는 모션이 들어갈 부분 
            {
                talksqu.SetActive(false);
                Debug.Log("플레이어 앉아서 두리면 거리는 모션");
                Player.sitdown = 0;
                Player.lookaround = 1;
                //플레이어 앉아서 lookaround 거리는 모션
                talksqu.SetActive(true);
               



            }
            if (textflag == 3) // 흔들리는 모션이 들어갈 부분
            {
                Player.lookaround = 0;
                Player.sitdown = 1;
                talksqu.SetActive(false);
                CameraShake.shake();
                Debug.Log("흔들리는 모션 ");
                //customize.eyeo();
                Player.sitdown = 0;
                Player.shock = 1;
                spot.SetActive(true);
                Invoke("spot비활성화", 1f);
                Invoke("talksqu활성화", 2f);
            }
            if (textflag == 4 )
            {
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
    
    void talksqu활성화()
    {
        talksqu.SetActive(true);
    }
    void spot비활성화()
    {
        spot.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
