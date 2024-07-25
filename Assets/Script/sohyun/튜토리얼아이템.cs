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

public class 튜토리얼아이템 : MonoBehaviour
{
    int clickflag = 0;
    
    int 키링flag = 0;
    int 에어팟flag = 0;
    int 부적flag = 0;
   
    public TMP_Text 내용;
    public TMP_Text 이름;
    public GameObject 말풍선;
    public GameObject 키링;
    public GameObject 에어팟한쪽;
    public GameObject 찢겨진부적;
    public GameObject 키링설명;
    public GameObject 에어팟설명;
    public GameObject 찢겨진부적설명;

    public Inventory inventory; // Inventory 스크립트 참조

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("마우스클릭감지");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.충돌아이템명);

        if (clickflag == 0 && intertest.충돌아이템명 == "열차사이문")
        {


            말풍선.SetActive(true);
            이름.text = "System";
            내용.text = "문이 열렸다";
            clickflag = 1;

        }
        else if (clickflag >= 1 && intertest.충돌아이템명 == "열차사이문")
        {

            말풍선.SetActive(true);
            이름.text = "System";
            if (tutorialscript.gotoflag < 3)
            {
                내용.text = "열차를 조금 더 둘러보자. ";
            }
            else
            {
                내용.text = "다음 칸으로 이동한다";

                SceneManager.LoadScene("Pro_map2 beta");
            }

            clickflag = 2;


        }
        else if (부적flag == 0&& intertest.충돌아이템명 == "찢겨진 부적")
        {
            말풍선.SetActive(true);
            이름.text = "System";
            내용.text = "[찢겨진 부적] : 영문을 알 수 없는 글씨가 쓰여진 종이.섬뜩하게 찢겨져있다. ";
            찢겨진부적.SetActive(false);
            찢겨진부적설명.SetActive(false);
            inventory.AddItem("찢겨진부적", "영문을 알 수 없는 글씨가 쓰여진 종이. 섬뜩하게 찢겨져있다.");
            tutorialscript.gotoflag++;
            부적flag = 1;
        }
        else if (에어팟flag==0&&intertest.충돌아이템명 == "에어팟한쪽")
        {
            말풍선.SetActive(true);
            이름.text = "System";
            내용.text = "[누군가 두고 내린 에어팟 한쪽]을 가방에 챙겼다";
            에어팟한쪽.SetActive(false);
            에어팟설명.SetActive(false);
            inventory.AddItem("에어팟한쪽", "누군가 두고 내린 에어팟 한쪽.");
            tutorialscript.gotoflag++;
            에어팟flag = 1;
        }
        else if (키링flag==0&&intertest.충돌아이템명 == "키링")
        {
            말풍선.SetActive(true);
            이름.text = "System";
            내용.text = "[누군가 흘린 키링]을 가방에 챙겼다.";
            키링.SetActive(false);
            키링설명.SetActive(false);
            inventory.AddItem("키링", "누군가 흘린 키링.");
            tutorialscript.gotoflag++;
            키링flag = 1;
           
        }
        

    }
   
}
