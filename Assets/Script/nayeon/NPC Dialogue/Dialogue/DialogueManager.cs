using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TMP_Text dialogue_text;
    public TMP_Text name;
    public TMP_Text chosen1_text;
    public TMP_Text chosen2_text;

    public int currentIdx;
    public bool IsDialogueFinished;
    public  Dialogue[] contextList;
    public int chooseFlag = 0; //선택지 대화 flag
    public bool clickFlag = false; //선택지 1개인경우 click check
    private bool isChosenOne = false; //선택지 1개인 경우 

    private float delay = 0.05f; //타이핑 속도 
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }

    public void Initialize(Dialogue[] dialogues)
    {
        contextList = dialogues;
        currentIdx = 0;
        IsDialogueFinished = false;
        DisplayDialogue();
    }

    public void onClickNextButton()
    {
        if (contextList != null && currentIdx < contextList.Length - 1)
        {
            currentIdx++; 
            DisplayDialogue();
        }
        else
        {
            IsDialogueFinished = true;
            Debug.Log("contextlist �ʱ�ȭ �ȵ�");
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

        if(name.text != customize.playername) //npc player 구분 
        {
            dialogue_text.alignment = TextAlignmentOptions.Right;
        }
        else
        {
            dialogue_text.alignment = TextAlignmentOptions.Left;
        }

        typingCoroutine = StartCoroutine(textPrint(delay, contextList[currentIdx].contexts));
        
    }

    IEnumerator textPrint(float d, string text)
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
            isChosenOne = false;
        }
        else if (!string.IsNullOrEmpty(contextList[currentIdx].chosen1) && string.IsNullOrEmpty(contextList[currentIdx].chosen2))
        {
            chosen1_text.text = "";
            chosen2_text.text = contextList[currentIdx].chosen1;
            isChosenOne = true;
        }
        else
        {
            chosen1_text.text = "";
            chosen2_text.text = "";
        }
    }

    public void OnClickChoose()
    {
        if (isChosenOne) //선택지 1개인 경우
            clickFlag = true; 
        else
        {
            if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
                chooseFlag = 1;
            else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen2") == 0)
                chooseFlag = 2;
        }
    }

  

    public void processChoose(Dialogue[] dialogues) // choose 2
    {
        Initialize(dialogues);
    }

    public IEnumerator processing(Dialogue[] dialogues) //choose 1
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
    }
}