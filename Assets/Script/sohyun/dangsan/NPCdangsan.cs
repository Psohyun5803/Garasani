using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCdangsan : MonoBehaviour
{
    public int helpCount = 0;
    public static NPCdangsan instance;//참조도움

    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
   
    // Start is called before the first frame update
    void Update()
    {
       
    }
   

    void Start()
    {

        ui_dialogue.SetActive(false);
        DataManager.instance.csv_FileName = "dangsanB1";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        Debug.Log("csv load");
        Player.moveflag = 1;
        customize.sceneflag = 4;
       



    }
    

   

    void OnMouseDown(){

        Debug.Log("NPC clicked");
        StartCoroutine(NpcRoutine());
    }


    
    public IEnumerator NpcRoutine(){
        ui_dialogue.SetActive(true);
        switch(gameObject.name){
                
                
                case "이강도":
                    contextList = DataManager.instance.GetDialogue(1, 1);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;

                case "윤미호":
                    contextList = DataManager.instance.GetDialogue(2,2);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;
                
                case "신바람":
                    contextList = DataManager.instance.GetDialogue(3, 5);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;

                case "나창범":
                    contextList = DataManager.instance.GetDialogue(3, 5);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;



                case "노인 1" :
                contextList = DataManager.instance.GetDialogue(14, 18);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;

            case "노인 2":
                contextList = DataManager.instance.GetDialogue(14, 18);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;

            case "노인 3":
                contextList = DataManager.instance.GetDialogue(14, 18);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                break;



           
            default : break;
        }
        ui_dialogue.SetActive(false);
    }
}
