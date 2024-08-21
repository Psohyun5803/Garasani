using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chungmuro_B3 : MonoBehaviour
{
    public static Chungmuro_B3 instance;
    bool moveB1 = false; //지하 1층 이동 플래그 
    public Dialogue[] contextList;
    public GameObject upstair; //위치 설정 
    
    public IEnumerator ChungmuroB3_1() //3호선 선택 시 
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);

        while (inSubway_0.instance.dialogueID < 31)
        {
            switch (inSubway_0.instance.dialogueID)
            {
                case (25):
                    contextList = DataManager.instance.GetDialogue(49, 51);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    if(Wiki_Chungmuro.instance.checkWiki == true)
                    {
                        inSubway_0.instance.dialogueID = 26;
                    }
                    else
                    {
                        inSubway_0.instance.dialogueID = 27;
                    }
                    break;

                case (26):
                    contextList = DataManager.instance.GetDialogue(52, 52);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 28;
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        inSubway_0.instance.dialogueID = 31;
                        moveB1 = true;
                    } 
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (27):
                    contextList = DataManager.instance.GetDialogue(53, 53);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.clickFlag);
                    DialogueManager.instance.clickFlag = false;
                    inSubway_0.instance.dialogueID = 31;
                    moveB1 = true;
                    break;

                case (28):
                    contextList = DataManager.instance.GetDialogue(54, 58);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 29;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 30;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (29):
                    contextList = DataManager.instance.GetDialogue(59, 61);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 30;
                    break;

                case (30):
                    contextList = DataManager.instance.GetDialogue(62, 66);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 31;  
                    break;

                default:
                    inSubway_0.instance.dialogueID = 31;
                    break;

            }
        }
        inSubway_0.instance.dialogueID = 0; //충무로 이벤트 끝 
        DialogueManager.instance.ui_dialogue.SetActive(false);

        if(moveB1 == true)
        {
            SceneManager.LoadScene("Chungmuro_B1"); //지하 1층 씬 이동 
        }
    }

    


  
    void Start()
    {
        //플레이어 이동 설정 
        customize.sceneflag = 4;
        customize.moveflag = 1;
        //플레이어 위치 설정 
        Vector3 upstairPosition = upstair.transform.position;
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerObject.transform.position = new Vector3(upstairPosition.x, upstairPosition.y, upstairPosition.z);
        }

        DataManager.instance.csv_FileName = "Prologue2";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
    }

    void Update()
    {
        
    }
}
