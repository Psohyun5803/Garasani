using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogue; //커스텀 클래스 가져옴 

    //실제 대사 스크립트 꺼내오기 
    public Dialogue[] GetDialogue()
    {
        dialogue.dialouges = DataManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);
        return dialogue.dialouges;
    }
}
