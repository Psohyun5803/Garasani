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

public class station1 : MonoBehaviour
{
    string[] station1talk =new string[6] { "���ƿ��� �ʷϻ��̿���?","PL��?", "���ƾ����� �������� �ʷϻ� Ÿ��� �ߴµ�...", "����!", "PL�ʷϻ��̸�...", "����2ȣ�� ȯ�¿����� ��ٸ��� �������� �𸣰ڳ׿�." };
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
    public static int index = 0;
    int again = 0;
    int num = 0;
    int onestair = 0;



    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (gameObject.name == "1ȣ�����")
        {
           
            talksqu.SetActive(true);
            options.SetActive(false);
            option3_bt.SetActive(false);
            button.SetActive(true);
            who.text = "player";
            content.text = "������ Ÿ���� �� ����.";
            onestair = 1;
        }





    }



    // Start is called before the first frame update
    void Start()
    {
        customize.sceneflag = 2;
        customize.moveflag = 1;
        onestair = 0;
        if (npc.B1toS1 == 1)
        {

            GameObject upstair = GameObject.Find("1ȣ�����");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x + 10, upstair.transform.position.y);
            npc.B1toS1 = 0;
        }
        npc.station1 = 1;
        talksqu.SetActive(true);
        if(index==0)
        {
            who.text = "����";
            Debug.Log("�����");
            content.text = "���� �ʷϻ��̿���?";
            button.SetActive(true);
           
        }

       
    }
    public void buttondown()
    {
        if(onestair!=1)
        {
            index++;
           

            if (index > 5)
            {
                if (num != 0 && again == 0)
                {
                    talksqu.SetActive(false);

                }
                else
                {
                    who.text = "����";
                    content.text = "ȯ�¿��� ������ ���� ������ Ÿ���ұ��?";
                    talksqu.SetActive(true);
                    options.SetActive(true);
                    option3_bt.SetActive(true);
                    option4_bt.SetActive(true);
                    option5_bt.SetActive(true);
                    option6_bt.SetActive(true);
                    button.SetActive(false);
                    option1.text = "> ��õ����";
                    option2.text = "> ������";
                    option3.text = "> ����ź��";
                    option4.text = "> ��������";
                    option5.text = "> ��������";
                    option6.text = "> ���￪��";
                }


            }

            else
            {
                if (station1talk[index].Substring(0, 2) == "PL")
                {
                    who.text = "player";
                }
                else
                {
                    who.text = station1talk[index].Substring(0, 2);
                }
                content.text = station1talk[index].Substring(2);
                Debug.Log(content.text = station1talk[index].Substring(2));
            }
        }
        else
        {
            talksqu.SetActive(false);
        }


    }
    public void option1d()
    {
        num = 1;


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
        who.text = "����";
        content.text = "�װ� ��ٸ��� �ǰڳ׿�!";
        again = 0;
        options.SetActive(false);
        button.SetActive(true);
    }
    public void option2d()
    {
        num = 2;


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
        who.text = "����";
        content.text = "��..�ƴ� �� ���ƿ�. �뼱�� ��������?";
        options.SetActive(false);
        button.SetActive(true);
        again = 1;
    }
    // Update is called once per frame
    void Update()
    {

        if (who.text != "player")
        {
            content.alignment = TextAlignmentOptions.Right;
        }
        else
        {
            content.alignment = TextAlignmentOptions.Left;
        }

    }
}