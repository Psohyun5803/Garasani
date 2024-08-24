using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chungmuro_B2 : MonoBehaviour
{
    public static Chungmuro_B2 instance;
    public Dialogue[] contextList;
    public Transform playerFirst;

    public GameObject sign; //표지판
    public bool canMove = false; //대화 끝나야 다른 층 이동 가능

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public IEnumerator ChungmuroB2_1()
    {
        Debug.Log(inSubway_0.instance.dialogueID);
        DialogueManager.instance.ui_dialogue.SetActive(true);

        while (inSubway_0.instance.dialogueID < 25)
        {
            switch (inSubway_0.instance.dialogueID)
            {

                case (19):
                    contextList = DataManager.instance.GetDialogue(38, 39);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        inSubway_0.instance.dialogueID = 20;
                        
                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        inSubway_0.instance.dialogueID = 21;
          
                    } 
                    DialogueManager.instance.chooseFlag = 0;
                    break;


                case (20):
                    contextList = DataManager.instance.GetDialogue(40,40);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 22;
                    break;

                case (21):
                    contextList = DataManager.instance.GetDialogue(41, 41);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 22;
                    break;

                case (22):
                    contextList = DataManager.instance.GetDialogue(42, 43);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        inSubway_0.instance.dialogueID = 23;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        inSubway_0.instance.dialogueID = 24;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (23):
                    contextList = DataManager.instance.GetDialogue(44, 44);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 25;
                    break;

                case (24):
                    contextList = DataManager.instance.GetDialogue(45, 48);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 25;
                    break;

                default:
                    inSubway_0.instance.dialogueID = 25;
                    break;
            }

        }

        DialogueManager.instance.ui_dialogue.SetActive(false);
        canMove = true;
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        //플레이어 이동 설정 
        customize.sceneflag = 4;
        customize.moveflag = 1;
        Player.frontflag = 1;
        //플레이어 위치 설정 
        Vector3 signPosition = sign.transform.position;
        GameObject playerObject = GameObject.FindWithTag("Player");
        if(playerObject != null)
        {
            playerObject.transform.position = new Vector3(signPosition.x, signPosition.y-3, signPosition.z);
        }
        Player.frontflag=1;
        // if (playerFirst != null)
        // {
        //     // 플레이어 위치 설정
        //     Debug.Log($"playerFirst 위치: {playerFirst.transform.position}");
        //     Player.playertrans(playerFirst.transform.position.x, playerFirst.transform.position.y);

        // }
        DataManager.instance.csv_FileName = "Prologue2";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드

    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
