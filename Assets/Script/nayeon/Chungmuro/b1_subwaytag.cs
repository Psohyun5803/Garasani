using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class b1_subwaytag : MonoBehaviour
{
    public static b1_subwaytag instance;
    public bool moveB3; //3호선 이동 flag

    private void OnMouseDown()
    {
        Debug.Log("개찰구 클릭");
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
