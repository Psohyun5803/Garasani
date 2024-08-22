using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chungmuro_B3 : MonoBehaviour
{
    bool moveB1 = false; //지하 1층 이동 플래그 
    public Dialogue[] contextList;
    public Transform playerFirst; //위치 설정 

    public Transform dest; // 목적지 Transform
    public float speed = 5.0f; // 정민 이동 속도
    [SerializeField] private GameObject targetAnimatorObject;
    public string boolParameterName = "Right";
    private Animator NPCAnimator;
    int  dialogueID = 25;
    
    public IEnumerator ChungmuroB3_1() //3호선 선택 시 
    {
        Debug.Log(dialogueID);
        Debug.Log("코루틴 시작");
        DialogueManager.instance.ui_dialogue.SetActive(true);

        while (dialogueID < 31)
        {
            switch (dialogueID)
            {
                case (25):
                    contextList = DataManager.instance.GetDialogue(49, 51);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    if(Wiki_Chungmuro.instance.checkWiki == true)
                    {
                        dialogueID = 26;
                    }
                    else
                    {
                        dialogueID = 27;
                    }
                    break;

                case (26):
                    contextList = DataManager.instance.GetDialogue(52, 52);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 28;
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueID = 31;
                        moveB1 = true;
                    } 
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (27):
                    contextList = DataManager.instance.GetDialogue(53, 53);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.clickFlag);
                    DialogueManager.instance.clickFlag = false;
                    dialogueID = 31;
                    moveB1 = true;
                    break;

                case (28):
                    contextList = DataManager.instance.GetDialogue(54, 58);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                        dialogueID = 29;
                    else if (DialogueManager.instance.chooseFlag == 2)
                        dialogueID = 30;
                    DialogueManager.instance.chooseFlag = 0;
                    break;

                case (29):
                    contextList = DataManager.instance.GetDialogue(59, 61);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 30;
                    break;

                case (30):
                    contextList = DataManager.instance.GetDialogue(62, 66);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 31;  
                    break;

                default:
                    dialogueID = 31;
                    break;

            }
        }
        dialogueID = 0; //충무로 이벤트 끝 
        DialogueManager.instance.ui_dialogue.SetActive(false);

        if(moveB1 == true)
        {
           if (JM_b3_3.instance != null)
            {
                Destroy(JM_b3_3.instance.gameObject);
                JM_b3_3.instance = null;
                Debug.Log("객체 삭제");
            }
            SceneManager.LoadScene("Chungmuro_B1"); //지하 1층 씬 이동 
        }
    }


   IEnumerator NPCEventCoroutine() // 정민 이동
    {
        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool(boolParameterName, true);
        }

        float targetXPosition = dest.position.x;
        float moveDuration = 2.0f; // 이동 목표 시간

        Vector3 startPosition = targetAnimatorObject.transform.position;
        Vector3 targetPosition = new Vector3(targetXPosition, startPosition.y, startPosition.z);
        float elapsedTime = 0f;

        Debug.Log($"Starting NPC movement from {startPosition} to {targetPosition}");

        while (elapsedTime < moveDuration)
        {
            targetAnimatorObject.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetAnimatorObject.transform.position = targetPosition; // 정확한 위치로 설정

        Debug.Log($"NPC movement ended at {targetAnimatorObject.transform.position}");

        if (NPCAnimator != null)
        {
            Debug.Log("npc animate false");
            NPCAnimator.SetBool(boolParameterName, false);
        }

        StartCoroutine(ChungmuroB3_1());
    }

    void nothing(){
        //아무것도 안하는 메소드 
    }

    void Start()
    {
        if (targetAnimatorObject != null)
        {
            NPCAnimator = targetAnimatorObject.GetComponent<Animator>();
            NPCAnimator.SetBool(boolParameterName, false);
        }
        else
        {
            Debug.LogError("Target animator object not assigned.");
        }

        NPCAnimator= GetComponent<Animator>();
        
        //플레이어 이동 설정 
        customize.sceneflag = 4;
        customize.moveflag = 1;

        // playerFirst가 null이 아닌지 확인
        if (playerFirst != null)
        {
            // 플레이어 위치 설정
            Debug.Log($"playerFirst 위치: {playerFirst.transform.position}");
            Player.playertrans(playerFirst.transform.position.x, playerFirst.transform.position.y);

        }
        else
        {
            Debug.LogError("playerFirst 오브젝트가 할당되지 않았습니다.");
        }
        
        DataManager.instance.csv_FileName = "Prologue2";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드

        

        Invoke("nothing", 1.5f);
        StartCoroutine(NPCEventCoroutine());
    }

}
