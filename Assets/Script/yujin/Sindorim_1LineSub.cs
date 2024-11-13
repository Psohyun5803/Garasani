using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sindorim_1LineSub : MonoBehaviour
{
    public static Sindorim_1LineSub instance;
    public Dialogue[] contextList;
    //public Transform playerFirst; //위치 설정 
    public GameObject ui_dialogue;// 말풍선
    int dialogueID = 1;
   
 
    public GameObject player;
   
    
    public string nextSceneName; //대화 후 바로 다음 씬으로 이동할 수 있도록
    private bool hasTriggered = false; //플레이어와 문의 충돌 감지
   


    public IEnumerator AutoEvent()
    {

        Debug.Log("실행");
            ui_dialogue.SetActive(true);
            while (dialogueID < 4)
            {

                switch (dialogueID)
                {
                    case 1:
                        contextList = DataManager.instance.GetDialogue(1, 1);

                        DialogueManager.instance.processChoose(contextList);
                        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                        if (DialogueManager.instance.chooseFlag == 1)
                            dialogueID = 2;

                        else if (DialogueManager.instance.chooseFlag == 2)
                        {
                            dialogueID = 4;
                            Player.moveflag = 1;
                          

                        }

                        DialogueManager.instance.chooseFlag = 0;
                        break;
                    case 2:

                        contextList = DataManager.instance.GetDialogue(2, 4);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                        dialogueID = 3;
                        break;
                    case 3:
                        yield return new WaitForSeconds(1f);
                        SceneManager.LoadScene("Sindorim_1");
                      
                        dialogueID = 4;
                        break;


                    default:
                        dialogueID = 4;
                        break;

                }

            }
            ui_dialogue.SetActive(false);
        
        





        /*Debug.Log(inSubway_0.instance.dialogueID);  // 현재 대화 ID를 로그로 출력
        DialogueManager.instance.ui_dialogue.SetActive(true);  // 대화 UI 활성화 -> 이건 대화 UI객체가 아닙니다!

        contextList = DataManager.instance.GetDialogue(1, 4);
        DialogueManager.instance.processChoose(contextList);
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        Debug.Log("ChooseFlag after case 1: " + DialogueManager.instance.chooseFlag);

        if (DialogueManager.instance.chooseFlag == 1)
            dialogueID = 2;

        else if (DialogueManager.instance.chooseFlag == 2)
            //dialogueID = 4;
            DialogueManager.instance.ui_dialogue.SetActive(false);

        DialogueManager.instance.chooseFlag = 0;

        DialogueManager.instance.ui_dialogue.SetActive(false);

        //대화 종료 후 2초 텀
        yield return new WaitForSeconds(2f);
        // 씬 전환
        SceneManager.LoadScene(nextSceneName);*/
    }

    void Start()
    {
        DataManager.instance.csv_FileName = "sindorimtext";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        
        ui_dialogue.SetActive(false);
        customize.sceneflag = 4; //테스트 위한 코드 - 삭제가능
        Player.moveflag = 1; // 테스트 위한 코드 - 삭제가능
        player = GameObject.Find("Player");




    }
    /*void Start()
    {
        DataManager.instance.csv_FileName = "<Sindorim_1LineSub>";
        DataManager.instance.DialogueLoad();
        Debug.Log("csv load");
        StartCoroutine(AutoEvent());
    }*/

    /*private void OnTriggerEnter2D(Collider2D other) //아예 문 밖으로 나가려 충돌했을 때 발동되도록 하기 위해서
    {
        // Player 태그를 가진 오브젝트와 충돌하고, 아직 트리거되지 않은 경우
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true; // 중복 실행 방지
            StartCoroutine(AutoEvent()); // 대화 이벤트 시작
        }
    }*/
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌 발생: " + other.gameObject.name); // 충돌이 발생할 때의 오브젝트 이름을 출력

        // 이름이 "Player"인 오브젝트와 충돌했는지 확인
        if (other.gameObject.name == "Player")
        {
           
            Debug.Log("플레이어와 충돌 감지됨!"); // 플레이어와 충돌이 감지되었음을 출력
            StartCoroutine(AutoEvent());
            //Player.moveflag = 0;
            //StartCoroutine(FadeAndLoadScene());
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        dialogueID = 1;
           
           
    }
}
