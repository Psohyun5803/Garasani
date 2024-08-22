using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chungmuro_B3 : MonoBehaviour
{
    public static Chungmuro_B3 instance;
    bool moveB1 = false; //지하 1층 이동 플래그 
    public Dialogue[] contextList;
    public GameObject playerFirst; //위치 설정 

    public Transform dest; // 목적지 Transform
    public float speed = 5.0f; // 정민 이동 속도
    private Animator animator;
    [SerializeField] private GameObject targetAnimatorObject;
    public string boolParameterName = "Right";
    private Animator NPCAnimator;
    
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
            // GameObject jm = GameObject.Find("구정민");
            // if (jm != null)
            // {
            //     // 구정민 객체가 존재할 때만 삭제
            //     Destroy(jm);
            // }
        }
    }

    


  
    // IEmMoveToDestination()
    // {
    //     // // 목적지까지의 남은 거리를 계산
    //     // float distance = Vector2.Distance(transform.position, dest.position);

    //     // // 거리가 일정 이하로 줄어들면 정지
    //     // if (distance > 0.1f)
    //     // {
    //     //     // 이동 애니메이션 활성화
    //     //     animator.SetBool("isWalking", true);

    //     //     // 현재 위치에서 목적지까지 한 프레임 동안 이동할 위치를 계산
    //     //     transform.position = Vector2.MoveTowards(transform.position, dest.position, speed * Time.deltaTime);

    //     //     // 이동 방향에 따라 캐릭터의 방향을 전환 (좌/우)
    //     //     Vector3 dir = (dest.position - transform.position).normalized;
    //     //     if (dir.x != 0)
    //     //     {
    //     //         transform.localScale = new Vector3(Mathf.Sign(dir.x), 1, 1); // 좌우 반전
    //     //     }
    //     // }
    //     // else
    //     // {
    //     //     // 목적지에 도달하면 애니메이션을 정지
    //     //     animator.SetBool("isWalking", false);
    //     // }
    // }

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
            NPCAnimator.SetBool(boolParameterName, false);
        }

        
    }

    void nothing(){

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


        //플레이어 이동 설정 
        customize.sceneflag = 4;
        customize.moveflag = 1;
        //플레이어 위치 설정 
        Vector3 platerPosition = playerFirst.transform.position;
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerObject.transform.position = new Vector3(platerPosition.x, platerPosition.y, platerPosition.z);
        }

        DataManager.instance.csv_FileName = "Prologue2";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드

        animator = GetComponent<Animator>();

        Invoke("nothing", 1.5f);
        StartCoroutine(NPCEventCoroutine());
    }

    void Update()
    {
        
    }
}
