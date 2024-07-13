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
    //public int ChooseFlag = 0;
    public  Dialogue[] contextList;

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
        if (contextList == null || contextList.Length == 0 || currentIdx >= contextList.Length)
            return;

        dialogue_text.text = contextList[currentIdx].contexts;
        name.text = contextList[currentIdx].name;

        if (!string.IsNullOrEmpty(contextList[currentIdx].chosen1))
        {
            chosen1_text.text = contextList[currentIdx].chosen1;
            chosen2_text.text = contextList[currentIdx].chosen2;
        }
        else
        {
            chosen1_text.text = "";
            chosen2_text.text = "";
        }
 
    }

}
