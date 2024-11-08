using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sibinpc : MonoBehaviour
{
    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    public TMP_Text text;//텍스트
    public static double sibiid = 40;
   
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
        if(firstflag==true)
        {
            StartCoroutine(NpcRoutine());
        }
       
    }
    public IEnumerator NpcRoutine()
    {

        ui_dialogue.SetActive(true);
        while (sibiid < 50)
        {
            switch (sibiid)
            {
                case 40:
                    contextList = DataManager.instance.GetDialogue(168, 168);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sibiid = 41;
                    break;
                case 41:
                 
                    contextList = DataManager.instance.GetDialogue(169, 169);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    { //가위바위보 함.
                        sibiid = 42;
                        //sibiid = Random.Range(44, 47); 
                        firstflag = false;
                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {//가위바위보 안 함 
                        sibiid = 50;
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    break;
                case 42:
                    contextList = DataManager.instance.GetDialogue(170, 170);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sibiid = 43;
                    break;
                case 43:
                    contextList = DataManager.instance.GetDialogue(171, 171);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sibiid = Random.Range(44, 47);
                    break;
                case 44:
                    contextList = DataManager.instance.GetDialogue(172, 172);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sibiid = 47;
                    break;
                case 45:
                    contextList = DataManager.instance.GetDialogue(173, 173);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sibiid = 49;
                    break;
                case 46:
                    contextList = DataManager.instance.GetDialogue(174, 174);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sibiid = 48;
                    break;
                case 47:
                    contextList = DataManager.instance.GetDialogue(175, 175);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sibiid = 50;
                    break;
                case 48:
                    contextList = DataManager.instance.GetDialogue(176, 176);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sibiid = 50;
                    break;
                case 49:
                    contextList = DataManager.instance.GetDialogue(177, 177);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    sibiid = 50;
                    break;
                default:
                    sibiid = 50;
                    break;

            }


        }

        ui_dialogue.SetActive(false);
        if( firstflag == true)
        {
            sibiid = 40;
        }





    }
}
