using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMevent : MonoBehaviour
{
    public static JMevent instance;
    public GameObject ui_Dialogue;
    public bool isStart;
    public Dialogue[] contextList;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        isStart = false;
    }

    void OnMouseDown()
    {
        Debug.Log($"inSubway_0.instance: {inSubway_0.instance}");
        Debug.Log($"DataManager.instance: {DataManager.instance}");
        Debug.Log($"ui_Dialogue: {ui_Dialogue}");
        Debug.Log($"inSubway_1.instance: {inSubway_1.instance}");
        
        if (inSubway_0.instance.jmeventFlag == true)
        {
            if(isStart == false)
            {
                isStart = true; 
                Debug.Log("npc click");
                ui_Dialogue.SetActive(true);
                StartCoroutine(inSubway_1.instance.subwayStory());
            }
            else
            {
                StartCoroutine(HandleDialogue());
            }
            
        }
    }

    private IEnumerator HandleDialogue()
    {
        if (Prolog2_Item.instance.hammerflag == 1) // 망치 찾은 경우
        {
            contextList = DataManager.instance.GetDialogue(36, 36);
            yield return StartCoroutine(DialogueManager.instance.processing(contextList));
            contextList = DataManager.instance.GetDialogue(38, 38);
            yield return StartCoroutine(DialogueManager.instance.processing(contextList));
            inSubway_0.instance.dialogueID = 17;
        }
        else // 망치를 못 찾은 경우
        {
            contextList = DataManager.instance.GetDialogue(37, 37);
            yield return StartCoroutine(DialogueManager.instance.processing(contextList));
        }
    }
}
