using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class b1_subwaytag : MonoBehaviour
{
    public static b1_subwaytag instance;
    public GameObject talksqu;
    int dialogueid;
    public bool moveB3; //3호선 이동 flag
    public bool uiflag = false;
    public Dialogue[] contextList;
    private void OnMouseDown()
    {
        if(Chungmuro_B1.done)//지하 1층에서의 상호작용이 모두 끝났을 때,
        {
            Debug.Log("개찰구 클릭");
           
            // DialogueManager.instance.ui_dialogue.SetActive(true);
            // DialogueManager.instance.name.text = "System";
            // DialogueManager.instance.dialogue_text.text = "교통카드를 태그할까요?";
            // DialogueManager.instance.chosen1_text.text = "네 (-1500)";
            // DialogueManager.instance.chosen2_text.text = "아니요";
            StartCoroutine(subwayTag());
        }
     

    }

    IEnumerator subwayTag()
    {
        //개찰구 태그
        Debug.Log("코루틴시작됨");
        uiflag = true;
        DialogueManager.instance.ui_dialogue.SetActive(true);
        DialogueManager.instance.name.text = "System";
        DialogueManager.instance.dialogue_text.text = "교통카드를 태그할까요?";
        DialogueManager.instance.chosen1_text.text = "네 (-1500)";
        DialogueManager.instance.chosen2_text.text = "아니요";

        Debug.Log("대화 시작, chooseFlag 초기값: " + DialogueManager.instance.chooseFlag);
    
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        
        Debug.Log("chooseFlag 변경됨: " + DialogueManager.instance.chooseFlag);
        
        if(DialogueManager.instance.chooseFlag == 1)
        {
            DialogueManager.instance.name.text = "System";
            DialogueManager.instance.dialogue_text.text = "나의 여정이 기록되었다.";
            if (JM_b1.instance != null)
            {
                Destroy(JM_b1.instance.gameObject);
                JM_b1.instance = null;
                Debug.Log("객체 삭제");
            }
            SceneManager.LoadScene("Start_Cutscene");
        }
        else{
            DialogueManager.instance.ui_dialogue.SetActive(false);
        }
        DialogueManager.instance.chooseFlag = 0;
        uiflag = false;

    }
    private IEnumerator tagroutine()
    {
        talksqu.SetActive(true);
        while(dialogueid<37)
        {
            switch(dialogueid)
            {
                case 34:
                    contextList = DataManager.instance.GetDialogue(75, 75);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueid = 35;
                    }
                    if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueid = 36;
                    }
                    DialogueManager.instance.chooseFlag = 0;
                    break;
                case 35:
                    contextList = DataManager.instance.GetDialogue(76, 76);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                   
                    dialogueid= 37;
                    break;
                case 36:
                    contextList = DataManager.instance.GetDialogue(77, 77);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));

                    dialogueid = 37;
                    break;
                default:
                    dialogueid = 37;
                    break;

            }
            talksqu.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogueid = 34;
        /*DataManager.instance.csv_FileName = "Prologue2";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드*/
       
    }

    // Update is called once per frame
    void Update()
    {
      
           
        
       
    }
}
