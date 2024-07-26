using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class Prologue2Dialogue : MonoBehaviour
{
    public static Prologue2Dialogue instance;
    public int dialogueID;
    public bool checkWiki = true; //위키 체크 변수 (임의로 true 설정. 수정필요) **
    public Dialogue[] contextList;


    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public IEnumerator prologue2_1()
    {
        dialogueID = 1;
        Debug.Log("start" + dialogueID);
 
        while (dialogueID < 15)
        {
            switch (dialogueID)
            {
                case (1):
                    contextList = DataManager.instance.GetDialogue(1, 7);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 2;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        dialogueID = 3;
                    DialogueManager.instance.chooseFlag = 0;

                    break;


                case (2):
                    contextList = DataManager.instance.GetDialogue(8, 8);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 4;
                    break;


                case (3):
                    contextList = DataManager.instance.GetDialogue(9, 9);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 4;
                    break;


                case (4):
                    contextList = DataManager.instance.GetDialogue(10,10);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 5;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        dialogueID = 6;
                    DialogueManager.instance.chooseFlag = 0;
                    break;


                case (5):
                    contextList = DataManager.instance.GetDialogue(11, 14);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 7;
                    break;


                case (6):
                    contextList = DataManager.instance.GetDialogue(15, 20);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 7;
                    break;


                case (7):
                    contextList = DataManager.instance.GetDialogue(21,24);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 8;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        dialogueID = 9;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (8):
                    contextList = DataManager.instance.GetDialogue(25,25);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 10;
                    break;


                case (9):
                    contextList = DataManager.instance.GetDialogue(26,26);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 10;
                    break;


                case (10):
                    contextList = DataManager.instance.GetDialogue(27,28);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 11;
                    break;


                case (11):
                    contextList = DataManager.instance.GetDialogue(29,29);
                    // *** 아이템 획득한 것에 따른 구현 필요 (processChoose 사용) ***//
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));                  
                    dialogueID = 12;
                    break;

                case (12):
                    contextList = DataManager.instance.GetDialogue(30,30);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 14;
                    break;

                case (13):
                    contextList = DataManager.instance.GetDialogue(31,31);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 14;
                    break;

                case (14):
                    contextList = DataManager.instance.GetDialogue(32, 32);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 15;
                    break;
                    
                default:
                    dialogueID = 15;
                    break;
            }
          
        }
        DialogueOnOff.instance.ui_Dialogue.SetActive(false); //대화창 꺼짐 
       
    }

    public IEnumerator prologue2_2()
    {
        while(dialogueID <= 19)
        {
            switch (dialogueID) {
                case (15):
                    contextList = DataManager.instance.GetDialogue(33, 34);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 16;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        dialogueID = 17;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (16):
                    contextList = DataManager.instance.GetDialogue(35, 35);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 18;
                    break;

                case (17):
                    contextList = DataManager.instance.GetDialogue(36, 36);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 18;
                    break;

                case (18):
                    contextList = DataManager.instance.GetDialogue(37, 37);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    dialogueID = 19;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (19):
                    contextList = DataManager.instance.GetDialogue(38, 42);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    dialogueID = 20;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                default:
                    dialogueID = 20;
                    break;
            }
            
        }
        DialogueOnOff.instance.ui_Dialogue.SetActive(false); //대화창 꺼짐 
        
        
    }

    public IEnumerator prologue2_3()
    {
        while(dialogueID < 29)
        {
            switch (dialogueID)
            {
                case (20):
                    contextList = DataManager.instance.GetDialogue(43, 45);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    if (checkWiki == true) dialogueID = 21;
                    else dialogueID = 22;
                    break;

                case (21):
                    contextList = DataManager.instance.GetDialogue(46, 46);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 23;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        dialogueID = 26;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (22):
                    contextList = DataManager.instance.GetDialogue(47, 47);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    dialogueID = 26;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (23):
                    contextList = DataManager.instance.GetDialogue(48, 52);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 24;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        dialogueID = 25;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (24):
                    contextList = DataManager.instance.GetDialogue(53, 55);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 25;
                    break;

                case (25):
                    contextList = DataManager.instance.GetDialogue(56, 60);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 29;
                    break;

                case (26):
                    contextList = DataManager.instance.GetDialogue(61, 63);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 27;
                    break;

                case (27):
                    contextList = DataManager.instance.GetDialogue(64, 65);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 28;
                    Debug.Log("현재 dialogueID: " + dialogueID);
                    break;

                case (28):
                    contextList = DataManager.instance.GetDialogue(66, 69);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 29;
                    break;

                default:
                    dialogueID = 29;
                    break;
            }
        }
        DialogueOnOff.instance.ui_Dialogue.SetActive(false); //대화창 꺼짐 
    }
}
