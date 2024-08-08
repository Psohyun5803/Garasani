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
    public TMP_Text content;
    public GameObject talksqu;
    public TMP_Text who;
    public static string interobj;
    int buttonnum = 0;

    public int playercolflag = 0;
    string[] weildcontent = new string[8] { "못에 발이 없어.", "못에 발이 없다니까?","....","그녀석들이 나를 두고 갔어.","그녀석들이 나를 두고 갔어.", "자식 새끼들 키워봐야 다 소용없다더니...","....","내 바구니....어디다 놔뒀더라?" };
    string[] helpcontent = new string[5] { "이상하다...안경이 여기 어디 있었는데.....", "저...학생. 혹시 내 안경 못 봤어요?", "이상하네...", "우리 손주랑 똑 닮았네....", "우리 손주 같아서 주는 거야..." };
    string[] objcontent = new string[1] { "................." };
    string[] angercontent = new string[3] { "어이,거기!", "눈을 어따 두고 다니는 거야?", "쯧." };
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 1;
            
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 0;
        }
    }
    
    public void buttondown()
    {
        buttonnum++;
        Debug.Log(interobj);
        Debug.Log(buttonnum);
        if (interobj == "헛소리 하는 노인")
        {
            if (buttonnum > 7)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "헛소리 하는 노인";
                content.text = weildcontent[buttonnum];

            }
        }
        else if(interobj == "도움이 필요해보이는 노인")
        {
            if (buttonnum > 2)
            {
                //여기에 안경플래그 추가 예정
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "도움이 필요해보이는 노인";
                content.text = helpcontent[buttonnum];

            }
        }

        else if (interobj == "물건을 훔치는 노인")
        {
            if (buttonnum > 0)
            {
                //여기에 안경플래그 추가 예정
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "물건을 훔치는 노인";
                content.text = objcontent[buttonnum];

            }
        }

        else if (interobj == "시비거는노인")
        {
            if (buttonnum > 2)
            {
                //여기에 안경플래그 추가 예정
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                who.text = "시비 거는 노인";
                content.text = angercontent[buttonnum];

            }
        }
    }
    void OnMouseDown()
    {
        Debug.Log("마우스클릭감지");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.colitemname);

        if (playercolflag==1&&gameObject.name == "헛소리 하는 노인")
        {
            interobj = "헛소리 하는 노인";
           
            if(buttonnum==0)
            {
                talksqu.SetActive(true);
                who.text = "헛소리 하는 노인";
                content.text = weildcontent[0];
            }
           
            Debug.Log("헛소리 하는 노인 클릭됨");
           
        }

        if (playercolflag == 1 && gameObject.name == "도움이 필요해보이는 노인")
        {
            interobj = "도움이 필요해보이는 노인";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "도움이 필요해보이는 노인";
                content.text = helpcontent[0];
            }

         

        }

        if (playercolflag == 1 && gameObject.name == "물건을 훔치는 노인")
        {
            interobj = "물건을 훔치는 노인";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "물건을 훔치는 노인";
                content.text = objcontent[0];
            }



        }

        if (playercolflag == 1 && gameObject.name == "시비거는노인")
        {
            interobj = "시비거는노인";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "시비 거는 노인";
                content.text = angercontent[0];
            }



        }


    }
// Start is called before the first frame update
void Start()
    {
        talksqu.SetActive(false);
        customize.sceneflag = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playercolflag);
    }
}
