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

public class tutorialscript : MonoBehaviour
{
    public GameObject talksqu;
    public GameObject butt;


    
    public GameObject InteractionView;
    public TMP_Text explain;
    public GameObject paper;
    public GameObject papercontent;
    public GameObject airpotcontent;
    public GameObject keyringcontent;
    //public GameObject 스크립트매니저;
    private RectTransform interactionViewRectTransform;
    public Vector3 mousePosition; //마우스 커서 좌표
    public Vector3 worldPosition; //마우스 커서 월드좌표
    public static int gotoflag =0;
    public GameObject moveicon;
    public GameObject dashicon;
    public GameObject investicon;
    public GameObject invenicon;
    public TMP_Text context;
    public TMP_Text who;
    int scriptcounter = 0;
    
    string[] text = new string[10] { "으...", "머리를 좀 세게 부딪힌 거 같은데...", "...", "근데 왜 이리 조용하지? 설마 아무도 없나?", "...", "열차를 좀 돌아다녀볼까.", "...?", "...이게 무슨 소리지...?", "앞쪽에서 점점 다가오고 있어...", "...!" };
    string[] obj = new string[4] { "바닥에 떨어져있는 종이 쪼가리", "의자에 떨어져있는 에어팟 한쪽", "의자에 떨어져있는 키링", "열차사이 문" };
    string[] interact = new string[4] { "[찢겨진 부적] : 영문을 알 수 없는 글씨가 쓰여진 종이. 섬뜩하게 찢겨져있다.", "[누군가 두고 내린 에어팟 한쪽]을 가방에 챙겼다.", "[누군가 흘린 키링]을 가방에 챙겼다.", "무언가에 걸린 듯 문이 열리지 않는다" };
    // Start is called before the first frame update
    void Start()
    {
       talksqu.SetActive(true);
        investicon.SetActive(false);
        moveicon.SetActive(false);
        dashicon.SetActive(false);
        investicon.SetActive(false);
        invenicon.SetActive(false);

        who.text = customize.playername;
        context.text = text[scriptcounter];
        scriptcounter++;
        //interactionViewRectTransform = InteractionView.GetComponent<RectTransform>();
        //InteractionView.SetActive(false);
    }
    public void buttondown()
    {
        if (scriptcounter <= 5)
        {
            who.text = customize.playername;
            context.text = text[scriptcounter];
            scriptcounter++;
        }
        else if (scriptcounter == 6)
        {
            //스크립트매니저.SetActive(false);
           talksqu.SetActive(false);
            dashicon.SetActive(true);
            moveicon.SetActive(true);
        }
    }
    /*   private void OnMouseOver() //아이템 위에 커서 있는 것 감지 
       {
           if (!isMouseOver) //커서가 obj 위에 올라갔을 때 최초 1번만 실행
           {
               isMouseOver = true;
               string objectName = gameObject.name; //커서 감지한 obj name 
               Debug.Log("마우스 감지" + objectName);

               Vector3 mousePosition = Input.mousePosition; //커서 좌표 가져옴 
               worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

               ActiveInteraction(); //상태창 on
           }

       }
       void OnMouseExit()
       {
           // 마우스가 obj에서 벗어났을 때 플래그를 리셋
           isMouseOver = false;
           InteractionView.SetActive(false);
       }



       public void ActiveInteraction()
       {
           InteractionView.transform.position = (worldPosition); //obj 커서 위치로 상태창 moveicon 
           InteractionView.SetActive(true); //커서 감지 시 상태창 on
           if(gameObject.name=="찢겨진부적")
           {
               objectcounter = 0;
               explain.text = interact[objectcounter];
           }
       }
    */

    // Update is called once per frame
   
    
    void Update()
    {
        if (intertest.colitemname != null)
        {
            dashicon.SetActive(false);
            moveicon.SetActive(false);
            investicon.SetActive(true);
            invenicon.SetActive(true);
        }
        else
        {
            dashicon.SetActive(true);
            moveicon.SetActive(true);
            investicon.SetActive(false);
            invenicon.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //스크립트매니저.SetActive(true);
            talksqu.SetActive(true);
            who.text = "System";
            context.text = "너무 피곤해서 달릴 수 없다.";
            dashicon.SetActive(false);
            moveicon.SetActive(false);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //스크립트매니저.SetActive(false);
           talksqu.SetActive(false);

        }

        /*if (Input.GetMousebuttDown(0))
        {
            //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            //string objectName = gameObject.name; //커서 감지한 obj name 
            //Debug.Log("마우스 클릭 감지" + objectName);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Debug.Log(hit.transform.gameObject.name);

            }
            
        
            if (hit.collider != null)
            {
                GameObject clickobj = hit.transform.gameObject;
                Debug.Log(clickobj.name);
                Debug.Log("클릭했습니다");
                
                if (clickflag == 0 && clickobj.name == "열차사이문"&& intertest.colitemname=="열차사이문")
                {
                    
                       
                           talksqu.SetActive(true);
                            name.text = "System";
                            context.text = "문이 열렸다";
                            clickflag = 1;
                }
                else if (clickflag>=1&& clickobj.name == "열차사이문")
                {
                   
                       talksqu.SetActive(true);
                        name.text = "System";
                        if (gotoflag<3)
                        {
                        context.text = "열차를 조금 더 둘러보자. ";
                        }
                        else
                        {
                            context.text = "다음 칸으로 moveicon한다";
                            
                            SceneManager.LoadScene("Pro_map2 beta");
                        }   
                       
                        clickflag = 2;
                         
                    
                }
                else if (clickobj.name=="찢겨진부적"&& intertest.colitemname == "찢겨진부적")
                {
                   talksqu.SetActive(true);
                    name.text = "System";
                    context.text = "[찢겨진 부적] : 영문을 알 수 없는 글씨가 쓰여진 종이.섬뜩하게 찢겨져있다. ";
                    clickobj.SetActive(false);
                    papercontent.SetActive(false);
                    gotoflag++;
                }
                else if (clickobj.name == "에어팟한쪽"&& intertest.colitemname == "에어팟한쪽")
                {
                   talksqu.SetActive(true);
                    name.text = "System";
                    context.text = "[누군가 두고 내린 에어팟 한쪽]을 가방에 챙겼다";
                    clickobj.SetActive(false);
                   airpotcontent.SetActive(false);
                    gotoflag++;
                }
                else if (clickobj.name== "키링"&& intertest.colitemname == "키링")
                {
                   talksqu.SetActive(true);
                    name.text = "System";
                    context.text = "[누군가 흘린 키링]을 가방에 챙겼다.";
                    clickobj.SetActive(false);
                    keyringcontent.SetActive(false);
                    gotoflag++;
                }



            }
            else
            {
                Debug.Log("충돌아이템이 없습니다");
            }
        }*/
    }
   
}
