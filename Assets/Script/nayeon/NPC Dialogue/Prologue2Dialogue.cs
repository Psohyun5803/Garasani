using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class Prologue2Dialogue : MonoBehaviour
{
    public static Prologue2Dialogue instance;
    public int dialogueID;
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
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

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
                    DialogueOnOff.instance.ui_Dialogue.SetActive(false); //prologue2 대화 끝 
                    break;

                default:
                    dialogueID = 15;
                    break;
            }

            
        }
        
    }

    //public void OnClickChoose()
    //{
    //    Debug.Log("선택지 클릭 확인");
    //    //태그가 1이면 번호 1리턴, 2면 2리턴
    //    if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
    //        chooseFlag = 1;
    //    else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen2") == 0) 
    //        chooseFlag = 2;
    //    Debug.Log("Flag" + chooseFlag); ;
    //}

    //public void processChoose(Dialogue[] dialogues) //선택지가 있는 대화인 경우 사용 
    //{
    //    DialogueManager.instance.Initialize(dialogues);
    //}

    //public IEnumerator processing(Dialogue[] dialogues) //선택지가 없는 대화인 경우 사용 
    //{
    //    DialogueManager.instance.Initialize(dialogues);
    //    yield return new WaitUntil(() => DialogueManager.instance.IsDialogueFinished);
      
    //}

}
