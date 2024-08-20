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
    public Transform stopPoint1;  // 첫 번째 멈추는 지점 (위로 이동)
    public Transform stopPoint2;  // 두 번째 멈추는 지점 (왼쪽으로 이동, 최종 목적지)
    public float speed = 3f;

    

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
        inSubway_0.instance.dialogueID = 32;
        DialogueManager.instance.ui_dialogue.SetActive(false);
    }

    public IEnumerator ChungmuroB1_2() //돌 1번 밀고 나서 진행 
    {
        DialogueManager.instance.ui_dialogue.SetActive(true);
        while (inSubway_0.instance.dialogueID < 34)
        {
            switch (inSubway_0.instance.dialogueID)
            {
                case (32):
                    contextList = DataManager.instance.GetDialogue(70, 71);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 33;
                    break;

                case (33):
                    contextList = DataManager.instance.GetDialogue(72, 74);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    inSubway_0.instance.dialogueID = 34;
                    break;

                default:
                    inSubway_0.instance.dialogueID = 34;
                    break;

            }
        }
        inSubway_0.instance.dialogueID = 0; //충무로 이벤트 끝 
        DialogueManager.instance.ui_dialogue.SetActive(false);
        StartCoroutine(JMmoving());

    }

    IEnumerator JMmoving() //개찰구로 이동 
    {
        // 1. 첫 번째 지점으로 이동 (위로 이동)
        while (Vector3.Distance(npc.position, stopPoint1.position) > 0.1f)
        {
            npc.position = Vector3.MoveTowards(npc.position, stopPoint1.position, speed * Time.deltaTime);
            yield return null;
        }

        // 2. 두 번째 지점으로 이동 (왼쪽으로 이동)
        while (Vector3.Distance(npc.position, stopPoint2.position) > 0.1f)
        {
            npc.position = Vector3.MoveTowards(npc.position, stopPoint2.position, speed * Time.deltaTime);
            yield return null;
        }

        // NPC가 최종 목적지에 도착했습니다.
        Debug.Log("NPC has arrived at the final destination.");
    }


    // Start is called before the first frame update
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
            playerObject.transform.position = new Vector3(upstairPosition.x, upstairPosition.y-10 , upstairPosition.z);
        }

        DataManager.instance.csv_FileName = "Prologue2";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        
    }

    // Update is called once per frame
    void Update()
    {

        if (b1_subwaytag.instance.moveB3)
        {
            SceneManager.LoadScene("3_Chungmuro_B3"); //3호선 승강장 이동 

        }

        
    }
}
