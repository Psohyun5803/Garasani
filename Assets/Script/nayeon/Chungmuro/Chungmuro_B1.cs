using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chungmuro_B1 : MonoBehaviour
{
    public static Chungmuro_B1 instance;
    public Dialogue[] contextList;
    public GameObject upstair; //위치 설정

    public Transform npc;         // 엔피씨 오브젝트

    public Transform playerFirst;
    public int dialogueID = 31;
    private bool isChungmuroB1_2Running = false;

    public float speed = 1.5f; // 정민 이동 속도
    [SerializeField] private GameObject targetAnimatorObject;
    public string boolParameterName = "Front";
    private Animator NPCAnimator;
    public Transform stopPoint1;  // 첫 번째 멈추는 지점 (위로 이동)
    public Transform stopPoint2;  // 두 번째 멈추는 지점 (오른쪽으로 이동, 최종 목적지)

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public IEnumerator ChungmuroB1() //같이 가는 선택지 진행 
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);
        contextList = DataManager.instance.GetDialogue(67, 69);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        dialogueID = 32;
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }

    public IEnumerator ChungmuroB1_2() //돌 3번 밀고 나서 진행 
    {
         if (isChungmuroB1_2Running) yield break; // 이미 실행 중이면 종료

        isChungmuroB1_2Running = true;
        DialogueManager.instance.ui_dialogue.SetActive(true);
        while (dialogueID < 34)
        {
            switch (dialogueID)
            {
                case (32):
                    contextList = DataManager.instance.GetDialogue(70, 71);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 33;
                    break;

                case (33):
                    contextList = DataManager.instance.GetDialogue(72, 74);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 34;
                    break;

                default:
                    dialogueID = 34;
                    break;

            }
        }
        dialogueID = 0; //충무로 이벤트 끝 
        DialogueManager.instance.ui_dialogue.SetActive(false);
        //StartCoroutine(JMmoving());
        isChungmuroB1_2Running = false;

    }

    IEnumerator JMmoving() //개찰구로 이동 
    {
        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool(boolParameterName, true);
        }

        // 1. 첫 번째 지점으로 이동 (위로 이동)
        while (Vector3.Distance(npc.position, stopPoint1.position) > 0.1f)
        {
            npc.position = Vector3.MoveTowards(npc.position, stopPoint1.position, speed * Time.deltaTime);
            yield return null;
        }

        // 첫 번째 지점에서 멈추고 방향 변경
        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool("Right",true);
            NPCAnimator.SetBool("Front",false );
        }

        Debug.Log("NPC has stopped at stopPoint1 and changed direction.");

        // 잠시 멈춤
        //yield return new WaitForSeconds(0.5f); // 필요에 따라 대기 시간 조정

        // 2. 두 번째 지점으로 이동 (오른쪽으로 이동)
        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool("Front", false);
            NPCAnimator.SetBool("Right", true);
        }

        while (Vector3.Distance(npc.position, stopPoint2.position) > 0.1f)
        {
            npc.position = Vector3.MoveTowards(npc.position, stopPoint2.position, speed * Time.deltaTime);
            yield return null;
        }

        // NPC가 최종 목적지에 도착했습니다.
        Debug.Log("NPC has arrived at the final destination.");

        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool("Right", false);
            NPCAnimator.SetBool("Front", false);
        }

    }


    // Start is called before the first frame update
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

        //플레이어 위치 설정 
        Vector3 upstairPosition = upstair.transform.position;
        if (playerFirst != null)
        {
            // 플레이어 위치 설정
            Debug.Log($"playerFirst 위치: {playerFirst.transform.position}");
            Player.playertrans(playerFirst.transform.position.x, playerFirst.transform.position.y);

        }
        DataManager.instance.csv_FileName = "Prologue2";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        
    }

    // Update is called once per frame
    void Update()
    {

        if(b1_rock3.instance.rockFlag == true && !isChungmuroB1_2Running){
            StartCoroutine(ChungmuroB1_2());
        }

        
    }
}
