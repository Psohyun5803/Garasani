using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chungmuro_B3 : MonoBehaviour
{
    public Dialogue[] contextList;
    public bool checkWiki = false; //3호선 운행정보 위키 학인

    public GameObject screenDoor; //위치 설정용
    [SerializeField] private GameObject targetAnimatorObject;


    public IEnumerator ChungmuroB3_1() //3호선 선택 시 
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        while (inSubway_0.instance.dialogueID < 30)
        {
            switch (inSubway_0.instance.dialogueID)
            {
                case (24):
                    contextList = DataManager.instance.GetDialogue(47, 29);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    if(checkWiki == true)
                    {
                        inSubway_0.instance.dialogueID = 25;
                    }
                    else
                    {
                        inSubway_0.instance.dialogueID = 26;
                    }
                    break;

                case (25):
                    contextList = DataManager.instance.GetDialogue(50, 50);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 27;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 30;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (26):
                    contextList = DataManager.instance.GetDialogue(51, 51);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.clickFlag);
                    DialogueManager.instance.clickFlag = false;
                    inSubway_0.instance.dialogueID = 30;
                    break;

                case (27):
                    contextList = DataManager.instance.GetDialogue(52, 36);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 28;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 29;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (28):
                    contextList = DataManager.instance.GetDialogue(57, 59);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 29;
                    break;

                case (29):
                    contextList = DataManager.instance.GetDialogue(60, 64);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 30; 
                    break;

                default:
                    inSubway_0.instance.dialogueID = 30;
                    break;

            }
        }
        inSubway_0.instance.dialogueID = 0; //충무로 이벤트 끝 
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }

    public IEnumerator ChungmuroB3_2() //같이 가는 선택지 진행 
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);
        while (inSubway_0.instance.dialogueID < 33)
        {
            switch (inSubway_0.instance.dialogueID)
            {
                case (30):
                    contextList = DataManager.instance.GetDialogue(65,67);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 31;
                    break;

                case (31):
                    contextList = DataManager.instance.GetDialogue(68, 69);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 32;
                    break;

                case (32):
                    contextList = DataManager.instance.GetDialogue(70, 72);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 33;
                    break;

                default:
                    inSubway_0.instance.dialogueID = 33;
                    break;
            }

        }
        inSubway_0.instance.dialogueID = 0; //충무로 이벤트 끝 
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }


  
    void Start()
    {
        //위치 재조정 
        Vector3 newposition = screenDoor.transform.position;
        Player.playertrans(newposition.x, newposition.y - 5);
        Vector3 jmPosition = new Vector3(targetAnimatorObject.transform.position.x + 5, targetAnimatorObject.transform.position.y -5, targetAnimatorObject.transform.position.z);
        targetAnimatorObject.transform.position = jmPosition;

    }

    void Update()
    {
        
    }
}
