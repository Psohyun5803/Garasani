using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    public int helpCount = 0;
    public static NPCManager instance;//참조도움

    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    public static int jobflag = 0;
    public static int godflag = 0;
    public static int saiitem = 0;
    int sajuid = 20;
    GameObject shop;
    // Start is called before the first frame update
    void Update()
    {
        if(npcshopopen.jobcouflag==true)
        {
            npcshopopen.jobcouflag = false;
            StartCoroutine(Job());

        }
        if (npcshopopen.grandcouflag == true)
        {
            npcshopopen.grandcouflag = false;
            StartCoroutine(halstart());

        }
        if (npcshopopen.angcouflag == true)
        {
            npcshopopen.angcouflag = false;
            StartCoroutine(ang());

        }

        if (npcshopopen.recouflag == true)
        {
            npcshopopen.recouflag = false;
            StartCoroutine(rear());

        }
    }
   

    void Start()
    {
      
        DataManager.instance.csv_FileName = "NPC";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        Debug.Log("csv load");
        if(SceneManager.GetActiveScene().name == "1호선내부1")
        {
            StartCoroutine(jobstart());
        }
        shop = GameObject.Find("Shop");



    }
    

   

    void OnMouseDown(){

        Debug.Log("NPC clicked");
        StartCoroutine(NpcRoutine());
    }


    public IEnumerator rear()
    {
        Debug.Log("실행됨");
        ui_dialogue.SetActive(true);
        contextList = DataManager.instance.GetDialogue(1, 1);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        ui_dialogue.SetActive(false);
    }
    public IEnumerator jobstart()
    {
        if(jobflag==0)
        {
            Debug.Log("진행중2");
            ui_dialogue.SetActive(true);

            //물건 구매 기능 추가
            contextList = DataManager.instance.GetDialogue(40, 43);
            yield return StartCoroutine(DialogueManager.instance.processing(contextList));

            ui_dialogue.SetActive(false);
        }
       
    }

    public IEnumerator halstart()
    {
        Debug.Log("실행됨");
        ui_dialogue.SetActive(true);
        contextList = DataManager.instance.GetDialogue(59, 59);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        ui_dialogue.SetActive(false);

    }
    public IEnumerator ang()
    {
        Debug.Log("실행됨2");
        ui_dialogue.SetActive(true);
        contextList = DataManager.instance.GetDialogue(60, 60);
        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        ui_dialogue.SetActive(false);
    }
    public IEnumerator Job()
    {
        Debug.Log("실행됨3");
        ui_dialogue.SetActive(true);
        if (npcshopopen.sellflag == 1)
        {
            contextList = DataManager.instance.GetDialogue(44, 44);
            yield return StartCoroutine(DialogueManager.instance.processing(contextList));
            jobflag = 1;

        }

        else if (npcshopopen.sellflag == 2)
        {
            contextList = DataManager.instance.GetDialogue(45, 46);
            yield return StartCoroutine(DialogueManager.instance.processing(contextList));
            jobflag = 1;
        }
        ui_dialogue.SetActive(false);
    }
    public IEnumerator NpcRoutine(){
        ui_dialogue.SetActive(true);
        switch(gameObject.name){
                
                
                case "시비거는노인":
                    contextList = DataManager.instance.GetDialogue(2, 4);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;

                case "물건을 훔치는 노인":
                    contextList = DataManager.instance.GetDialogue(5, 11);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;
                
                case "헛소리 하는 노인":
                    contextList = DataManager.instance.GetDialogue(12, 19);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;

                case "도움이 필요해보이는 노인":
                    if(helpCount == 0){
                        contextList = DataManager.instance.GetDialogue(20, 22);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                        helpCount = 1;
                        
                        
                    }
                    else if(helpCount == 1&& GameManager.instance.SearchItem("안경")){
                        contextList = DataManager.instance.GetDialogue(23, 28);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                        GameManager.instance.RemoveItemString("안경");
                        helpCount = 2;
                    }
                    else if(helpCount == 1 && !GameManager.instance.SearchItem("안경"))
                    {
                        helpCount = 0;
                    }
                    else
                    { 
                        contextList = DataManager.instance.GetDialogue(29, 30);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }
                    break;
                
                

                case "사이비" :
                    contextList = DataManager.instance.GetDialogue(47, 51);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1){ //진짜요 선택지 
                        contextList = DataManager.instance.GetDialogue(52, 54);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                        saiitem = 1;
                    }
                    else if (DialogueManager.instance.chooseFlag == 3){ //시비를 건다 선택지 
                        contextList = DataManager.instance.GetDialogue(55, 58);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    godflag = 1;
                    break;
                
              

                case "소화전":
                    juckinter.juckactive = true;
                    contextList = DataManager.instance.GetDialogue(178, 178);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));

                    break;


            /*case "시비거는 취객":
                contextList = DataManager.instance.GetDialogue(61, 61);
                DialogueManager.instance.processChoose(contextList);
                yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                if (DialogueManager.instance.chooseFlag == 1){ //가위바위보 구현 필요 
                    contextList = DataManager.instance.GetDialogue(62, 62); //이겼을 때 대사 
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                }
                break;*/
            default : break;
        }
        ui_dialogue.SetActive(false);
    }
}
