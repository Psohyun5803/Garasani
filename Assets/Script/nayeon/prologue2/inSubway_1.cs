using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inSubway_1 : MonoBehaviour
{
    public static inSubway_1 instance;
    public Dialogue[] contextList;
    public GameObject blackPanel;

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
            switch (inSubway_0.instance.dialogueID)
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
                    break;


                case (5):
                    contextList = DataManager.instance.GetDialogue(12, 12);
                    Debug.Log("대사 출력 확인");
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 7;
                    break;


                case (6):
                    contextList = DataManager.instance.GetDialogue(13, 13);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 7;
                    break;


                case (7):
                    contextList = DataManager.instance.GetDialogue(14, 14);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 8;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 9;
                    DialogueManager.instance.chooseFlag = 0;
                    break;


                case (8):
                    contextList = DataManager.instance.GetDialogue(15, 18);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 10;
                    break;


                case (9):
                    contextList = DataManager.instance.GetDialogue(19, 24);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 10;
                    break;


                case (10):
                    contextList = DataManager.instance.GetDialogue(25, 28);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 11;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 12;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (11):
                    contextList = DataManager.instance.GetDialogue(29, 29);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 13;
                    playerState.instance.isTired = false; //피로이상 상태 해제
                    Debug.Log("피로이상 상태 해제 : " + playerState.instance.isTired);
                    break;


                case (12):
                    contextList = DataManager.instance.GetDialogue(30, 30);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 13;
                    break;


                case (13):
                    contextList = DataManager.instance.GetDialogue(31, 32);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 14;
                    break;

                case (14):
                    contextList = DataManager.instance.GetDialogue(33, 33);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 15;
                    break;


                default:
                    inSubway_0.instance.dialogueID = 15;
                    break;
            }
        }

        inSubway_0.instance.ui_dialogue.SetActive(false);
        JMevent.instance.hammerEvent = true; //망치 수집 이벤트 시작 
    }


    public IEnumerator subway_exit()
    {
        //망치 찾은 이후

        contextList = DataManager.instance.GetDialogue(34, 34);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        contextList = DataManager.instance.GetDialogue(36, 36);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
       
        Prolog2_Item.instance.hammerflag = true; //망치 수집 이벤트 끝 -> 씬 이동 가능
        inSubway_0.instance.ui_dialogue.SetActive(false);


    }

    public IEnumerator pre_B2()
    {
        inSubway_0.instance.ui_dialogue.SetActive(true);
        blackPanel.SetActive(true);
        contextList = DataManager.instance.GetDialogue(37, 37);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        inSubway_0.instance.dialogueID = 18;
        inSubway_0.instance.ui_dialogue.SetActive(false);
        blackPanel.SetActive(false);
        SceneManager.LoadScene("Chungmuro_B2"); //지하 2층 계단 이동 
    }


    public IEnumerator subway_remain()
    {
        //망치 못찾은 경우
        contextList = DataManager.instance.GetDialogue(35, 35);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        inSubway_0.instance.ui_dialogue.SetActive(false);
    }

    void Start()
    {
        blackPanel.SetActive(false);    
    }


    void Update()
    {

    }
}