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
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("기존 인스턴스 파괴1 " + instance.GetInstanceID());
            gameObject.SetActive(false);

            // 기존 인스턴스가 있다면, 새로운 인스턴스는 파괴
            if (instance != this)
            {
                Destroy(gameObject);
                Debug.Log("기존 인스턴스 파괴2 " + instance.GetInstanceID());
                gameObject.SetActive(false);
            }
        }
        else
        {
            // 새 인스턴스가 없다면, 현재 인스턴스를 저장하고 씬 전환 시에도 유지
            instance = this;
            Debug.Log("새 인스턴스 생성 " + GetInstanceID());
            DontDestroyOnLoad(gameObject);
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
