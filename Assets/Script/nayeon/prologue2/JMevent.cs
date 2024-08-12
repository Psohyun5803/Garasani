using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMevent : MonoBehaviour
{
    public static JMevent instance;
    public GameObject ui_Dialogue;
    public bool isStart;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    //public void On_uiDialogue()
    //{
    //    if (Input.GetMouseButtonDown(0) && isStart == false)
    //    {
    //        isStart = true; //최초 1번 클릭시 실행 
    //        Debug.Log("npc click");
    //        //prologue2 정민 이벤트 시작
    //        DataManager.instance.csv_FileName = "Prologue2";
    //        DataManager.instance.DialogueLoad(); //csvfile load
    //        ui_Dialogue.SetActive(true);
    //        StartCoroutine(inSubway_1.instance.subwayStory());
    //    }
    //}


    void Start()
    {
        //ui_Dialogue.SetActive(false);
        isStart = false;

    }

    void Update()
    {
        //On_uiDialogue();
        if (Input.GetMouseButtonDown(0) && isStart == false)
        {
            isStart = true; //최초 1번 클릭시 실행 
            Debug.Log("npc click");
            //prologue2 정민 이벤트 시작
            DataManager.instance.csv_FileName = "Prologue2";
            DataManager.instance.DialogueLoad(); //csvfile load
            ui_Dialogue.SetActive(true);
            StartCoroutine(inSubway_1.instance.subwayStory());
        }

    }
}
