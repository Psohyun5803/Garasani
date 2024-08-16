using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public GameObject ui_dialogue;

    public void onClickNext()
    {
        if(DialogueManager.instance.name.text == "System")
            ui_dialogue.SetActive(false);
    }

}
