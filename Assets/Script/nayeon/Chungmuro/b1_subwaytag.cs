using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class b1_subwaytag : MonoBehaviour
{
    public static b1_subwaytag instance;
    public bool moveB3; //3호선 이동 flag

    private void OnMouseDown()
    {
        StartCoroutine(subwayTag());


    }

    IEnumerator subwayTag()
    {
        //개찰구 태그
        DialogueManager.instance.ui_dialogue.SetActive(true);
        DialogueManager.instance.name.text = "System";
        DialogueManager.instance.dialogue_text.text = "교통카드를 태그할까요?";
        DialogueManager.instance.chosen1_text.text = "네 (-1500)";
        DialogueManager.instance.chosen2_text.text = "아니요";
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        if(DialogueManager.instance.chooseFlag == 1)
        {
            DialogueManager.instance.name.text = "System";
            DialogueManager.instance.dialogue_text.text = "나의 여정이 기록되었다.";
        }

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