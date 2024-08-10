using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMevent : MonoBehaviour
{
    public static JMevent instance;
    public GameObject ui_Dialogue;
    public int dialogueID;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    //public void On_uiDialogue()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //prologue2 정민 이벤트 시작
    //        DataManager.instance.csv_FileName = "Prologue2";
    //        ui_Dialogue.SetActive(true);
    //        StartCoroutine(inSubway_1.instance.subwayStory());
    //    }
    //}

    void Start()
    {
        ui_Dialogue.SetActive(false);
        dialogueID = 1;

    }

    void Update()
    {
        //On_uiDialogue();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("npc click");
            //prologue2 정민 이벤트 시작
            DataManager.instance.csv_FileName = "Prologue2";
            DataManager.instance.DialogueLoad(); //대화 로드 
            ui_Dialogue.SetActive(true);
            StartCoroutine(inSubway_1.instance.subwayStory());
        }

    }
}
