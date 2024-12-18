using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangsanB1kwang : MonoBehaviour
{
    public static NPCdangsan instance;//참조도움

    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    private int dialogueid=8;
    private bool twoflag = false;

    // Start is called before the first frame update
    void Update()
    {
        
    }


    void Start()
    {

      




    }




    void OnMouseDown()
    {

        Debug.Log("NPC clicked");
        if(twoflag==true)
        {
            StartCoroutine(NpcRoutine2());
        }
        else
        {
            StartCoroutine(NpcRoutine());
        }
        
        
    }



    public IEnumerator NpcRoutine()
    {
        ui_dialogue.SetActive(true);
        while (dialogueid < 11)
        {
            switch (dialogueid)
            {
                case 8:
                    contextList = DataManager.instance.GetDialogue(19, 19);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueid = 9;
                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueid = 10;
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    break;
                case 9:
                   
                    contextList = DataManager.instance.GetDialogue(20, 20);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueid = 11;
                    break;
                case 10:
                    contextList = DataManager.instance.GetDialogue(21, 21);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueid = 11;
                    break;

                
                default:
                    dialogueid = 11;
                    break;

            }


        }

        ui_dialogue.SetActive(false);
        //다른 아이템 장착시
        twoflag = true;
       

    }

    public IEnumerator NpcRoutine2()
    {
        twoflag = false;
        ui_dialogue.SetActive(true);
        while (dialogueid < 14)
        {
            switch (dialogueid)
            {
                case 11:
                    contextList = DataManager.instance.GetDialogue(22, 22);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueid = 12;
                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueid = 13;
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    break;
                case 12:

                    contextList = DataManager.instance.GetDialogue(23, 24);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueid = 14;
                    break;
                case 13:
                    contextList = DataManager.instance.GetDialogue(25, 26);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueid = 14;
                    break;


                default:
                    dialogueid = 14;
                    break;

            }


        }

        ui_dialogue.SetActive(false);


    }
}
