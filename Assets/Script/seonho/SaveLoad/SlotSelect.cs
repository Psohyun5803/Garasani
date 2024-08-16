using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlotSelect : MonoBehaviour
{
    public GameObject slotSelectionPanel; // 슬롯 선택 UI 패널
    public Button[] slotButtons; // 슬롯 버튼 배열
    public Button closeButton; // 닫기 버튼

    private void Start()
    {
        // 슬롯 버튼 클릭 이벤트 설정
        for (int i = 0; i < slotButtons.Length; i++)
        {
            int slotNumber = i + 1; // 슬롯 번호 설정
            slotButtons[i].onClick.AddListener(() => OnSlotButtonClicked(slotNumber));
        }

        // 닫기 버튼 클릭 이벤트 설정
        closeButton.onClick.AddListener(OnCloseButtonClicked);

        // 초기 상태는 UI를 비활성화
        slotSelectionPanel.SetActive(false);
    }

    public void Show()
    {
        // 슬롯 버튼 텍스트 업데이트
        UpdateSlotButtons();
        slotSelectionPanel.SetActive(true);
    }

    void OnSlotButtonClicked(int slotNumber)
    {
        if (SaveLoadManager.instance.IsSlotUsed(slotNumber))
        {
            // 저장된 상태로 게임 복원
            SaveLoadManager.GameState gameState = SaveLoadManager.instance.LoadGame(slotNumber);
            if (gameState != null)
            {
                PlayerController.instance.transform.position = gameState.playerPosition;
                // 추가적으로 필요한 데이터가 있으면 여기서 설정

                // UI를 숨기고 게임 진행
                slotSelectionPanel.SetActive(false);
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                Debug.LogError("게임 상태를 불러오는 데 실패했습니다.");
            }
        }
        else
        {
            Debug.Log("빈 슬롯을 선택했습니다. 아무 일도 일어나지 않습니다.");
        }
    }

    void OnCloseButtonClicked()
    {
        // UI를 숨김
        slotSelectionPanel.SetActive(false);
    }

    void UpdateSlotButtons()
    {
        for (int i = 0; i < slotButtons.Length; i++)
        {
            int slotNumber = i + 1;
            if (SaveLoadManager.instance.IsSlotUsed(slotNumber))
            {
                slotButtons[i].GetComponentInChildren<Text>().text = "Slot " + slotNumber + " (Used)";
            }
            else
            {
                slotButtons[i].GetComponentInChildren<Text>().text = "Slot " + slotNumber + " (Empty)";
            }
        }
    }
}