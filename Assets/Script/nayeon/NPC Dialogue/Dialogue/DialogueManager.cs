using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject ui_dialogue;
    public TMP_Text dialogue_text;
    public TMP_Text name;
    public TMP_Text chosen1_text;
    public TMP_Text chosen2_text;
  
    //public TMP_Text chosen3_text;
    public static int jungminemoflag;
    public static int jihoonemoflag;
    //public TMP_Text chosen3_text;

    public int currentIdx;
    public bool IsDialogueFinished;
    public Dialogue[] contextList;
    public int chooseFlag = 0; //선택지 대화 flag
    public bool clickFlag = false; //선택지 1개인경우 click check
    private bool isChosenOne = false; //선택지 1개인 경우 

    public static float delay = 0.05f; //타이핑 속도 
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void Initialize(Dialogue[] dialogues)
    {
        contextList = dialogues;
        currentIdx = 0;
        IsDialogueFinished = false;
        Player.moveflag = 0;
      
        DisplayDialogue();
    }

    public void onClickNextButton()
    {
        if (contextList != null && currentIdx < contextList.Length - 1)
        {
            currentIdx++;
            DisplayDialogue();
            Debug.Log("next button click");
        }
        else
        {
            Player.moveflag = 1;
            IsDialogueFinished = true;
            Debug.Log("contextlist 없음");
        }
    }

    public void DisplayDialogue()
    {
        isTyping = true;
        if (contextList == null || contextList.Length == 0 || currentIdx >= contextList.Length)
            return;

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }


        dialogue_text.text = "";
        chosen1_text.text = "";
        chosen2_text.text = "";
        name.text = contextList[currentIdx].name;
        jihoonemoflag = contextList[currentIdx].jihoonemo;
        jungminemoflag = contextList[currentIdx].jungminemo;
        dialogue_text.alignment = TextAlignmentOptions.Left;//둘 다 왼쪽 정렬 -소현수정
        /*if (name.text == customize.playername || name.text == "System") //npc player 정렬 구분 
        {
            dialogue_text.alignment = TextAlignmentOptions.Left;
        }
        else
        {
            dialogue_text.alignment = TextAlignmentOptions.Right;
        }*/

        typingCoroutine = StartCoroutine(textPrint(delay, contextList[currentIdx].contexts));
    }

    IEnumerator textPrint(float d, string text) //타이핑 효과 코루틴 
    {
        int count = 0;

        while (count != text.Length)
        {
            if (count < text.Length)
            {
                dialogue_text.text += text[count].ToString();
                count++;
            }

            yield return new WaitForSeconds(delay);
        }

        isTyping = false;
        ShowChoices();
    }


    private void ShowChoices()
    {
        if (!string.IsNullOrEmpty(contextList[currentIdx].chosen1) && !string.IsNullOrEmpty(contextList[currentIdx].chosen2))
        {
            chosen1_text.text = contextList[currentIdx].chosen1;
            chosen2_text.text = contextList[currentIdx].chosen2;
            //chosen3_text.text = contextList[currentIdx].chosen3;
           // chosen3_text.text = contextList[currentIdx].chosen3;
            isChosenOne = false;
        }
        else if (!string.IsNullOrEmpty(contextList[currentIdx].chosen1) && string.IsNullOrEmpty(contextList[currentIdx].chosen2))
        {
            chosen1_text.text = "";
            chosen2_text.text = contextList[currentIdx].chosen1;
          //  chosen3_text.text = "";
            isChosenOne = true;
        }
        else
        {
            chosen1_text.text = "";
            chosen2_text.text = "";
            //chosen3_text.text = "";
           // chosen3_text.text = "";
        }
    }

    public void OnClickChoose()
    {
        if (name.text == "System"){
            if(chosen1_text.text != ""){
                if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
                    chooseFlag = 1;
                else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen2") == 0)
                    chooseFlag = 2;
                //else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen3") == 0)
                  //  chooseFlag = 3;
            }
            else{
                ui_dialogue.SetActive(false);
            }
        }
        else if (isChosenOne) //선택지 1개인 경우
            clickFlag = true;
        else
        {
            if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
                chooseFlag = 1;
            else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen2") == 0)
                chooseFlag = 2;
            Debug.Log("선택지 클릭");
            Debug.Log("choose : " + chooseFlag);

        }
    }



    public void processChoose(Dialogue[] dialogues) // 선택지 있는 경우 
    {
        Initialize(dialogues);
    }

    public IEnumerator processing(Dialogue[] dialogues) //선택지 없는 경우 
    {
        Initialize(dialogues);
        yield return new WaitUntil(() => IsDialogueFinished);

    }

    void Update()
    {
        // typing effect

        if (isTyping && EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.name == "말풍선")
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                typingCoroutine = null;
            }

            dialogue_text.text = contextList[currentIdx].contexts;
            isTyping = false;

            ShowChoices();
        }
        if (Input.GetKeyDown(KeyCode.Return)) //-소현수정 enter누르면 넘어가게 
        {
            if (contextList != null && currentIdx < contextList.Length - 1)
            {
                currentIdx++;
                DisplayDialogue();
                Debug.Log("next button click");
            }
            else
            {
                Player.moveflag = 1;
                IsDialogueFinished = true;
                Debug.Log("contextlist 없음");
            }
        }
    }
}