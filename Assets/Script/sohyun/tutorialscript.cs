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
    public GameObject 말풍선;
    public GameObject 버튼;


    private bool isMouseOver = false; //현재 오브젝트 위에 커서가 있는지에 대한 플래그
    public GameObject InteractionView;
    public TMP_Text 설명;
    public GameObject 찢겨진부적;
    private RectTransform interactionViewRectTransform;
    public Vector3 mousePosition; //마우스 커서 좌표
    public Vector3 worldPosition; //마우스 커서 월드좌표


    public TMP_Text 내용;
    public TMP_Text 이름;
    int scriptcounter = 0;
    int objectcounter = 0;
    string[] text = new string[10] {"으...","머리를 좀 세게 부딪힌 거 같은데...","...","근데 왜 이리 조용하지? 설마 아무도 없나?","...","열차를 좀 돌아다녀볼까.","...?","...이게 무슨 소리지...?","앞쪽에서 점점 다가오고 있어...","...!" };
    string[] 오브젝트 = new string[4] { "바닥에 떨어져있는 종이 쪼가리", "의자에 떨어져있는 에어팟 한쪽", "의자에 떨어져있는 키링", "열차사이 문" };
    string[] 상호작용 = new string[4] { "[찢겨진 부적] : 영문을 알 수 없는 글씨가 쓰여진 종이. 섬뜩하게 찢겨져있다.", "[누군가 두고 내린 에어팟 한쪽]을 가방에 챙겼다.", "[누군가 흘린 키링]을 가방에 챙겼다.", "무언가에 걸린 듯 문이 열리지 않는다" };
    // Start is called before the first frame update
    void Start()
    {
        말풍선.SetActive(true);
        이름.text = customize.playername;
        내용.text = text[scriptcounter];
        scriptcounter++;
        //interactionViewRectTransform = InteractionView.GetComponent<RectTransform>();
        //InteractionView.SetActive(false);
    }
    public void button()
    {
        if (scriptcounter<=5)
        {
            이름.text = customize.playername;
            내용.text = text[scriptcounter];
            scriptcounter++;
        }
        else if (scriptcounter==6)
        {
            말풍선.SetActive(false);
        }
    }
    /*   private void OnMouseOver() //아이템 위에 커서 있는 것 감지 
       {
           if (!isMouseOver) //커서가 오브젝트 위에 올라갔을 때 최초 1번만 실행
           {
               isMouseOver = true;
               string objectName = gameObject.name; //커서 감지한 오브젝트 이름 
               Debug.Log("마우스 감지" + objectName);

               Vector3 mousePosition = Input.mousePosition; //커서 좌표 가져옴 
               worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

               ActiveInteraction(); //상태창 on
           }

       }
       void OnMouseExit()
       {
           // 마우스가 오브젝트에서 벗어났을 때 플래그를 리셋
           isMouseOver = false;
           InteractionView.SetActive(false);
       }



       public void ActiveInteraction()
       {
           InteractionView.transform.position = (worldPosition); //오브젝트 커서 위치로 상태창 이동 
           InteractionView.SetActive(true); //커서 감지 시 상태창 on
           if(gameObject.name=="찢겨진부적")
           {
               objectcounter = 0;
               설명.text = 상호작용[objectcounter];
           }
       }
    */

    // Update is called once per frame
    int clickflag = 0;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            말풍선.SetActive(true);
            이름.text = "System";
            내용.text = "너무 피곤해서 달릴 수 없다.";

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            말풍선.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                GameObject clickobj = hit.transform.gameObject;
                if (clickflag == 0 && clickobj.name == "열차사이문")
                {
                    
                       
                            말풍선.SetActive(true);
                            이름.text = "System";
                            내용.text = "문이 열렸다";
                            clickflag = 1;
                }
                else if (clickflag==1&& clickobj.name == "열차사이문")
                {
                   
                        말풍선.SetActive(true);
                        이름.text = "System";
                        내용.text = "다음 칸으로 이동한다";
                        clickflag = 2;
                    
                }
                else if (clickobj.name=="찢겨진부적")
                {
                    말풍선.SetActive(true);
                    이름.text = "System";
                    내용.text = "[찢겨진 부적] : 영문을 알 수 없는 글씨가 쓰여진 종이. 섬뜩하게 찢겨져있다. ";
                    clickobj.SetActive(false);
                }
                else if (clickobj.name == "에어팟한쪽")
                {
                    말풍선.SetActive(true);
                    이름.text = "System";
                    내용.text = "[누군가 두고 내린 에어팟 한쪽]을 가방에 챙겼다";
                    clickobj.SetActive(false);
                }
                else if (clickobj.name== "키링")
                {
                    말풍선.SetActive(true);
                    이름.text = "System";
                    내용.text = "[누군가 흘린 키링]을 가방에 챙겼다.";
                    clickobj.SetActive(false);
                }



            }
        }
    }
}
