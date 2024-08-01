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

public class npc : MonoBehaviour
{
    public TMP_Text 내용;
    public GameObject 말풍선;
    public TMP_Text 이름;
    public static string 상호작용객체;
    int buttonnum = 0;

    public int 플레이어충돌플래그 = 0;
    string[] 헛소리대사 = new string[8] { "못에 발이 없어.", "못에 발이 없다니까?","....","그녀석들이 나를 두고 갔어.","그녀석들이 나를 두고 갔어.", "자식 새끼들 키워봐야 다 소용없다더니...","....","내 바구니....어디다 놔뒀더라?" };
    string[] 도움대사 = new string[5] { "이상하다...안경이 여기 어디 있었는데.....", "저...학생. 혹시 내 안경 못 봤어요?", "이상하네...", "우리 손주랑 똑 닮았네....", "우리 손주 같아서 주는 거야..." };
    string[] 물건대사 = new string[1] { "................." };
    string[] 시비대사 = new string[3] { "어이,거기!", "눈을 어따 두고 다니는 거야?", "쯧." };
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            플레이어충돌플래그 = 1;
            
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            플레이어충돌플래그 = 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            플레이어충돌플래그 = 0;
        }
    }
    
    public void buttondown()
    {
        buttonnum++;
        Debug.Log(상호작용객체);
        Debug.Log(buttonnum);
        if (상호작용객체 == "헛소리 하는 노인")
        {
            if (buttonnum > 7)
            {
                말풍선.SetActive(false);
                buttonnum = 0;
                상호작용객체 = null;
            }
            else
            {
                이름.text = "헛소리 하는 노인";
                내용.text = 헛소리대사[buttonnum];

            }
        }
        else if(상호작용객체 == "도움이 필요해보이는 노인")
        {
            if (buttonnum > 2)
            {
                //여기에 안경플래그 추가 예정
                말풍선.SetActive(false);
                buttonnum = 0;
                상호작용객체 = null;
            }
            else
            {
                이름.text = "도움이 필요해보이는 노인";
                내용.text = 도움대사[buttonnum];

            }
        }

        else if (상호작용객체 == "물건을 훔치는 노인")
        {
            if (buttonnum > 0)
            {
                //여기에 안경플래그 추가 예정
                말풍선.SetActive(false);
                buttonnum = 0;
                상호작용객체 = null;
            }
            else
            {
                이름.text = "물건을 훔치는 노인";
                내용.text = 물건대사[buttonnum];

            }
        }

        else if (상호작용객체 == "시비거는노인")
        {
            if (buttonnum > 2)
            {
                //여기에 안경플래그 추가 예정
                말풍선.SetActive(false);
                buttonnum = 0;
                상호작용객체 = null;
            }
            else
            {
                이름.text = "시비 거는 노인";
                내용.text = 시비대사[buttonnum];

            }
        }
    }
    void OnMouseDown()
    {
        Debug.Log("마우스클릭감지");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.충돌아이템명);

        if (플레이어충돌플래그==1&&gameObject.name == "헛소리 하는 노인")
        {
            상호작용객체 = "헛소리 하는 노인";
           
            if(buttonnum==0)
            {
                말풍선.SetActive(true);
                이름.text = "헛소리 하는 노인";
                내용.text = 헛소리대사[0];
            }
           
            Debug.Log("헛소리 하는 노인 클릭됨");
           
        }

        if (플레이어충돌플래그 == 1 && gameObject.name == "도움이 필요해보이는 노인")
        {
            상호작용객체 = "도움이 필요해보이는 노인";

            if (buttonnum == 0)
            {
                말풍선.SetActive(true);
                이름.text = "도움이 필요해보이는 노인";
                내용.text = 도움대사[0];
            }

         

        }

        if (플레이어충돌플래그 == 1 && gameObject.name == "물건을 훔치는 노인")
        {
            상호작용객체 = "물건을 훔치는 노인";

            if (buttonnum == 0)
            {
                말풍선.SetActive(true);
                이름.text = "물건을 훔치는 노인";
                내용.text = 물건대사[0];
            }



        }

        if (플레이어충돌플래그 == 1 && gameObject.name == "시비거는노인")
        {
            상호작용객체 = "시비거는노인";

            if (buttonnum == 0)
            {
                말풍선.SetActive(true);
                이름.text = "시비 거는 노인";
                내용.text = 시비대사[0];
            }



        }


    }
// Start is called before the first frame update
void Start()
    {
        말풍선.SetActive(false);
        customize.sceneflag = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(플레이어충돌플래그);
    }
}
