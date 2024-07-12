using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Prologue2Dialogue : MonoBehaviour
{
    public static Prologue2Dialogue instance;
    public int dialogueID;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void prologue2()
    {
        dialogueID = 1;
        //dialogueID = 1;
        switch (dialogueID)
        {
            case (1):
                pro_id1(DataManager.instance.GetDialogue(1, 7));
                break;
            case (2):
                pro_id2(DataManager.instance.GetDialogue(8, 8));
                break;
            case (3):
                pro_id3(DataManager.instance.GetDialogue(9, 9));
                break;
            default:
                break;
        }
    }




    public void pro_id1(Dialogue[] dialogues)
    {
        DialogueManager.instance.DisplayDialogue(dialogues);
        if (DialogueManager.instance.ChooseFlag == 1)
        {
            dialogueID = 2;
        }
        else
        {
            dialogueID = 3;
        }
        Debug.Log(dialogueID);
    }

    public void pro_id2(Dialogue[] dialogues)
    {
        DialogueManager.instance.DisplayDialogue(dialogues);
        Debug.Log("id2");
        dialogueID = 4;
    }

    public void pro_id3(Dialogue[] dialogues)
    {
        DialogueManager.instance.DisplayDialogue(dialogues);
        Debug.Log("id3");
        dialogueID = 4;
    }



}
