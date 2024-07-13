using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class Prologue2Dialogue : MonoBehaviour
{
    public static Prologue2Dialogue instance;
    public int dialogueID;
    public int chooseFlag = 0;
    public Dialogue[] contextList;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public IEnumerator prologue2()
    {
        dialogueID = 1;
        Debug.Log("start" + dialogueID);
 
        while (dialogueID < 15)
        {
            switch (dialogueID)
            {
                case (1):
                    contextList = DataManager.instance.GetDialogue(1, 7);
                    processChoose(contextList);
                    yield return new WaitUntil(() => chooseFlag != 0);

                    if (chooseFlag == 1)
                        dialogueID = 2;
                    else if (chooseFlag == 2)
                        dialogueID = 3;
                    chooseFlag = 0;
                    break;


                case (2):
                    contextList = DataManager.instance.GetDialogue(8, 8);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 4;
                    break;


                case (3):
                    contextList = DataManager.instance.GetDialogue(9, 9);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 4;
                    break;


                case (4):
                    contextList = DataManager.instance.GetDialogue(10,10);
                    processChoose(contextList);
                    yield return new WaitUntil(() => chooseFlag != 0);

                    if (chooseFlag == 1)
                        dialogueID = 5;
                    else if (chooseFlag == 2)
                        dialogueID = 6;
                    chooseFlag = 0;
                    break;


                case (5):
                    contextList = DataManager.instance.GetDialogue(11, 14);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 7;
                    break;


                case (6):
                    contextList = DataManager.instance.GetDialogue(15, 20);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 7;
                    break;


                case (7):
                    contextList = DataManager.instance.GetDialogue(21,24);
                    processChoose(contextList);
                    yield return new WaitUntil(() => chooseFlag != 0);

                    if (chooseFlag == 1)
                        dialogueID = 8;
                    else if (chooseFlag == 2)
                        dialogueID = 9;
                    chooseFlag = 0;
                    break;

                case (8):
                    contextList = DataManager.instance.GetDialogue(25,25);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 10;
                    break;


                case (9):
                    contextList = DataManager.instance.GetDialogue(26,26);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 10;
                    break;


                case (10):
                    contextList = DataManager.instance.GetDialogue(27,28);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 11;
                    break;


                case (11):
                    contextList = DataManager.instance.GetDialogue(29,29);
                    yield return StartCoroutine(processing(contextList));
                    // *** 아이템 획득한 것에 따른 구현 필요 ***//
                    dialogueID = 12;
                    break;

                case (12):
                    contextList = DataManager.instance.GetDialogue(30,30);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 14;
                    break;

                case (13):
                    contextList = DataManager.instance.GetDialogue(31,31);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 14;
                    break;

                case (14):
                    contextList = DataManager.instance.GetDialogue(32, 32);
                    yield return StartCoroutine(processing(contextList));
                    dialogueID = 15;
                    DialogueOnOff.instance.ui_Dialogue.SetActive(false); //prologue2 대화 끝 
                    break;

                default:
                    dialogueID = 15;
                    break;
            }

            
        }
        
    }

    public void OnClickChoose()
    {
        Debug.Log("선택지 클릭 확인");
        //태그가 1이면 번호 1리턴, 2면 2리턴
        if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
            chooseFlag = 1;
        else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen2") == 0) 
            chooseFlag = 2;
        Debug.Log("Flag" + chooseFlag); ;
    }

    public void processChoose(Dialogue[] dialogues)
    {
        DialogueManager.instance.Initialize(dialogues);
    }

    public IEnumerator processing(Dialogue[] dialogues)
    {
        DialogueManager.instance.Initialize(dialogues);
        yield return new WaitUntil(() => DialogueManager.instance.IsDialogueFinished);
      
    }

}
