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
        DisplayDialogue(contextList);
    }

    public void onClickNextButton()
    {
        if (contextList != null && currentIdx < contextList.Length - 1)
        {
            currentIdx++; // 다음 문장으로 이동
            DisplayDialogue(contextList);
        }
        else
        {
            Debug.Log("contextlist 초기화 안됨");
        }
    }

    //public void OnClickChoose()
    //{
    //    Debug.Log("선택지 클릭 확인");
    //    //태그가 1이면 번호 1리턴, 2면 2리턴
    //    if (EventSystem.current.currentSelectedGameObject.tag.CompareTo("chosen1") == 0)
    //        ChooseFlag = 1;
    //    else ChooseFlag = 2;
    //    Debug.Log(ChooseFlag);
    //}

    public void DisplayDialogue(Dialogue[] dialogues)
    {
        contextList = dialogues;
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
