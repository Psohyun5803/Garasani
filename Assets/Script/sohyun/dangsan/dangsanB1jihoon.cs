using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangsanB1jihoon : MonoBehaviour
{
    public static NPCdangsan instance;//참조도움

    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    private int dialogueid = 4;
   

    // Start is called before the first frame update
    void Update()
    {

    }


    void Start()
    {


        jihoon_B2.jihoonmove = 0;



    }




    void OnMouseDown()
    {

        Debug.Log("NPC clicked");
       
        StartCoroutine(NpcRoutine());
        


    }



    public IEnumerator NpcRoutine()
    {
        ui_dialogue.SetActive(true);
        while (dialogueid < 7)
        {
            switch (dialogueid)
            {
                case 4:
                    contextList = DataManager.instance.GetDialogue(6, 6);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueid = 5;
                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueid = 6;
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    break;
                case 5:

                    contextList = DataManager.instance.GetDialogue(7, 10);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueid = 7;
                    break;
                case 6:
                    contextList = DataManager.instance.GetDialogue(11, 13);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueid = 7;
                    break;


                default:
                    dialogueid = 7;
                    break;

            }


        }

        ui_dialogue.SetActive(false);
        jihoon_B2.jihoonmove = 1;


    }

    
}
