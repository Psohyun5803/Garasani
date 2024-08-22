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

public class chunmuroall : MonoBehaviour
{
    public TMP_Text content;
    public GameObject talksqu;

    public TMP_Text who;
    public TMP_Text option1;
    public TMP_Text option2;
    public GameObject option1_bt;
    public GameObject option2_bt;
    public static string presentcol;
    private bool firstCollisionIgnored = false;

    public static int StationtoB2 = 0;
    public static int B2toStation = 0;
    // Start is called before the first frame update
    void Start()
    {
        firstCollisionIgnored = true;

        talksqu.SetActive(false);
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Chungmuro_B2")
        {
            if (StationtoB2 == 1)
            {
                GameObject upstair = GameObject.Find("[계단]지하 2층 (1)");

                // null ??
                if (upstair != null)
                {
                    Debug.Log(upstair.transform.position.x);
                    Player.playertrans(upstair.transform.position.x - 1, upstair.transform.position.y + 1);
                    StationtoB2 = 0;
                }
                else
                {
                    Debug.LogError("[계단]지하 2층 (1) ????? ?? ? ????.");
                }
            }
        }
        else if (sceneName == "4_Chungmuro_B3" || sceneName == "3_Chungmuro_B3")
        {
            GameObject upstair = GameObject.Find("[계단]지하 3층_승강장");

            if (B2toStation == 1)
            {
                if (upstair != null)
                {
                    Debug.Log(upstair.transform.position.x);
                    Player.playertrans(upstair.transform.position.x + 4, upstair.transform.position.y);
                    B2toStation = 0;
                }
                else
                {
                    Debug.LogError("[??]?? 3?_??? ????? ?? ? ????.");
                }
            }
            // null ??

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (firstCollisionIgnored)
        {
            // ? ??? ???? ???? false? ??
            firstCollisionIgnored = false;
            return;
        }

        Debug.Log("충돌 감지: " + collision.gameObject.name);

        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {

            presentcol = gameObject.name;
            Debug.Log("presentcol 설정: " + presentcol);

            if (gameObject.name == "[계단]지하 3층_승강장" || gameObject.name == "[계단]지하 2층 (1)" || gameObject.name == "[계단]지하 2층")
            {

                talksqu.SetActive(true);
                Debug.Log(presentcol);
                option1_bt.SetActive(true);
                option2_bt.SetActive(true);
                who.text = "player";
                content.text = "어디로 가시겠습니까?";
                option1.text = "> 이동하기";
                option2.text = "> 취소";
            }





        }



    }
    private void OnCollisionExit2D(Collision2D collision)
    {


        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {

            presentcol = null;
        }
    }
    public void opt1down()
    {
        option1.text = "";
        option2.text = "";
        content.text = "";
        talksqu.SetActive(false);
        if (presentcol == "[계단]지하 3층_승강장")
        {
            StationtoB2 = 1;
            SceneManager.LoadScene("Chungmuro_B2");

        }
        if (presentcol == "[계단]지하 2층 (1)" || presentcol == "[계단]지하 2층")
        {
            B2toStation = 1;
            SceneManager.LoadScene("4_Chungmuro_B3");
            //??? ?? 3_Chungmuro_B3?
        }
    }
    public void opt2down()
    {
        option1.text = "";
        option2.text = "";
        content.text = "";
        talksqu.SetActive(false);
        customize.sceneflag = 2;
        Player.moveflag = 1;

    }
}