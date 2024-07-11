using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prologue2Dialogue : MonoBehaviour
{
    public static Prologue2Dialogue instance;
    public TMP_Text dialogue_text;
    public TMP_Text name;
    private int currentDialogueIndex = 0; // 현재 대사 인덱스를 추적하는 변수
    private Dialogue[] contextList; // 대화 내용을 저장하는 배열
    private int currentContextIndex = 0; // 현재 문장 인덱스를 추적하는 변수

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void onClickNextButton()
    {
        if (contextList != null && currentDialogueIndex < contextList.Length)
        {
            DisplayDialogue(currentDialogueIndex, currentContextIndex);
            currentContextIndex++; // 다음 문장으로 이동

            if (currentContextIndex >= contextList[currentDialogueIndex].contexts.Length)
            {
                currentContextIndex = 0; // 문장 인덱스를 초기화
                currentDialogueIndex++; // 다음 대사로 이동
            }
        }
        else
        {
            // 대화가 끝난 경우 대화창 끔 
            DialogueOnOff.instance.ui_Dialogue.SetActive(false);
        }
    }

    public IEnumerator Prologue2()
    {
        contextList = DataManager.instance.GetDialogue(1, 7); // 대화 내용 가져오기
        currentDialogueIndex = 0; // 대화 시작 시 인덱스 초기화
        currentContextIndex = 0; // 문장 인덱스 초기화
        if (contextList.Length > 0)
        {
            DisplayDialogue(currentDialogueIndex, currentContextIndex);
        }
        yield break;

    }

    public string nameCheck(string name)
    {
        if (name.CompareTo("player") == 0) //주인공인 경우 이름을 바꿔준다.
        {
            name = customize.playername;
        }
        return name;
    }

    //public void Pro_id1()
    //{
    //    Dialogue[] contextList  = DataManager.instance.GetDialogue(1, 7);
    //    for(int i = 0; i < contextList.Length; i++)
    //    {
    //        name.text = nameCheck(contextList[i].name); //주인공인지 npc인지 구분
    //        string dialogueText = "";
    //        foreach (string context in contextList[i].contexts)
    //        {
    //            dialogueText += context + "\n"; // 각 문장을 줄바꿈으로 구분
    //        }
    //        dialogue_text.text = dialogueText;
    //        Debug.Log(name.text);
    //        Debug.Log(dialogue_text.text);
    //    }
    //}

    private void DisplayDialogue(int dialogueIndex, int contextIndex)
    {
        if (dialogueIndex < contextList.Length && contextIndex < contextList[dialogueIndex].contexts.Length)
        {
            name.text = nameCheck(contextList[dialogueIndex].name); // 주인공인지 NPC인지 구분
            dialogue_text.text = contextList[dialogueIndex].contexts[contextIndex];
            Debug.Log(name.text);
            Debug.Log(dialogue_text.text);
        }
    }

    //public void Pro_id2()
    //{

    //}
    //public void Pro_id3()
    //{

    //}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
