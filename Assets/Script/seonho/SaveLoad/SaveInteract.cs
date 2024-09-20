using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class SaveInteract : MonoBehaviour
{
    public TMP_Text content;
    public GameObject talksqu;
    public GameObject button;
    public TMP_Text who;
    public TMP_Text option1;
    public TMP_Text option2;
    public GameObject options;

    private int gointer = 0;
    private string interobj;
    private Vector2 pos;

    public GameObject SaveUI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            if (gameObject.name == "개찰구" && gointer == 0)
            {
                pos = transform.position;
                interobj = "개찰구";
                Player.moveflag = 0;
                talksqu.SetActive(true);
                options.SetActive(true);
                button.SetActive(false);
                who.text = customize.playername;
                content.text = "이동할까?";
                option1.text = "> 태그를 찍는다.";
                option2.text = "> 태그를 찍지 않는다.";

                Debug.Log("텍스트가 설정되었습니다: " + content.text);
            }
        }
    }

    private void ClearOptions()
    {
        option1.text = "";
        option2.text = "";
    }

    public void ProcessChoice()
    {
        // 대화 매니저의 chooseFlag 값을 확인
        int choice = DialogueManager.instance.chooseFlag;
        Debug.Log("선택된 플래그: " + choice);

        if (interobj == "개찰구")
        {
            if (choice == 1)
            {
                SaveUI.SetActive(true);
                // 태그를 찍는다
                Player.moveflag = 1;
                button.SetActive(true);
                gointer = 1;
                Player.playertrans(transform.position.x - 3, transform.position.y);
                Debug.Log("플래그 1: 태그를 찍었다.");
            }
            else if (choice == 2)
            {
                Player.playertrans(pos.x + 1, pos.y); // 플레이어 이동 확인용 디버그
                Debug.Log("플레이어 이동: " + pos.x + 1 + ", " + pos.y);
                Player.moveflag = 1;
                button.SetActive(true);
                Debug.Log("플래그 2: 태그를 찍지 않았다.");
            }
            else
            {
                Debug.LogWarning("유효하지 않은 선택지");
            }
        }

        // 옵션 UI를 비활성화하고 선택이 완료되었음을 표시
        options.SetActive(false);
        talksqu.SetActive(false);

        if (DialogueManager.instance != null)
        {
            if (DialogueManager.instance.currentIdx < DialogueManager.instance.contextList.Length - 1)
            {
                DialogueManager.instance.onClickNextButton();  // 선택 후 대화 진행
            }
            else
            {
                Debug.Log("대화가 끝났습니다.");
                Player.moveflag = 1;  // 대화가 끝났으면 플레이어 움직임 활성화
            }
        }
        else
        {
            Debug.LogError("DialogueManager 인스턴스가 존재하지 않습니다.");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            interobj = null;
        }
    }

    public void buttondown()
    {
        if (interobj == "개찰구")
        {
            talksqu.SetActive(false);
            interobj = null;
            ClearOptions();
            content.text = "";
        }
    }

    void Start()
    {
        talksqu.SetActive(false);
        options.SetActive(false);
        button.SetActive(true);
        SaveUI.SetActive(false);

        customize.sceneflag = 2;
        customize.moveflag = 1;
    }

    void Update()
    {
        // 선택지 처리
        if (DialogueManager.instance.chooseFlag > 0)
        {
            ProcessChoice();  // 선택지에 따른 처리
            DialogueManager.instance.chooseFlag = 0;  // 처리 후 플래그 초기화
        }
    }
}