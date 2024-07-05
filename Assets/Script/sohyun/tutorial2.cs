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
    public GameObject 버튼;
    public TMP_Text 내용;
    public TMP_Text 이름;
    int textflag = 0;
    public GameObject door;
    string[] text = new string[4] {  "...?", "...이게 무슨 소리지...?", "앞쪽에서 점점 다가오고 있어...", "...!" };
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newposition = door.transform.position;
        customize.playertrans(newposition.x, newposition.y);
        말풍선.SetActive(false);
        이름.text = customize.playername;
        내용.text = text[textflag];
        Invoke("dontmove", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("클릭인식");
                GameObject clickobj = hit.transform.gameObject;
                if (clickobj.name == "열차사이문")
                {
                    말풍선.SetActive(true);
                    이름.text = "System";
                    내용.text = "무언가에 걸린듯 문이 열리지 않는다.";

                }
            }
        }
    }
    public void button()
    {
        if (textflag==0)
        {
            textflag++;
        }
        if (textflag <= 2)
        {
            이름.text = customize.playername;
            내용.text = text[textflag];
            textflag++;
        }
        else if (textflag == 3)
        {
            Debug.Log("문열림");
            말풍선.SetActive(false);
            customize.moveflag = 1;
        }
    }
    void dontmove()
    {
        customize.moveflag = 0;
        말풍선.SetActive(true);

    }
}
