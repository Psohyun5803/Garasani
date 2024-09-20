using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSave : MonoBehaviour
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
    }

    public void Show()
    {
        // 슬롯 버튼 텍스트 업데이트
        UpdateSlotButtons();
        slotSelectionPanel.SetActive(true);
    }

    public void OnSlotButtonClicked(int slotNumber)
    {
        // 현재 게임 상태를 가져와서 저장
        SaveLoadManager.GameState gameState = new SaveLoadManager.GameState
        {
            playerPosition = PlayerController.instance.transform.position
        };

        SaveLoadManager.instance.SaveGame(slotNumber, gameState);

        Debug.Log("슬롯 " + slotNumber + "에 저장되었습니다.");
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