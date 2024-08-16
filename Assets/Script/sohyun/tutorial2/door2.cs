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
public class door2 : MonoBehaviour
{
    public GameObject talksqu;
    public TMP_Text content;
    public TMP_Text who;

    void OnMouseDown()
    {
        Debug.Log("열차 사이 문 클릭");
        if (tutorial2.doorflag == 0)
        {

            talksqu.SetActive(true);
            who.text = "System";
            content.text = "무엇인가 걸린 듯 열리지 않는다.";
            //tutorial2.textflag++;
            //tutorial2.doorflag++;
        }
    }
    
}
