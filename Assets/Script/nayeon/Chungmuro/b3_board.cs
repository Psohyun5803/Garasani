using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b3_board : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("click");
        DialogueManager.instance.ui_dialogue.SetActive(true);
        DialogueManager.instance.name.text = "System";
        DialogueManager.instance.dialogue_text.text = "[진접행 : 운행종료 / 오이도행 : 운행종료]\n[당고개행: ..... (글씨가 깨져 읽을 수 없다)]";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
