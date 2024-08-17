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
//"player"에 customize.playername 넣으면 됨 

public class npc : MonoBehaviour
{
    public TMP_Text content;
    public GameObject talksqu;
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
    public static int clofirst = 0;
    public static int manjufirst = 0;
    public static int jihoonflag = 0;
    public static int optnum = 0;
    public static int glass = 0;//인벤토리에 안경이 있으면 1로 변경하면 된다. 
    public static int glassinter = 0; //한 번 노인에게 안경을 가져다 줬으면 
    public static int sibiinter = 0;
    public static int jobinter = 0;
    public static string interobj;
    public static string presentcol;
    public static int buttonnum = 0;


    public int playercolflag = 0;
    string[] weildcontent = new string[8] { "못에 발이 없어.", "못에 발이 없다니까?", "....", "그녀석들이 나를 두고 갔어.", "그녀석들이 나를 두고 갔어.", "자식 새끼들 키워봐야 다 소용없다더니...", "....", "내 바구니....어디다 놔뒀더라?" };
    string[] helpcontent = new string[5] { "이상하다...안경이 여기 어디 있었는데.....", "저...학생. 혹시 내 안경 못 봤어요?", "이상하네...", "우리 손주랑 똑 닮았네....", "우리 손주 같아서 주는 거야..." };
    string[] objcontent = new string[1] { "................." };
    string[] angercontent = new string[3] { "어이,거기!", "눈을 어따 두고 다니는 거야?", "쯧." };
    string[] manjucontent = new string[4] {"헤헤,정말 괜찮은데...","정민네.","......","정민....대학생이 무슨 돈이 있겠어요~"};
    string[] clocontent = new string[3] { "정민오, 패션에 관심 있으신가봐요? 저돈데!","정민이것도 사실 지하상가에서 산 거거든요~","정민여기 질 괜찮다니까?" };
    string[] jihoonfirst = new string[6] { "정민어, 안녕?", "지훈으아아아아앙!!", "정민엄마랑 아빠는 어디가셨어?", "지훈몰라...엄마아아....", "지훈엄마가 안 보여... 끅....", "정민미아같은데...어떡할까요?" };
    string[] stationcontent = new string[4] { "정민앗, 퇴근하셨네...", "....", "정민마지막으로 엄마랑 어디서 헤어졌는지 기억나?","지훈(도리도리)" };
    string[] jobcontent = new string[2] { "자 강아지, 강아지 장난감 있습니다. 360도로 돌아가는 겁니다. \n요 친환경 LED ", "지훈...히끅." };
    string[] godcontent = new string[8] { "여러분. 저희 예수님께서는 나 하나를 위해\n 십자가에 못이 박혀 돌아가시고....","정민씨", "예에,당연히! 진짜 아니겠습니까. 하나님께서 보우하사....", "PL그거 진짜에요? 아닌 거 같은데....", "정민(안색이 파래졌다)", "PL그럼 저 지옥...", "정민하하,죄송합니다.", "....." };
    //string[] jihoonfirst = new string[] = {"정민어, 안녕?","지훈으아아아아아앙!!","정민엄마랑 아빠는 어디가셨어?","지훈몰라...엄마아아...","지훈엄마가 안 보여... 끅....","정민미아같은데...어떡할까요?","선1이름을 물어본다","선2먹을 것을 건넨다")
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 1;
            presentcol = gameObject.name;

            
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
        if(interobj=="도움이 필요해보이는 노인")
        {
            who.text = "player";
            content.text = "안 주셔도 돼요";
            button.SetActive(true);
            buttonnum = 0;
            glassinter = 1;

        }
        if(interobj=="사이비")
        {
            who.text = "player";
            content.text = "진짜요?";
            button.SetActive(true);
            buttonnum = 1;
           
            
        }
        if (interobj == "시비거는 취객")
        {
            who.text = "시비거는 취객";
            content.text = "오잉?";
            button.SetActive(true);
            buttonnum = 1;
            sibiinter = 1;


        }

       
        if (interobj == "잡상인")
        {
            who.text = "player";
            content.text = "움직이는 강아지를 구매했다.";
            button.SetActive(true);
            buttonnum = 10;
            


        }

        if (interobj == "음식 파는 할머니")
        {
            who.text = "player";
            content.text = "김밥을 구입했다.";
            button.SetActive(true);
            buttonnum = 10;



        }

        if (interobj == "앵벌이")
        {
            who.text = "player";
            content.text = "카세트 96을 구입했다.";
            button.SetActive(true);
            buttonnum = 10;



        }
        /*if(interobj == "지훈"&&jihoonflag==0)
        {
            who.text = "지훈";
            content.text = "물을 구매했다.";
            button.SetActive(true);
        }*/
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
        if (interobj == "도움이 필요해보이는 노인")
        {
            who.text = "player";
            content.text = "감사합니다";
            button.SetActive(true);
            buttonnum = 0;
            glassinter = 1;
        }

        if (interobj == "사이비")
        {

          
            who.text = "사이비";
            content.text = "(유유히 옆 칸으로 사라진다)";
            /*if(gameObject.name== "사이비")
            {
                Debug.Log("사이비 비활성화 코드");
                
            }*/
            button.SetActive(true);
            buttonnum = 12;
           
        }

        if (interobj == "시비거는 취객")
        {
            who.text = "시비거는 취객";
            content.text = "(나를 향해 손가락질을 한다)";
            button.SetActive(true);
            buttonnum = 1;
            sibiinter = 1;


        }
        if (interobj == "잡상인")
        {
            who.text = "player";
            content.text = "팔토시를 구매했다.";
            button.SetActive(true);
            buttonnum = 10;




        }

        if (interobj == "음식 파는 할머니")
        {
            who.text = "player";
            content.text = "찐 옥수수를 구입했다.";
            button.SetActive(true);
            buttonnum = 10;




        }

        if (interobj == "앵벌이")
        {
            who.text = "player";
            content.text = "카세트 32를 구입했다.";
            button.SetActive(true);
            buttonnum = 10;



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


        if (interobj == "잡상인")
        {
            who.text = "player";
            content.text = "풀페이스 두건을 구매했다.";
            button.SetActive(true);
            buttonnum = 10;



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


        if (interobj == "사이비")
        {
            who.text = "player";
            content.text = "그거 진짜에요? 아닌 거 같은데....";
            button.SetActive(true);
            buttonnum = 3;


        }
        if (interobj == "시비거는 취객")
        {
            who.text = "시비거는 취객";
            content.text = "에이씨....";
            button.SetActive(true);
            buttonnum = 1;
            sibiinter = 1;


        }
        if (interobj == "앵벌이")
        {
            who.text = "player";
            content.text = "카세트 3을 구입했다.";
            button.SetActive(true);
            buttonnum = 10;



        }
        options.SetActive(false);
    }

    public void option4down()
    {
        optnum = 4;


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
        if (interobj == "잡상인")
        {
            who.text = "player";
            content.text = "키토산 파스를 구매했다.";
            button.SetActive(true);
            buttonnum = 10;




        }


        options.SetActive(false);
    }
    public void option5down()
    {
        optnum = 5;


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
        if (interobj == "잡상인")
        {
            who.text = "player";
            content.text = "빤짝 고글을 구매했다.";
            button.SetActive(true);
            buttonnum = 10;




        }


        options.SetActive(false);
    }
    public void option6down()
    {
        optnum = 6;


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
        if (interobj == "잡상인")
        {
            who.text = "player";
            content.text = "카세트 플레이어를 구매했다.";
            button.SetActive(true);
            buttonnum = 10;




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
            presentcol = gameObject.name;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercolflag = 0;
            presentcol = null;
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
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                    manjufirst = 1;

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
                   
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                    manjufirst = 1;
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
                if(buttonnum>14)//구매했을시
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
                else
                {
                    if(buttonnum>1)
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
                    if(buttonnum==1)
                    {
                        who.text = "정민";
                        content.text = "말랑하고 쫀득하고 고소한 커스타드의 향기를...";
                        buttonnum++;
                    }
                    if(buttonnum==0)
                    {
                        who.text = "정민";
                        content.text = "아니! 지하철에서 만쥬를 뿌리치고 가다니...!";
                        buttonnum++;
                    }
                    who.text = "정민";
                    content.text = "아니! 지하철에서 만쥬를 뿌리치고 가다니...!";
                    buttonnum++;
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





        }
        if(interobj=="잡상인")
        {
            if(buttonnum>9)
            {

                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                options.SetActive(false);
                if(buttonnum>1)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                if (jobcontent[buttonnum].Substring(0, 2) == "지훈")
                {
                    who.text = "지훈";
                    content.text = jobcontent[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "잡상인";
                    content.text = jobcontent[buttonnum];
                }
                buttonnum++;
            }
        }
        
        if (interobj == "시비거는 취객")
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
            if(buttonnum==0&&glassinter==1) // 한 번 상호작용을 끝냈으면
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                buttonnum++;
                if (buttonnum > 5)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                if (buttonnum > 2)
                {
                    if (glass == 0)
                    {
                        talksqu.SetActive(false);
                        buttonnum = 0;
                        interobj = null;
                    }
                    else if (glass == 1)
                    {
                        if (helpcontent[buttonnum] == "우리 손주 같아서 주는 거야...")
                        {
                            options.SetActive(true);
                            option3_bt.SetActive(false);
                            option1.text = "> 안 주셔도 돼요";
                            option2.text = "> 감사합니다";
                        }
                        who.text = "도움이 필요해보이는 노인";
                        content.text = helpcontent[buttonnum];
                    }

                }
                else
                {
                    who.text = "도움이 필요해보이는 노인";
                    content.text = helpcontent[buttonnum];

                }
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
                npcmove.moveflag = 1;
            }
            else
            {
                who.text = "물건을 훔치는 노인";
                content.text = objcontent[buttonnum];

            }
        }

        else if (interobj == "사이비")
        {
            buttonnum++;
            if (buttonnum>10)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
           
            if(optnum==1)
            {
                if(buttonnum>2)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                if (godcontent[buttonnum].Substring(0,2)=="정민")
                {
                    who.text = "정민";
                    content.text = /*playername+*/godcontent[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "사이비";
                    content.text = /*playername+*/godcontent[buttonnum];
                }
                
            }
           
           
            else if(optnum==3)
            {
                if(buttonnum>7)
                {
                    talksqu.SetActive(false);
                    buttonnum = 0;
                    interobj = null;
                }
                if (godcontent[buttonnum].Substring(0, 2) == "PL")
                {
                    who.text = "player";
                    content.text = /*playername+*/godcontent[buttonnum].Substring(2);
                }
                else if(godcontent[buttonnum].Substring(0, 2) == "정민")
                {
                    who.text = "정민";
                    content.text = /*playername+*/godcontent[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "사이비";
                    content.text = /*playername+*/godcontent[buttonnum];
                }
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


        else if (interobj == "역무실")
        {
            buttonnum++;
            if (buttonnum > 3)
            {

                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {
                if (stationcontent[buttonnum].Substring(0,2)=="정민"|| stationcontent[buttonnum].Substring(0, 2)=="지훈")
                {
                    who.text = stationcontent[buttonnum].Substring(0, 2);
                    content.text = stationcontent[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "player";
                    content.text = stationcontent[buttonnum];
                }
                

            }
        }

        else if (interobj == "음식 파는 할머니")
        {
            if(buttonnum>10)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else if (buttonnum > 9)
            {
                who.text = "음식 파는 할머니";
                content.text = "고마우이.";
                buttonnum++;

            }
            else 
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
                


            }
            
            
        }

        else if (interobj == "앵벌이")
        {
            if (buttonnum > 10)
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else if (buttonnum > 9)
            {
                who.text = "정민";
                content.text = "(자는 척)";
                buttonnum++;

            }
            else
            {
                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;



            }


        }

        else if (interobj == "지훈")
        {
            buttonnum++;
            if (buttonnum > 5)
            {

                talksqu.SetActive(false);
                buttonnum = 0;
                interobj = null;
            }
            else
            {   
                if (jihoonfirst[buttonnum].Substring(0, 2) == "정민" || jihoonfirst[buttonnum].Substring(0, 2) == "지훈")
                {
                    who.text = jihoonfirst[buttonnum].Substring(0, 2);
                    if(jihoonfirst[buttonnum].Substring(2)== "으아아아아앙!!")
                    {
                        content.fontSize = 7;

                    }
                    else
                    {
                        content.fontSize = 3;
                    }
                    
                    if(jihoonfirst[buttonnum].Substring(2) == "미아같은데...어떡할까요 ?")
                    {
                        //options.SetActive(true);
                        //option3_bt.SetActive(false);
                        //option1.text = "> 이름을 물어본다";
                        //option2.text = "> 먹을 것을 건넨다";//인벤토리 열고 음식 분류의 아이템을 줘야한다 
                        
                    }
                         content.text = jihoonfirst[buttonnum].Substring(2);
                }
                else
                {
                    who.text = "player";
                    content.text = jihoonfirst[buttonnum];
                }


            }
        }
    }
    void OnMouseDown()
    {
        Debug.Log("마우스클릭감지");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.colitemname);

        if (playercolflag==1&&gameObject.name == "헛소리 하는 노인" && presentcol == "헛소리 하는 노인")
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

        if (playercolflag == 1 && gameObject.name == "도움이 필요해보이는 노인" && presentcol == "도움이 필요해보이는 노인")
        {
            interobj = "도움이 필요해보이는 노인";

            if (buttonnum == 0)
            {
                if(glassinter==0)
                {
                    talksqu.SetActive(true);
                    who.text = "도움이 필요해보이는 노인";
                    content.text = helpcontent[0];
                }
                else
                {
                    talksqu.SetActive(true);
                    who.text = "도움이 필요해보이는 노인";
                    content.text = "안경을 착용하더니 무언갈 중얼중얼 읽고 있다.";
                }
                
            }

         

        }

        if (playercolflag == 1 && gameObject.name == "물건을 훔치는 노인" && presentcol == "물건을 훔치는 노인")
        {
            interobj = "물건을 훔치는 노인";

            if (buttonnum == 0)
            {
                npcmove.moveflag = 0;
                talksqu.SetActive(true);
                who.text = "물건을 훔치는 노인";
                content.text = objcontent[0];
            }



        }

        if (playercolflag == 1 && gameObject.name == "시비거는노인" && presentcol == "시비거는노인")
        {
            interobj = "시비거는노인";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "시비 거는 노인";
                content.text = angercontent[0];
            }



        }

        if (playercolflag == 1 && gameObject.name == "델리만쥬 가게" && presentcol == "델리만쥬 가게")
        {
            interobj = "델리만쥬 가게";
            if (manjufirst == 1&& buttonnum==0)
            {
                talksqu.SetActive(true);
                options.SetActive(true);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
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
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(false);
            }



        }

        if (playercolflag == 1 && gameObject.name == "옷 가게" && presentcol == "옷 가게")
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
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(true);
                who.text = "system";
                content.text = "무엇을 구매할까?";
                option1.text = "> 짱구 잠옷";
                option2.text = "> 요상한 맨투맨";
                option3.text = "> 벙거지";
                //exit.text = "> 사지 않는다.";
            }



        }

        if (playercolflag == 1 && gameObject.name == "편의점" && presentcol == "편의점")
        {
            interobj = "편의점";
           
            
                Debug.Log("들어옴");
                talksqu.SetActive(true);
                options.SetActive(true);
                option3_bt.SetActive(true);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(true);
                who.text = "system";
                content.text = "무엇을 구매할까?";
                option1.text = "> 물";
                option2.text = "> 보조배터리";
                option3.text = "> 과자";
                //exit.text = "> 사지 않는다.";




        }

        if (playercolflag == 1 && gameObject.name == "역무실" && presentcol == "역무실")
        {
            interobj = "역무실";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = stationcontent[0].Substring(0,2);
                content.text = stationcontent[0].Substring(2);
            }



        }

        if (playercolflag == 1 && gameObject.name == "지훈"&&presentcol == "지훈")
        {
            interobj = "지훈";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = jihoonfirst[0].Substring(0, 2);
                content.text = jihoonfirst[0].Substring(2);
            }



        }

        if (playercolflag == 1 && gameObject.name == "사이비"&&presentcol == "사이비")
        {
            interobj = "사이비";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "사이비";
                content.text = godcontent[buttonnum];
                options.SetActive(true);
                option3_bt.SetActive(true);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                option1.text = "> 진짜요?";
                option2.text = "> (가만히 있는다)";
                option3.text = "> (시비를 건다)";
                button.SetActive(false);
            }



        }


        if (playercolflag == 1 && gameObject.name== "시비거는 취객"&&presentcol == "시비거는 취객")
        {
            interobj = "시비거는 취객";

            if (buttonnum == 0&&sibiinter==0)
            {
                talksqu.SetActive(true);
                who.text = "시비거는취객";
                content.text = "가위! 바위! 보!";
                options.SetActive(true);
                option3_bt.SetActive(true);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                option1.text = "> 가위";
                option2.text = "> 바위";
                option3.text = "> 보";
                button.SetActive(false);
            }
            else
            {
                talksqu.SetActive(true);
                who.text = "시비거는취객";
                content.text = "떼잉...!";
            }



        }
        if (playercolflag == 1 && gameObject.name == "잡상인"&&presentcol=="잡상인")
        {
            interobj = "잡상인";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "잡상인";
                content.text = "1000원짜리 두 장, 두 장만 받겠습니다.";
              
                options.SetActive(true);
                option3_bt.SetActive(true);
                button.SetActive(true);
                
                option1.text = "> 움직이는 강아지";
                option2.text = "> 팔토시";
                option3.text = "> 풀페이스 두건";
                option4.text= "> 키토산 파스";
                option5.text = "> 빤짝 고글";
                option6.text = "> 카세트 플레이어";
                
            }



        }

        if (playercolflag == 1 && gameObject.name == "음식 파는 할머니" && presentcol == "음식 파는 할머니")
        {
            interobj = "음식 파는 할머니";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "음식 파는 할머니";
                content.text = "....";

                options.SetActive(true);
                option3_bt.SetActive(false);
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(true);

                option1.text = "> 김밥";
                option2.text = "> 찐 옥수수";
                

            }



        }
        if (playercolflag == 1 && gameObject.name == "앵벌이" && presentcol == "앵벌이")
        {
            interobj = "앵벌이";

            if (buttonnum == 0)
            {
                talksqu.SetActive(true);
                who.text = "앵벌이";
                content.text = "~..~";

                options.SetActive(true);
                
                option4_bt.SetActive(false);
                option5_bt.SetActive(false);
                option6_bt.SetActive(false);
                button.SetActive(true);

                option1.text = "> 카세트 96";
                option2.text = "> 카세트 32";
                option3.text = "> 카세트 3";


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
        Debug.Log(buttonnum);
        Debug.Log(presentcol);
        
    }
}
