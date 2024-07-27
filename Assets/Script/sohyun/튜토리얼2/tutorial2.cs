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

public class tutorial2 : MonoBehaviour
{
    public GameObject 말풍선;
    private IEnumerator 깜빡거림;
    public GameObject 버튼;
    public GameObject dark;
    public TMP_Text 내용;
    public TMP_Text 이름;
    public static int textflag = 0;
    public GameObject door;
    public static int doorflag = 0;
    
    string[] text = new string[4] {  "...?", "...이게 무슨 소리지...?", "앞쪽에서 점점 다가오고 있어...", "...!" };
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newposition = door.transform.position;
        Player.playertrans(newposition.x+3, newposition.y);
        말풍선.SetActive(false);
        이름.text = customize.playername;
        내용.text = text[textflag];
        Invoke("dontmove", 1f);
        깜빡거림 = 깜빡();
    }
    private IEnumerator 깜빡()
    {
        while (true)
        {
            dark.SetActive(true);
            yield return new WaitForSeconds(5f);
            dark.SetActive(false);
            yield return new WaitForSeconds(5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(깜빡거림);
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                
                GameObject clickobj = hit.transform.gameObject;
                if (clickobj.name == "열차사이문")
                {
                    말풍선.SetActive(true);
                    이름.text = "System";
                    내용.text = "무언가에 걸린듯 문이 열리지 않는다.";
                    textflag++;

                    //SceneManager.LoadScene("Dialogue");
                }
            }
        }
    }
    
    public void doordown()
    {
        Debug.Log("클릭됨");
        if (doorflag==0)
        {
            
            말풍선.SetActive(true);
            이름.text = "System";
            내용.text = "무언가에 걸린듯 문이 열리지 않는다.";
            textflag++;
            doorflag++;
        }
    }
   
    public void button()
    {
        if (textflag == 0)
        {
            textflag++;
        }
        else if (textflag <= 1)
        {
            이름.text = customize.playername;
            내용.text = text[textflag];
            textflag++;

        }
        else if (textflag == 2)
        {
            이름.text = customize.playername;
            내용.text = text[textflag];
            //customize.moveflag = 1;
            //말풍선.SetActive(false);
            textflag++;
        }
        else if (textflag == 3 && doorflag ==0)
        {
            말풍선.SetActive(false);
        }
        else if (textflag==4 && doorflag==1)
        {

            Debug.Log("문열림");
            
            말풍선.SetActive(true);
            이름.text = customize.playername;
            내용.text = text[3];
            textflag++;
        }

        else if (textflag > 4)
        {
            말풍선.SetActive(false);
            SceneManager.LoadScene("Prologue2");

        }

    }
    void dontmove()
    {
        customize.moveflag = 0;
        말풍선.SetActive(true);

    }
}
