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
//"구매했다"가 들어가는 곳에 자원 차감하면 됨

public class npc : MonoBehaviour
{
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject button;
    public TMP_Text who;
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;
    //
    //public TMP_Text exit;

    public GameObject options;
    public GameObject option3_bt;
    public static int clofirst = 0;
    public static int manjufirst = 0;
    public static int optnum = 0;
    public static string interobj;
    public static int buttonnum = 0;

    public int playercolflag = 0;
    string[] weildcontent = new string[8] { "못에 발이 없어.", "못에 발이 없다니까?", "....", "그녀석들이 나를 두고 갔어.", "그녀석들이 나를 두고 갔어.", "자식 새끼들 키워봐야 다 소용없다더니...", "....", "내 바구니....어디다 놔뒀더라?" };
    string[] helpcontent = new string[5] { "이상하다...안경이 여기 어디 있었는데.....", "저...학생. 혹시 내 안경 못 봤어요?", "이상하네...", "우리 손주랑 똑 닮았네....", "우리 손주 같아서 주는 거야..." };
    string[] objcontent = new string[1] { "................." };
    string[] angercontent = new string[3] { "어이,거기!", "눈을 어따 두고 다니는 거야?", "쯧." };
    string[] manjucontent = new string[4] {"헤헤,정말 괜찮은데...","정민네.","......","정민....대학생이 무슨 돈이 있겠어요~"};
    string[] clocontent = new string[3] { "정민오, 패션에 관심 있으신가봐요? 저돈데!","정민이것도 사실 지하상가에서 산 거거든요~","정민여기 질 괜찮다니까?" };

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
        if (option3_bt!=null&&option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
        }
        if (interobj=="델리만쥬 가게")
        {
            if(manjufirst!=1)
            {
                who.text = "Player";
                content.text = "사 줄까요?";
                button.SetActive(true);
                buttonnum = 0;

            }
            else
            {
                who.text = "system";
                content.text = "델리만쥬를 구매했다.";
            }
            
            

        }

        if (interobj == "옷 가게")
        {
            
            
             who.text = "system";
             content.text = "짱구 잠옷을 구매했다.";
             button.SetActive(true);
             buttonnum = 0;



        }

        if (interobj == "편의점")
        {
            who.text = "system";
            content.text = "물을 구매했다.";
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
        if(option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
            
        }
      
        if (interobj == "델리만쥬 가게")
        {
            if(manjufirst==0)
            {
                who.text = "Player";
                content.text = "돈 없으세요?";
                button.SetActive(true);
                buttonnum = 1;

            }
            else
            {
                who.text = "system";
                content.text = "핫도그를 구매했다.";
            }
           

        }
        if (interobj == "옷 가게")
        {
            who.text = "system";
            content.text = "요상한 맨투맨을 구매했다";
            button.SetActive(true);
            buttonnum = 0;


        }
        if (interobj == "편의점")
        {
            who.text = "system";
            content.text = "보조배터리를 구매했다.";
            button.SetActive(true);
            buttonnum = 0;


        }
        options.SetActive(false);
    }
    public void option3down()
    {
        optnum = 3;
        option1.text = "";
        option2.text = "";
        if (option3_bt != null && option3_bt.activeSelf)
        {
            if (option3 != null)
            {
                option3.text = "";
            }
        }
      
        
        
        if (interobj == "옷 가게")
        {
            who.text = "system";
            content.text = "벙거지를 구매했다.";
            button.SetActive(true);
            buttonnum = 0;


        }
        if (interobj == "편의점")
        {
            who.text = "system";
            content.text = "과자를 구매했다.";
            button.SetActive(true);
            buttonnum = 0;


        }
        options.SetActive(false);
    }
    /*public void exitdown()
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
        talksqu.SetActive(false);
        buttonnum = 0;
        interobj = null;
    }*/
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
            if (optnum==1&&manjufirst==0)
            {
              
                if (buttonnum>0)
                {
                    manjufirst = 1;
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
            if (optnum==2&&manjufirst==0)
            {
                Debug.Log(buttonnum);
                if(buttonnum>3)
                {
                    manjufirst = 1;
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
            if(manjufirst==1)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
                option1.text = "";
                option2.text = "";
                if (option3_bt != null && option3_bt.activeSelf)
                {
                    if (option3 != null)
                    {
                        option3.text = "";
                    }
                }
            }
            
          
          
        }


        if (interobj == "옷 가게")
        {

           
            if (clofirst==0)
            {
                buttonnum++;
                if (buttonnum > 2)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    
                    interobj = null;
                    clofirst = 1;
                }
                else
                {
                    who.text = clocontent[buttonnum].Substring(0, 2);
                    content.text = clocontent[buttonnum].Substring(2);

                }
            }
            else
            {
                if(clofirst==1)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                    option1.text = "";
                    option2.text = "";
                    if (option3_bt != null && option3_bt.activeSelf)
                    {
                        if (option3 != null)
                        {
                            option3.text = "";
                        }
                    }
                }
            }



        }
        if (interobj == "편의점")
        {


            
            talksqu.SetActive(false);
            buttonnum = 0;
            interobj = null;
            option1.text = "";
            option2.text = "";
            if (option3_bt != null && option3_bt.activeSelf)
            {
                if (option3 != null)
                {
                    option3.text = "";
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
            if (manjufirst == 1&& buttonnum==0)
            {
                talksqu.SetActive(true);
                options.SetActive(true);
                who.text = "system";
                content.text = "무엇을 구매할까?";
                option1.text = "> 델리만쥬";
                option2.text = "> 핫도그";
                button.SetActive(true);
                //exit.text = "> 사지 않는다.";
            }
            else if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                options.SetActive(true);
                who.text = "정민";
                content.text = "........";
                option1.text = "> 사 줄까요?";
                option2.text = "> 돈 없으세요?";
                option3_bt.SetActive(false);
                button.SetActive(false);
            }



        }

        if (playercolflag == 1 && gameObject.name == "옷 가게")
        {
            interobj = "옷 가게";
            Debug.Log(clofirst +"옷 플래그");
            if (buttonnum == 0 && clofirst == 0)
            {
                
                talksqu.SetActive(true);
                options.SetActive(false);
                who.text = clocontent[0].Substring(0, 2);
                content.text = clocontent[0].Substring(2);
            }
            if (buttonnum==0&&clofirst != 0)

            {
                Debug.Log("들어옴");
                talksqu.SetActive(true);
                options.SetActive(true);
                option3_bt.SetActive(true);
                button.SetActive(true);
                who.text = "system";
                content.text = "무엇을 구매할까?";
                option1.text = "> 짱구 잠옷";
                option2.text = "> 요상한 맨투맨";
                option3.text = "> 벙거지";
                //exit.text = "> 사지 않는다.";
            }



        }

        if (playercolflag == 1 && gameObject.name == "편의점")
        {
            interobj = "편의점";
           
            
                Debug.Log("들어옴");
                talksqu.SetActive(true);
                options.SetActive(true);
                option3_bt.SetActive(true);
                button.SetActive(true);
                who.text = "system";
                content.text = "무엇을 구매할까?";
                option1.text = "> 물";
                option2.text = "> 보조배터리";
                option3.text = "> 과자";
                //exit.text = "> 사지 않는다.";




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
