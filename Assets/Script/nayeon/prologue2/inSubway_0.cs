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
    public static bool jmovedone=false;
    public static int doorflag = 0;

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
                    break;
                default:
                    dialogueID = 4;
                        
                    break;
            }

        }
        ui_dialogue.SetActive(false);
        //StartCoroutine(cameramove.instance.JMmove());
        StartCoroutine(NPCEventCoroutine());


    }



    // Update is called once per frame
    void Update()
    {
        StartCoroutine(darkandlight);
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
        jmovedone = true;
    }
}
