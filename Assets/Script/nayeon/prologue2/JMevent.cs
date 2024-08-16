using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMevent : MonoBehaviour
{
    public static JMevent instance;
    public GameObject ui_Dialogue;
    public bool isStart;
    public Dialogue[] contextList;
    public bool hammerEvent = false;
    public bool isFirstClick = true;
    public bool hammerDialogue;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 인스턴스를 유지
            Debug.Log("Prolog2_Item 인스턴스 생성됨: " + GetInstanceID());
        }
        else
        {
            Debug.Log("기존 인스턴스 사용: " + instance.GetInstanceID());
            Destroy(gameObject); // 새로운 인스턴스가 생기지 않도록 파괴
        }

    }

    void Start()
    {
        isStart = false;
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown 호출됨");

        if (isFirstClick)
        {
            // 첫 번째 클릭에서는 이벤트를 설정하고 대화 준비
            if (inSubway_0.instance.jmeventFlag == true && isStart == false)
            {
                isStart = true;
                Debug.Log("npc click");
                ui_Dialogue.SetActive(true);
                StartCoroutine(inSubway_1.instance.subwayStory());
                isFirstClick = false;
                hammerEvent = true;
            }
        }
        else
        {
            // 두 번째 클릭에서 실제 이벤트 실행
            if (hammerEvent == true)
            {
                Debug.Log("hammer event "+hammerEvent);
                Debug.Log("hammerevent 직후 hammerDialogue " + hammerDialogue);
                ui_Dialogue.SetActive(true);
                if (hammerDialogue == true)
                {
                    StartCoroutine(inSubway_1.instance.subway_exit());
                }
                else
                {
                    StartCoroutine(inSubway_1.instance.subway_remain());
                }
                Debug.Log(" 끝나고 나서 hammerDialogue "+ hammerDialogue);
            }

            isFirstClick = true; // 다시 첫 번째 클릭 상태로 되돌림
        }
    }


}
