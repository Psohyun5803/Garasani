using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chungmuro_B1 : MonoBehaviour
{
    public static Chungmuro_B1 instance;
    public Dialogue[] contextList;
    public GameObject upstair; //위치 설정
    public jungmin_B2 jungminScript;

    public Transform npc;         // 엔피씨 오브젝트

    public Transform playerFirst;
    public int dialogueID = 31;
    private bool isChungmuroB1_2Running = false;

    public float speed = 2.0f; // 정민 이동 속도
    [SerializeField] private GameObject targetAnimatorObject;
    public string boolParameterName = "Front";
    private Animator NPCAnimator;
    //public Transform stopPoint1;  // 첫 번째 멈추는 지점 (위로 이동)
    //public Transform stopPoint2;  // 두 번째 멈추는 지점 (오른쪽으로 이동, 최종 목적지)
    public Transform dest;
    private bool isMoving = false; // 코루틴 실행 상태를 추적하는 변수

    AudioSource daehwa;
    AudioSource SubwaySoundObject ;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void nothing(){
        //아무것도 안함 
    }

    public IEnumerator ChungmuroB1() //같이 가는 선택지 진행 
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);
        contextList = DataManager.instance.GetDialogue(67, 69);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        dialogueID = 32;
        contextList = DataManager.instance.GetDialogue(72, 74);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        dialogueID = 34;
        daehwa.Play();
        SubwaySoundObject.Play();
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
                    daehwa.Play();
                    SubwaySoundObject.Play();
                    break;

                default:
                    dialogueID = 34;
                    break;

            }
        }
        dialogueID = 0; //충무로 이벤트 끝 
        DialogueManager.instance.ui_dialogue.SetActive(false);
        Invoke("nothing", 1.5f);
        isChungmuroB1_2Running = false;
        // if (!isMoving)
        // {
        //     StartCoroutine(JMmoving());
        // }
            
    }

    IEnumerator JMmoving() // 개찰구로 이동 
    {
        if (isMoving) yield break; // 이미 실행 중이면 중단

        isMoving = true; // 코루틴 시작

        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool(boolParameterName, true);
        }

        float targetYPosition = dest.position.y; // 목표 y 위치
        float moveDuration = 2.0f; // 이동 목표 시간

        Vector3 startPosition = targetAnimatorObject.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, targetYPosition, startPosition.z); // y 위치만 변경
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

        isMoving = false; // 코루틴 종료
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

        daehwa = GameObject.Find("daehwa").GetComponent<AudioSource>();
        SubwaySoundObject = GameObject.Find("SubwaySoundObject").GetComponent<AudioSource>();

        //플레이어 이동 설정 
        customize.sceneflag = 4;
        customize.moveflag = 1;
        Player.frontflag = 1;

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
