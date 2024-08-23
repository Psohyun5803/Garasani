using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tagcollider : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            StartCoroutine(subwayTag());
        }
        
    }


    IEnumerator subwayTag()
    {
        //개찰구 태그
        // DialogueManager.instance.ui_dialogue.SetActive(true);
        // DialogueManager.instance.name.text = "System";
        // DialogueManager.instance.dialogue_text.text = "교통카드를 태그할까요?";
        // DialogueManager.instance.chosen1_text.text = "네 (-1500)";
        // DialogueManager.instance.chosen2_text.text = "아니요";

        Debug.Log("대화 시작, chooseFlag 초기값: " + DialogueManager.instance.chooseFlag);
    
        yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
        
        Debug.Log("chooseFlag 변경됨: " + DialogueManager.instance.chooseFlag);
        
        if(DialogueManager.instance.chooseFlag == 1)
        {
            DialogueManager.instance.name.text = "System";
            DialogueManager.instance.dialogue_text.text = "나의 여정이 기록되었다.";
            if (JM_b1.instance != null)
            {
                Destroy(JM_b1.instance.gameObject);
                JM_b1.instance = null;
                Debug.Log("객체 삭제");
            }
            SceneManager.LoadScene("Start_Cutscene");
        }
        else{
            DialogueManager.instance.ui_dialogue.SetActive(false);
        }
        DialogueManager.instance.chooseFlag = 0;

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
