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

        //GameObject jm = GameObject.Find("구정민");
        //Player.playertrans(jm.transform.position.x -5 , jm.transform.position.y);

        //if (sceneName == "Chungmuro_B2")
        //{
        //    if (StationtoB2 == 1)
        //    {
        //        GameObject upstair = GameObject.Find("b2_upstairs_line4");
        //        //GameObject jm = GameObject.Find("구정민");

        //        // null ??
        //        if (jm != null)
        //        {
        //            Debug.Log(jm.transform.position.x);
        //            Player.playertrans(jm.transform.position.x -2 , jm.transform.position.y);
        //            StationtoB2 = 0;
        //        }
        //        else
        //        {
        //            Debug.LogError("지하2층 에러코드");
        //        }
        //    }
        //}
        //else if (sceneName == "4_Chungmuro_B3")
        //{ 
        //    // GameObject start = GameObject.Find("플레이어 위치");

        //    // if (B2toStation == 1)
        //    // {
        //    //     if (start != null)
        //    //     {
        //    //         Debug.Log(start.transform.position.x);
        //    //         Player.playertrans(start.transform.position., start.transform.position.y);
        //    //         B2toStation = 0;
        //    //     }
        //    //     else
        //    //     {
        //    //         Debug.LogError("지하3층 에러코드");
        //    //     }
        //    // }
        //    // // null ??

        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (firstCollisionIgnored)
        {
     
            firstCollisionIgnored = false;
            return;
        }

        Debug.Log("?? ??: " + collision.gameObject.name);

        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {

            presentcol = gameObject.name;
            // Debug.Log("presentcol ??: " + presentcol);

            if(gameObject.tag == "upstairs")
            {
           
                talksqu.SetActive(true);
                Debug.Log(presentcol);
                option1_bt.SetActive(true);
                option2_bt.SetActive(true);
                who.text = "System";
                content.text = "이동하시겠습니까?";
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
        if (presentcol == "b3_subway_platform")
        {
            StationtoB2 = 1;
            SceneManager.LoadScene("Chungmuro_B2");

        }
        else if (presentcol == "b2_upstairs_line3")
        {
            B2toStation = 1;
            if (JMmove.instance != null)
            {
                Destroy(JMmove.instance.gameObject);
                JMmove.instance = null;
                Debug.Log("객체 삭제");
            }
            SceneManager.LoadScene("3_Chungmuro_B3");
           
        }
        else if(presentcol == "b2_upstairs_line4")
        {
            B2toStation = 1;
            if (JMmove.instance != null)
            {
                Destroy(JMmove.instance.gameObject);
                JMmove.instance = null;
                Debug.Log("객체 삭제");
            }
            SceneManager.LoadScene("4_Chungmuro_B3");
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