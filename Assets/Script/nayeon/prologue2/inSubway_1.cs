using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inSubway_1 : MonoBehaviour
{
    public static inSubway_1 instance;
    public Dialogue[] contextList;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public IEnumerator subwayStory()
    {
      
        //처음 ~ 쓸만한 도구까지
        Debug.Log("start prol2");
        Debug.Log(inSubway_0.instance.dialogueID);

        while (inSubway_0.instance.dialogueID < 15)
        {
            switch(inSubway_0.instance.dialogueID)
            {
                case (4):
                    contextList = DataManager.instance.GetDialogue(5, 11);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 5;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 6;
                    DialogueManager.instance.chooseFlag = 0;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;


                case (5):
                    contextList = DataManager.instance.GetDialogue(12,12);
                    Debug.Log("대사 출력 확인");
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 7;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;


                case (6):
                    contextList = DataManager.instance.GetDialogue(13,13);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 7;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;


                case (7):
                    contextList = DataManager.instance.GetDialogue(14,14);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 8;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 9;
                    DialogueManager.instance.chooseFlag = 0;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;


                case (8):
                    contextList = DataManager.instance.GetDialogue(15,18);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 10;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;


                case (9):
                    contextList = DataManager.instance.GetDialogue(19,24);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 10;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;


                case (10):
                    contextList = DataManager.instance.GetDialogue(25,28);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 11;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 12;
                    DialogueManager.instance.chooseFlag = 0;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;

                case (11):
                    contextList = DataManager.instance.GetDialogue(29,29);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 13;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;


                case (12) :
                    contextList = DataManager.instance.GetDialogue(30,30);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 13;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;


                case (13):
                    contextList = DataManager.instance.GetDialogue(31,32);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 14;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;

                case (14):
                    contextList = DataManager.instance.GetDialogue(33,33);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 15;
                    Debug.Log(inSubway_0.instance.dialogueID);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    break;


                default:
                    inSubway_0.instance.dialogueID = 15;
                    break;
            }
        }

        inSubway_0.instance.ui_dialogue.SetActive(false);
        JMevent.instance.hammerEvent = true;
    }


    //public IEnumerator subway_exit()
    //{
    //    //망치 찾은 이후
        
    //    contextList = DataManager.instance.GetDialogue(36,36);
    //    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
    //    contextList = DataManager.instance.GetDialogue(38, 38);
    //    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
    //    inSubway_0.instance.dialogueID = 17;
        

    //}

    //public IEnumerator subway_remain()
    //{
    //    //망치 못찾은 경우
    //    contextList = DataManager.instance.GetDialogue(37,37);
    //    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
    //}


    void Update()
    {
        
    }
}
