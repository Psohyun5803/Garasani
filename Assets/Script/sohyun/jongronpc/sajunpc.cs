using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class sajunpc : MonoBehaviour
{
    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    public TMP_Text text;//텍스트
    public static int sajuid = 20;
    public static bool ing = false;
    public static bool firstflag = true; 

    void Start()
    {

        DataManager.instance.csv_FileName = "NPC";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        Debug.Log("csv load");
       



    }
   

    void OnMouseDown()
    {
        Debug.Log("NPC clicked");
        StartCoroutine(NpcRoutine());
    }
    public IEnumerator NpcRoutine()
    {
       
        ui_dialogue.SetActive(true);
        while (sajuid < 40)
        {
            switch (sajuid)
            {
                case 20:
                    contextList = DataManager.instance.GetDialogue(65, 73);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    { //사주 보기 선택 
                      //돈 조정 
                        sajuid = 21;
                        firstflag = false;
                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    { sajuid = 40; 
                        }
                    
                    DialogueManager.instance.chooseFlag = 0;
                    break;
                case 21:
                    contextList = DataManager.instance.GetDialogue(74, 74);
                    text.fontSize = 7;
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    text.fontSize = 3;
                    sajuid = 22;
                    break;
                case 22:
                    contextList = DataManager.instance.GetDialogue(75, 77);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = Random.Range(23, 35);
                    break;
                case 23:
                    contextList = DataManager.instance.GetDialogue(78, 83);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 24:
                    contextList = DataManager.instance.GetDialogue(84, 91);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 25:
                    contextList = DataManager.instance.GetDialogue(92, 98);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 26:
                    contextList = DataManager.instance.GetDialogue(99, 103);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 27:
                    contextList = DataManager.instance.GetDialogue(104, 109);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 28:
                    contextList = DataManager.instance.GetDialogue(110, 115);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 29:
                    contextList = DataManager.instance.GetDialogue(116, 123);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 30:
                    contextList = DataManager.instance.GetDialogue(124, 128);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 31:
                    contextList = DataManager.instance.GetDialogue(129, 134);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 32:
                    contextList = DataManager.instance.GetDialogue(135, 138);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 33:
                    contextList = DataManager.instance.GetDialogue(139, 145);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 34:
                    contextList = DataManager.instance.GetDialogue(146, 148);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 35;
                    break;
                case 35:
                    contextList = DataManager.instance.GetDialogue(148, 154);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 36;
                    break;
                   
                case 36:
                    contextList = DataManager.instance.GetDialogue(155, 155);//와다닥 연출
                    DialogueManager.delay = 0.02f;
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    DialogueManager.delay = 0.05f;
                    sajuid = 37;
                    break;
                case 37:
                    contextList = DataManager.instance.GetDialogue(156, 165);

                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    { // 부적 사기 선택 
                      //돈 조정 
                        sajuid = 38;

                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        sajuid = 39;
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    break;
                   
                case 38:
                    contextList = DataManager.instance.GetDialogue(166, 166);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 40;
                    break;
                case 39:
                    contextList = DataManager.instance.GetDialogue(167, 167);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sajuid = 40;
                    break;
                default:
                    sajuid = 40;
                    break;

            }
            
           
        }

        ui_dialogue.SetActive(false);
        if (firstflag == true)
        {
            sajuid = 20;
        }





    }
}


