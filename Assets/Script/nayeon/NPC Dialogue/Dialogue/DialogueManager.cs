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
    public int chooseFlag = 0; //선택지 2개인 경우 flag값 
    public bool clickFlag = false; //선택지가 1개인경우 클릭 확인 
    private bool isChosenOne = false; //선택지가 1개인경우

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
            currentIdx++; // 다음 문장으로 이동
            DisplayDialogue();
        }
        else
        {
            IsDialogueFinished = true;
            Debug.Log("contextlist 초기화 안됨");
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

        if(name.text != customize.playername) //주인공과 npc 왼쪽,오른쪽 정렬 구분 
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
        Debug.Log("선택지 클릭 확인");
        //태그가 1이면 번호 1리턴, 2면 2리턴
        if (isChosenOne)
            clickFlag = true;
        else
        {
            if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
                chooseFlag = 1;
            else if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen2") == 0)
                chooseFlag = 2;
        }

        Debug.Log(clickFlag);
    }

  

    public void processChoose(Dialogue[] dialogues) //선택지가 있는 대화인 경우 사용 
    {
        Initialize(dialogues);
    }

    public IEnumerator processing(Dialogue[] dialogues) //선택지가 없는 대화인 경우 사용 
    {
        Initialize(dialogues);
        yield return new WaitUntil(() => IsDialogueFinished);

    }

    void Update()
    {
        // 마우스 클릭으로 타이핑효과 코루틴 멈추고 대사 즉시 출력
        if (isTyping && EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.name == "말풍선")
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                typingCoroutine = null;
            }

            dialogue_text.text = contextList[currentIdx].contexts;
            isTyping = false;

            ShowChoices(); // 즉시 대사 출력 후 선택지 출력
        }
    }
}
