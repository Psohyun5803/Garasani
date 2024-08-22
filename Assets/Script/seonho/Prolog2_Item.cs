using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prolog2_Item : MonoBehaviour
{
    public static Prolog2_Item instance;
    public TMP_Text content;
    public TMP_Text name; //?? 
    public GameObject talkBubble;
    public GameObject hammer;
    public GameObject hammerInfo;

    public bool hammerflag;
    public Vector3 newPlayerPosition;
    public Vector3 newPlayerScale;
    public Inventory inventory; // Inventory 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 인스턴스를 유지
        }

    }

    private void Start()
    {
        hammerflag = false;
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로드 이벤트 구독
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 씬 로드 이벤트 구독 해제
    }

    //IEnumerator b2Moving()
    //{
    //    yield return StartCoroutine(inSubway_1.instance.pre_B2());
    //}

    void OnMouseDown()
    {
        Debug.Log("Mouse Click");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.colitemname);
        Debug.Log("Hammer flag: " + hammerflag);

        if (intertest.colitemname == "비상문")
        {
            talkBubble.SetActive(true);
            DialogueManager.instance.name.text = "System";

            if (hammerflag == true)
            {
                DialogueManager.instance.dialogue_text.text = "창문을 깨고 밖으로 나가자.";
                Debug.Log("Loading scene Chungmuro_B2");
                newPlayerPosition = new Vector3(7, 2, 0);
                newPlayerScale = new Vector3(0.5f, 0.5f, 0.5f);
                StartCoroutine(inSubway_1.instance.pre_B2());
                //SceneManager.LoadScene("Chungmuro_B2"); //지하 2층 계단 이동 
            }
            else
            {
                DialogueManager.instance.dialogue_text.text = "여길 통해서 나갈 수 있을 것 같다. 방법을 찾아보자.";
            }
        }

        else if (intertest.colitemname == "비상망치")
        {
            if(JMevent.instance.hammerEvent == true)
            {
                talkBubble.SetActive(true);
                DialogueManager.instance.name.text = "System";
                DialogueManager.instance.dialogue_text.text = "[비상망치] : 이걸로 창문을 깨고 나갈 수 있을 것 같다.";
                hammer.SetActive(false);
                hammerInfo.SetActive(false);
                inventory.AddItem("비상망치");
                JMevent.instance.hammerDialogue = true;
                Debug.Log("Hammer collected, hammerflag set true");
                Debug.Log("hammer dialogue : " + JMevent.instance.hammerDialogue);
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 새 씬이 로드된 후 플레이어의 위치를 설정합니다.
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            player.transform.position = newPlayerPosition;
            Debug.Log("Player position set to " + newPlayerPosition);
        }
        else
        {
            Debug.LogWarning("Player object not found!");
        }
    }

}