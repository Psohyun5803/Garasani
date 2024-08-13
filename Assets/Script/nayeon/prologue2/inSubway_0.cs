using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inSubway_0 : MonoBehaviour
{
    public static inSubway_0 instance;
    public GameObject ui_dialogue; //말풍선
    private IEnumerator darkandlight;
    public GameObject button;
    public GameObject dark;
    public TMP_Text context;
    public TMP_Text name;
    public GameObject door;
    public static int doorflag = 0;
    private bool doorclickflag = false;

    [SerializeField] private GameObject targetAnimatorObject;
    public float moveSpeed = 5f;
    public string boolParameterName = "Left";
    private Animator NPCAnimator;
    public bool jmeventFlag = false; //정민 이벤트 시작 플래그

    public Dialogue[] contextList;
    public int dialogueID;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueID = 1;
        if (targetAnimatorObject != null)
        {
            NPCAnimator = targetAnimatorObject.GetComponent<Animator>();
            NPCAnimator.SetBool(boolParameterName, false);
        }
        else
        {
            Debug.LogError("Target animator object not assigned.");
        }

        Vector3 newposition = door.transform.position;
        Player.playertrans(newposition.x + 3, newposition.y);
        ui_dialogue.SetActive(false);

        Invoke("dontmove", 1f);
        darkandlight = darkroutine();
        Invoke("dontmove", 1f);
        DataManager.instance.csv_FileName = "Prologue2";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        StartCoroutine(subwayStart()); 
        
    }

    //private IEnumerator MainRoutine()
    //{
    //    yield return StartCoroutine(subwayStart()); // subwayStart() 코루틴이 끝날 때까지 기다림
    //    //yield return StartCoroutine(NPCEventCoroutine()); // NPCEventCoroutine() 코루틴 실행
    //}




    private IEnumerator darkroutine() //전등 깜빡거림 효과 
    {
        while (true)
        {
            dark.SetActive(true);
            yield return new WaitForSeconds(5f);
            dark.SetActive(false);
            yield return new WaitForSeconds(5f);
        }
    }

    void dontmove()
    {
        customize.moveflag = 0;
        ui_dialogue.SetActive(true);

    }

    public IEnumerator subwayStart()
    {
        ui_dialogue.SetActive(true);
        while (dialogueID < 4)
        {
            switch (dialogueID)
            {
                case 1:
                    contextList = DataManager.instance.GetDialogue(1, 1);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 2;
                    break;
                case 2:
                    contextList = DataManager.instance.GetDialogue(2, 3);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 3;
                    break;
                case 3:
                    contextList = DataManager.instance.GetDialogue(4, 4);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    jmeventFlag = true;
                    dialogueID = 4;
                    Debug.Log(dialogueID);
                    Debug.Log(jmeventFlag);
                    break;
                default:
                    dialogueID = 4;
                        
                    break;
            }
            
           
        }
        ui_dialogue.SetActive(false);
        StartCoroutine(NPCEventCoroutine());


    }

    //public IEnumerator doorClick()
    //{
    //    // 문 클릭을 기다림
    //    bool doorClicked = false;
    //    while (!doorClicked)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
    //            if (hit.collider != null)
    //            {
    //                GameObject clickobj = hit.transform.gameObject;
    //                if (clickobj.name == "열차사이문")
    //                {
    //                    ui_dialogue.SetActive(true);
    //                    name.text = "System";
    //                    context.text = "무언가에 걸린듯 문이 열리지 않는다.";
    //                    doorClicked = true; // 클릭 확인
    //                }
    //            }
    //        }
    //        yield return null; // 다음 프레임까지 대기
    //    }

    //    // 클릭 후 대사 출력
    //    if (doorclickflag == true)
    //    {
    //        contextList = DataManager.instance.GetDialogue(4, 4);
    //        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
    //        dialogueID = 4;
    //    }
    //}



    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(darkandlight);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        //    if (hit.collider != null)
        //    {
        //        GameObject clickobj = hit.transform.gameObject;
        //        if (clickobj.name == "열차사이문")
        //        {
        //            ui_dialogue.SetActive(true);
        //            name.text = "System";
        //            context.text = "무언가에 걸린듯 문이 열리지 않는다.";
        //        }

               
        //    }
        //}

        
    }

    IEnumerator NPCEventCoroutine() //정민 이동 
    {
        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool(boolParameterName, true);
        }

        float targetXPosition = -6.0f; // ��ǥ X ��ǥ
        float moveDuration = 2.0f; // �̵��� �ð�

        Vector3 startPosition = targetAnimatorObject.transform.position;
        Vector3 targetPosition = new Vector3(targetXPosition, startPosition.y, startPosition.z);
        float elapsedTime = 0f;

        Debug.Log($"Starting NPC movement from {startPosition} to {targetPosition}");

        while (elapsedTime < moveDuration)
        {
            targetAnimatorObject.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            //Debug.Log($"NPC position: {targetAnimatorObject.transform.position}");
            yield return null;
        }

        targetAnimatorObject.transform.position = targetPosition; // Ensure it ends at the exact position

        Debug.Log($"NPC movement ended at {targetAnimatorObject.transform.position}");

        if (NPCAnimator != null)
        {
            NPCAnimator.SetBool(boolParameterName, false);
        }
    }
}
