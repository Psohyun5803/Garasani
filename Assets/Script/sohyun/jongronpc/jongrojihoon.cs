using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class jongrojihoon : MonoBehaviour
{
    public static jongrojihoon instance;
    public GameObject ui_dialogue; //말풍선

    public TMP_Text context;
    public TMP_Text name;
    public GameObject choosen;
    int firstflag = 0;


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
        dialogueID = 3;



        ui_dialogue.SetActive(false);
        choosen.SetActive(true);


        DataManager.instance.csv_FileName = "jongroB1";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
      

    }

    void Update()
    {
        choosen.SetActive(true);
        if (onclicked.onclickedflag ==1&&firstflag==0)
        {
            StartCoroutine(B1jihoon());
        }
        if(onclicked.onclickedflag==1&&firstflag==1)
        {
            StartCoroutine(B1jihoon2());
        }
    }
   
    void dontmove()
    {
        customize.moveflag = 0;
        ui_dialogue.SetActive(true);

    }

    public IEnumerator B1jihoon()
    {
        ui_dialogue.SetActive(true);
        onclicked.onclickedflag = 0;
        while (dialogueID < 11)
        {
            switch (dialogueID)
            {
                case 3:
                    contextList = DataManager.instance.GetDialogue(4, 8);
                   
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 4;
                  


                  
                    break;
                case 4:
                    contextList = DataManager.instance.GetDialogue(9, 9);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueID = 5;

                    }
                    if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueID = 7;
                    }
                    DialogueManager.instance.chooseFlag = 0;

                    break;
                case 5:
                    contextList = DataManager.instance.GetDialogue(10, 10);
                    
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 6;

                    break;

                   
                case 6:
                    contextList = DataManager.instance.GetDialogue(11, 11);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueID = 9;

                    }
                    if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueID = 10;
                    }
                    DialogueManager.instance.chooseFlag = 0;

                    break;
                case 7:
                    contextList = DataManager.instance.GetDialogue(12, 15);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 6;

                    break;
                case 9:
                    contextList = DataManager.instance.GetDialogue(18, 18);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 11;

                    break;
                case 10:
                    contextList = DataManager.instance.GetDialogue(19, 20);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 11;

                    break;
                default:

                    dialogueID = 11;


                    break;
            }


        }

        ui_dialogue.SetActive(false);
        firstflag = 1;
        jihoon_B2.jihoonmove = 1;
        //StartCoroutine(cameramove.instance.JMmove());



    }

    public IEnumerator B1jihoon2()
    {
        ui_dialogue.SetActive(true);
        onclicked.onclickedflag = 0;
        dialogueID = 21;
        while (dialogueID < 24)
        {
            switch (dialogueID)
            {
                case 21:
                    contextList = DataManager.instance.GetDialogue(39, 39);

                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    Debug.Log(DialogueManager.instance.chooseFlag);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueID = 22;

                    }
                    if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueID = 24;

                    }

                    DialogueManager.instance.chooseFlag = 0;

                    break;




                  
                case 22:
                    contextList = DataManager.instance.GetDialogue(40, 41);
                   
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    dialogueID = 24;
                    break;
              
                default:

                    dialogueID = 24;


                    break;
            }


        }

        ui_dialogue.SetActive(false);
        firstflag = 2;
        //StartCoroutine(cameramove.instance.JMmove());



    }




    // Update is called once per frame
}
