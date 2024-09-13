using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class train1station : MonoBehaviour
{
    public static train1station instance;
    public GameObject ui_dialogue; //말풍선

    public TMP_Text context;
    public TMP_Text name;
    public GameObject options;


    public Dialogue[] contextList;
    public int dialogueID;
    int chooseFlag = 0;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueID = 1;



        ui_dialogue.SetActive(false);
        options.SetActive(false);

        DataManager.instance.csv_FileName = "train1station";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        StartCoroutine(trainstation());

    }

    void Update()
    {
        if(onclicked.onclickedflag==1)
        {
            StartCoroutine(jungminclicked());
        }
    }
    void dontmove()
    {
        customize.moveflag = 0;
        ui_dialogue.SetActive(true);

    }

    public IEnumerator trainstation()
    {
        ui_dialogue.SetActive(true);

        while (dialogueID < 5)
        {
            switch (dialogueID)
            {
                case 1:
                    contextList = DataManager.instance.GetDialogue(1, 6);
                    Debug.Log(contextList.Length);
                   
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    

                    dialogueID = 2;
                    break;
                case 2:
                    contextList = DataManager.instance.GetDialogue(7, 7);

                    DialogueManager.instance.processChoose(contextList);
                    /*if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
                        chooseFlag = 1;
                    else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen2") == 0)
                        chooseFlag = 2;*/
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    options.SetActive(false);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueID = 4;
                    }
                    if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueID = 3;
                    }
                    DialogueManager.instance.chooseFlag = 0;
                    options.SetActive(false);
                    break;
                case 3:
                    contextList = DataManager.instance.GetDialogue(8, 8);
                   
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));

                    dialogueID = 5;


                    break;
                case 4:
                    contextList = DataManager.instance.GetDialogue(9, 9);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                   
                    dialogueID = 5;
                    break;

                default:

                    dialogueID = 5;


                    break;
            }


        }

        train1_dark.gifnum = 0;
        train1_dark.darkflag = 2;
        ui_dialogue.SetActive(false);
        //StartCoroutine(cameramove.instance.JMmove());



    }
    public IEnumerator jungminclicked()
    {
        onclicked.onclickedflag = 0;
        dialogueID = 2;
        ui_dialogue.SetActive(true);
        while (2 <= dialogueID && dialogueID < 5)
        {

            switch (dialogueID)
            {
                case 2:
                    contextList = DataManager.instance.GetDialogue(7, 7);

                    DialogueManager.instance.processChoose(contextList);
                    /*if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
                        chooseFlag = 1;
                    else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen2") == 0)
                        chooseFlag = 2;
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    options.SetActive(false);*/
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueID = 4;
                    }
                    if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueID = 3;
                    }
                    DialogueManager.instance.chooseFlag = 0;
                    options.SetActive(false);

                    break;
                case 3:
                    contextList = DataManager.instance.GetDialogue(8, 8);

                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));

                    dialogueID = 5;


                    break;
                case 4:
                    contextList = DataManager.instance.GetDialogue(9, 9);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));

                    dialogueID = 5;
                    break;

                default:

                    dialogueID = 5;


                    break;

            }
        }
        ui_dialogue.SetActive(false);
    }



    // Update is called once per frame

}
