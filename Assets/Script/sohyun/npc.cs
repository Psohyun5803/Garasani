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
    public GameObject button;
    public TMP_Text who;
    public TMP_Text option1;
    public TMP_Text option2;
    public GameObject options;
    public static int optnum = 0;
    public static string interobj;
    public static int buttonnum = 0;

    public int playercolflag = 0;
    string[] weildcontent = new string[8] { "못에 발이 없어.", "못에 발이 없다니까?", "....", "그녀석들이 나를 두고 갔어.", "그녀석들이 나를 두고 갔어.", "자식 새끼들 키워봐야 다 소용없다더니...", "....", "내 바구니....어디다 놔뒀더라?" };
    string[] helpcontent = new string[5] { "이상하다...안경이 여기 어디 있었는데.....", "저...학생. 혹시 내 안경 못 봤어요?", "이상하네...", "우리 손주랑 똑 닮았네....", "우리 손주 같아서 주는 거야..." };
    string[] objcontent = new string[1] { "................." };
    string[] angercontent = new string[3] { "어이,거기!", "눈을 어따 두고 다니는 거야?", "쯧." };
    string[] manjucontent = new string[4] {"헤헤,정말 괜찮은데...","정민네.","......","정민....대학생이 무슨 돈이 있겠어요~"};
    //string[] jihoonfirst = new string[] = {"정민어, 안녕?","지훈으아아아아아앙!!","정민엄마랑 아빠는 어디가셨어?","지훈몰라...엄마아아...","지훈엄마가 안 보여... 끅....","정민미아같은데...어떡할까요?","선1이름을 물어본다","선2먹을 것을 건넨다")
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 1;
            
        }
    }
    public void option1down()
    {
        optnum = 1;

        
        option1.text = "";
        option2.text = "";
        if (interobj=="델리만쥬 가게")
        {
            who.text = "Player";
            content.text = "사 줄까요?";
            button.SetActive(true);
            buttonnum = 0;
            

        }
        options.SetActive(false);
       
       
    }
    public void option2down()
    {
        optnum = 2;
        option1.text = "";
        option2.text = "";
        if (interobj == "델리만쥬 가게")
        {
            who.text = "Player";
            content.text = "돈 없으세요?";
            button.SetActive(true);
            buttonnum = 1;

        }
        options.SetActive(false);
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
        
        if(interobj=="델리만쥬 가게")
        {  
            Debug.Log(optnum+"");
            if (optnum==1)
            {
              
                if (buttonnum>0)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                else
                {
                    who.text = "정민";
                    content.text = manjucontent[buttonnum];
                    buttonnum++;
                }
                
            }
            if (optnum==2)
            {
                Debug.Log(buttonnum);
                if(buttonnum>3)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                else
                {
                    if (manjucontent[buttonnum].Substring(0,2)=="정민")
                    {
                        who.text = "정민";
                        content.text = manjucontent[buttonnum].Substring(2);
                    }
                    else
                    {
                        who.text = "player";
                        content.text = manjucontent[buttonnum];
                    }
                    
                    buttonnum++;
                    Debug.Log(buttonnum);
                }
                
            }
          
          
        }
      
       
     
        if (interobj == "헛소리 하는 노인")
        {
            buttonnum++;
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
            buttonnum++;
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
            buttonnum++;
            if (buttonnum > 0)
            {
               
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
            buttonnum++;
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

        if (playercolflag == 1 && gameObject.name == "델리만쥬 가게")
        {
            interobj = "델리만쥬 가게";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                options.SetActive(true);
                who.text = "정민";
                content.text = "........";
                option1.text = "> 사 줄까요?";
                option2.text = "> 돈 없으세요?";
                button.SetActive(false);
            }



        }


    }
// Start is called before the first frame update
void Start()
    {
        talksqu.SetActive(false);
        customize.sceneflag = 2;
        options.SetActive(false);
        button.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
