using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class darktrain : MonoBehaviour
{
    public static darktrain instance;
    public GameObject ui_dialogue; //말풍선
    
    public TMP_Text context;
    public TMP_Text name;
  

    
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
        dialogueID = 1;
       


        ui_dialogue.SetActive(false);

        
        DataManager.instance.csv_FileName = "traindark";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        StartCoroutine(darkStart());

    }

    void Update()
    {
        if(onclicked.onclickedflag==1)
        {
            StartCoroutine(jihoonclicked());

        }
    }
    void dontmove()
    {
        customize.moveflag = 0;
        ui_dialogue.SetActive(true);

    }

    public IEnumerator darkStart()
    {
        ui_dialogue.SetActive(true);
      
        while (dialogueID < 5)
        {
            switch (dialogueID)
            { 
                case 1:
                    contextList = DataManager.instance.GetDialogue(1, 4);
                    Debug.Log(contextList.Length);
                    for(int i=0;i<contextList.Length;i++)
                    {
                        Debug.Log(contextList[i].contexts);
                    }
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    
                    
                    dialogueID = 2;
                    break;
                case 2:
                    contextList = DataManager.instance.GetDialogue(5, 5);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag==1)
                    {
                        dialogueID = 3;
                    }
                    if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueID = 4;
                    }
                    DialogueManager.instance.chooseFlag = 0;

                    break;
                case 3:
                    contextList = DataManager.instance.GetDialogue(6,6 );
                    train1_dark.gifnum = 1;
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                   
                    dialogueID = 5;


                    break;
                case 4:
                    contextList = DataManager.instance.GetDialogue(7, 7);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    train1_dark.gifnum = 1;
                    dialogueID = 5;
                    break;

                default:
                  
                    dialogueID = 5;
                    

                    break;
            }
           

        }

        train1_dark.gifnum = 0;
        train1_dark.darkflag = 2;
        ui_dialogue.SetActive(false);
        //StartCoroutine(cameramove.instance.JMmove());
      


    }
    public IEnumerator jihoonclicked()
    {
        onclicked.onclickedflag = 0;
        ui_dialogue.SetActive(true);
        while (4 < dialogueID &&dialogueID< 6)
        {
            
            switch (dialogueID)
            {
                case 5:

                    contextList = DataManager.instance.GetDialogue(8, 9);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                   
                   
                    dialogueID = 6;
                    break;
                    //쪽지 얻는 inventory 함수 넣기 
                default:
                    dialogueID = 6;
                    break;

            }
        }
        ui_dialogue.SetActive(false);
    }



    // Update is called once per frame


}
