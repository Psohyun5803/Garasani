using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        while(JMevent.instance.dialogueID < 12)
        {
            switch(JMevent.instance.dialogueID)
            {
                case (1):
                    contextList = DataManager.instance.GetDialogue(1, 7);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        JMevent.instance.dialogueID = 2;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        JMevent.instance.dialogueID = 3;
                    DialogueManager.instance.chooseFlag = 0;

                    break;


                case (2):
                    contextList = DataManager.instance.GetDialogue(8, 8);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    JMevent.instance.dialogueID = 4;
                    break;


                case (3):
                    contextList = DataManager.instance.GetDialogue(9, 9);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    JMevent.instance.dialogueID = 4;
                    break;


                case (4):
                    contextList = DataManager.instance.GetDialogue(10, 10);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        JMevent.instance.dialogueID = 5;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        JMevent.instance.dialogueID = 6;
                    DialogueManager.instance.chooseFlag = 0;
                    break;


                case (5):
                    contextList = DataManager.instance.GetDialogue(11, 14);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    JMevent.instance.dialogueID = 7;
                    break;


                case (6):
                    contextList = DataManager.instance.GetDialogue(15, 20);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    JMevent.instance.dialogueID = 7;
                    break;


                case (7):
                    contextList = DataManager.instance.GetDialogue(21, 24);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        JMevent.instance.dialogueID = 8;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        JMevent.instance.dialogueID = 9;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (8):
                    contextList = DataManager.instance.GetDialogue(25, 25);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    JMevent.instance.dialogueID = 10;
                    break;


                case (9):
                    contextList = DataManager.instance.GetDialogue(26, 26);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    JMevent.instance.dialogueID = 10;
                    break;


                case (10):
                    contextList = DataManager.instance.GetDialogue(27, 28);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    JMevent.instance.dialogueID = 11;
                    break;

                case (11):
                    contextList = DataManager.instance.GetDialogue(29, 29);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    JMevent.instance.dialogueID = 12;
                    break;


                default:
                    JMevent.instance.dialogueID = 12;
                    break;
            }
        }

    }


    public IEnumerator subway_exit()
    {
        //망치 찾은 이후
        
        contextList = DataManager.instance.GetDialogue(30, 30);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        contextList = DataManager.instance.GetDialogue(32, 32);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        JMevent.instance.dialogueID = 15;

    }

    public IEnumerator subway_remain()
    {
        //망치 못찾은 경우
        contextList = DataManager.instance.GetDialogue(31, 31);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
    }


    void Update()
    {
        if (Prolog2_Item.instance.hammerflag == 1 && JMevent.instance.dialogueID < 15)
        {
            StartCoroutine(subway_exit());
        }
        else if (Prolog2_Item.instance.hammerflag == 0 && JMevent.instance.dialogueID < 15)
        {
            StartCoroutine(subway_remain());
        }
    }
}
