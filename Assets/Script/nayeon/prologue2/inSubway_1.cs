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
                    contextList = DataManager.instance.GetDialogue(7, 13);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 5;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 6;
                    DialogueManager.instance.chooseFlag = 0;

                    break;


                case (5):
                    contextList = DataManager.instance.GetDialogue(14,14);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 7;
                    break;


                case (6):
                    contextList = DataManager.instance.GetDialogue(15,15);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 7;
                    break;


                case (7):
                    contextList = DataManager.instance.GetDialogue(16,16);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 8;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 9;
                    DialogueManager.instance.chooseFlag = 0;
                    break;


                case (8):
                    contextList = DataManager.instance.GetDialogue(17,20);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 10;
                    break;


                case (9):
                    contextList = DataManager.instance.GetDialogue(21,26);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 10;
                    break;


                case (10):
                    contextList = DataManager.instance.GetDialogue(27,30);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 11;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 12;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (11):
                    contextList = DataManager.instance.GetDialogue(31, 31);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 13;
                    break;


                case (12) :
                    contextList = DataManager.instance.GetDialogue(32, 32);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 13;
                    break;


                case (13):
                    contextList = DataManager.instance.GetDialogue(33,34);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 14;
                    break;

                case (14):
                    contextList = DataManager.instance.GetDialogue(35, 35);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 15;
                    break;


                default:
                    inSubway_0.instance.dialogueID = 15;
                    break;
            }
        }

    }


    public IEnumerator subway_exit()
    {
        //망치 찾은 이후
        
        contextList = DataManager.instance.GetDialogue(36,36);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        contextList = DataManager.instance.GetDialogue(38, 38);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        inSubway_0.instance.dialogueID = 17;
        SceneManager.LoadScene("Chungmuro_B3");

    }

    public IEnumerator subway_remain()
    {
        //망치 못찾은 경우
        contextList = DataManager.instance.GetDialogue(37,37);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
    }


    void Update()
    {
        if (Prolog2_Item.instance.hammerflag == 1 && inSubway_0.instance.dialogueID > 14)
        {
            StartCoroutine(subway_exit());
        }
        else if (Prolog2_Item.instance.hammerflag == 0 && inSubway_0.instance.dialogueID > 14)
        {
            StartCoroutine(subway_remain());
        }
    }
}
