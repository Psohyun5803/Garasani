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
    public GameObject ��ǳ��;
    public GameObject ��ư;

    public Inventory inventory;


    private bool isMouseOver = false; //���� ������Ʈ ���� Ŀ���� �ִ����� ���� �÷���
    public GameObject InteractionView;
    public TMP_Text ����;
    public GameObject ����������;
    public GameObject ��������������;
    public GameObject �����̼���;
    public GameObject Ű������;
    //public GameObject ��ũ��Ʈ�Ŵ���;
    private RectTransform interactionViewRectTransform;
    public Vector3 mousePosition; //���콺 Ŀ�� ��ǥ
    public Vector3 worldPosition; //���콺 Ŀ�� ������ǥ

    public GameObject �̵�;
    public GameObject �뽬;
    public GameObject ����;
    public GameObject �κ�;
    public TMP_Text ����;
    public TMP_Text �̸�;
    int scriptcounter = 0;
    int objectcounter = 0;
    string[] text = new string[10] { "��...", "�Ӹ��� �� ���� �ε��� �� ������...", "...", "�ٵ� �� �̸� ��������? ���� �ƹ��� ����?", "...", "������ �� ���ƴٳຼ��.", "...?", "...�̰� ���� �Ҹ���...?", "���ʿ��� ���� �ٰ����� �־�...", "...!" };
    string[] ������Ʈ = new string[4] { "�ٴڿ� �������ִ� ���� �ɰ���", "���ڿ� �������ִ� ������ ����", "���ڿ� �������ִ� Ű��", "�������� ��" };
    string[] ��ȣ�ۿ� = new string[4] { "[������ ����] : ������ �� �� ���� �۾��� ������ ����. �����ϰ� �������ִ�.", "[������ �ΰ� ���� ������ ����]�� ���濡 ì���.", "[������ �기 Ű��]�� ���濡 ì���.", "���𰡿� �ɸ� �� ���� ������ �ʴ´�" };
    // Start is called before the first frame update
    void Start()
    {
        ��ǳ��.SetActive(true);
        ����.SetActive(false);
        �̵�.SetActive(false);
        �뽬.SetActive(false);
        ����.SetActive(false);
        �κ�.SetActive(false);

        �̸�.text = customize.playername;
        ����.text = text[scriptcounter];
        scriptcounter++;
        //interactionViewRectTransform = InteractionView.GetComponent<RectTransform>();
        //InteractionView.SetActive(false);
    }
    public void button()
    {
        if (scriptcounter <= 5)
        {
            �̸�.text = customize.playername;
            ����.text = text[scriptcounter];
            scriptcounter++;
        }
        else if (scriptcounter == 6)
        {
            //��ũ��Ʈ�Ŵ���.SetActive(false);
            ��ǳ��.SetActive(false);
            �뽬.SetActive(true);
            �̵�.SetActive(true);
        }
    }
    /*   private void OnMouseOver() //������ ���� Ŀ�� �ִ� �� ���� 
       {
           if (!isMouseOver) //Ŀ���� ������Ʈ ���� �ö��� �� ���� 1���� ����
           {
               isMouseOver = true;
               string objectName = gameObject.name; //Ŀ�� ������ ������Ʈ �̸� 
               Debug.Log("���콺 ����" + objectName);

               Vector3 mousePosition = Input.mousePosition; //Ŀ�� ��ǥ ������ 
               worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

               ActiveInteraction(); //����â on
           }

       }
       void OnMouseExit()
       {
           // ���콺�� ������Ʈ���� ����� �� �÷��׸� ����
           isMouseOver = false;
           InteractionView.SetActive(false);
       }



       public void ActiveInteraction()
       {
           InteractionView.transform.position = (worldPosition); //������Ʈ Ŀ�� ��ġ�� ����â �̵� 
           InteractionView.SetActive(true); //Ŀ�� ���� �� ����â on
           if(gameObject.name=="����������")
           {
               objectcounter = 0;
               ����.text = ��ȣ�ۿ�[objectcounter];
           }
       }
    */

    // Update is called once per frame
    int clickflag = 0;
    int gotoflag = 0;
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //��ũ��Ʈ�Ŵ���.SetActive(true);
            ��ǳ��.SetActive(true);
            �̸�.text = "System";
            ����.text = "�ʹ� �ǰ��ؼ� �޸� �� ����.";
            �뽬.SetActive(false);
            �̵�.SetActive(false);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //��ũ��Ʈ�Ŵ���.SetActive(false);
            ��ǳ��.SetActive(false);

        }
        
        /*if (Input.GetMouseButtonDown(0))
        {
            //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            //string objectName = gameObject.name; //Ŀ�� ������ ������Ʈ �̸� 
            //Debug.Log("���콺 Ŭ�� ����" + objectName);
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
                Debug.Log("Ŭ���߽��ϴ�");
                
                if (clickflag == 0 && clickobj.name == "�������̹�"&& intertest.�浹�����۸�=="�������̹�")
                {


                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "���� ���ȴ�";
                    clickflag = 1;
                }
                else if (clickflag >= 1 && clickobj.name == "�������̹�")
                {

                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    if (gotoflag < 3)
                    {
                        ����.text = "������ ���� �� �ѷ�����. ";
                    }
                    else
                    {
                        ����.text = "���� ĭ���� �̵��Ѵ�";

                        SceneManager.LoadScene("Pro_map2 beta");
                    }

                    clickflag = 2;
                }
                else if (clickobj.name == "����������" && intertest.�浹�����۸� == "����������")
                {
                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "[������ ����] : ������ �� �� ���� �۾��� ������ ����.�����ϰ� �������ִ�.";
                    clickobj.SetActive(false);
                    ��������������.SetActive(false);
                    inventory.AddItem("����������", "������ �� �� ���� �۾��� ������ ����. �����ϰ� �������ִ�.");
                    gotoflag++;
                }
                else if (clickobj.name == "����������" && intertest.�浹�����۸� == "����������")
                {
                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "[������ �ΰ� ���� ������ ����]�� ���濡 ì���";
                    clickobj.SetActive(false);
                    �����̼���.SetActive(false);
                    inventory.AddItem("����������", "������ �ΰ� ���� ������ ����.");
                    gotoflag++;
                }
                else if (clickobj.name == "Ű��" && intertest.�浹�����۸� == "Ű��")
                {
                    ��ǳ��.SetActive(true);
                    �̸�.text = "System";
                    ����.text = "[������ �기 Ű��]�� ���濡 ì���.";
                    clickobj.SetActive(false);
                    Ű������.SetActive(false);
                    inventory.AddItem("Ű��", "������ �기 Ű��.");
                    gotoflag++;
                }
            }
            else
            {
                Debug.Log("�浹�������� �����ϴ�");
            }
        }*/
    }
}
