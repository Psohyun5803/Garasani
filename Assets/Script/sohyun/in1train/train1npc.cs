using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class train1npc : MonoBehaviour
{
    public GameObject god;
    public GameObject ang;
    public GameObject job;
    public GameObject ui_dialogue; //��ǳ��
    public Dialogue[] contextList;
    public int firstflag=0;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "1ȣ������1")//1ȣ�� ���� 1�̶�� �۷��̵� ȿ���� ���ؼ� npc���� ã�´�
        {
           god = GameObject.Find("���̺�");
           ang = GameObject.Find("�޹���");
           job = GameObject.Find("�����");

            ang.SetActive(false);
            god.SetActive(false);
        }
        DataManager.instance.csv_FileName = "NPC";
        DataManager.instance.DialogueLoad(); // CSV ���� �ε�
        Debug.Log("csv load");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCManager.jobflag == 1&&firstflag==0)
        {
            firstflag = 1;
            god.SetActive(true);
        }
        if (NPCManager.godflag == 1)
        {
            ang.SetActive(true);
        }
       
    }
}
