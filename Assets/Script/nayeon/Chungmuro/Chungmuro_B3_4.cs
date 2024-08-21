using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chungmuro_B3_4 : MonoBehaviour
{
    public GameObject callWarning;
    private bool callFlag = false;
    public GameObject upstair;

    // Start is called before the first frame update
    void Start()
    {
        //플레이어 이동 설정 
        customize.sceneflag = 4;
        customize.moveflag = 1;
        //플레이어 위치 설정 
        Vector3 upstairPosition = upstair.transform.position;
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerObject.transform.position = new Vector3(upstairPosition.x, upstairPosition.y, upstairPosition.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (callWarning.activeSelf && callFlag == false)
        {
            callFlag = true;
            DialogueManager.instance.ui_dialogue.SetActive(true);
            DialogueManager.instance.name.text = customize.playername;
            DialogueManager.instance.dialogue_text.text = "안 되네...";
        }
    }
}