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
    public TMP_Text 대사;
    public GameObject 말풍선;
    public GameObject 느낌표;
    public GameObject Button1;
    public GameObject 암전;
    public GameObject dark;
    public TMP_Text 이름;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(customize.playername);
        Debug.Log(customize.playerbirth);
        느낌표.SetActive(false);
        말풍선.SetActive(false);
        dark.SetActive(false);
        Invoke("proscript1", 2f);
       
    }
    void proscript1()
    {
        말풍선.SetActive(true);
        대사.text = text[textflag++];
        이름.text = customize.playername;

    }
    public void buttondown1() // 대사가 이어서 나올 때
    {
        if (textflag > 4)
        {
            말풍선.SetActive(false);
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
            말풍선.SetActive(true);

            대사.text = text[textflag];
            이름.text = customize.playername;
            textflag++;
            if (textflag == 2) // 두리번 거리는 모션이 들어갈 부분 
            {
                말풍선.SetActive(false);
                Debug.Log("플레이어 앉아서 두리면 거리는 모션");
                customize.eyec();
                //플레이어 앉아서 두리번 거리는 모션
                말풍선.SetActive(true);



            }
            if (textflag == 3) // 흔들리는 모션이 들어갈 부분
            {
                말풍선.SetActive(false);
                CameraShake.shake();
                Debug.Log("흔들리는 모션 ");
                customize.eyeo();
                느낌표.SetActive(true);
                Invoke("느낌표비활성화", 1f);
                Invoke("말풍선활성화", 2f);
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
        암전.SetActive(false);
        
    }
    void lightoff()
    {
        암전.SetActive(true);

    }
    void lightcont()
    {
        Invoke("lighton", 0.2f);
        Invoke("lightoff", 0.3f);
    }
    void tutorialload()
    {
        SceneManager.LoadScene("Pro_Map");
    }
    
    void 말풍선활성화()
    {
        말풍선.SetActive(true);
    }
    void 느낌표비활성화()
    {
        느낌표.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
