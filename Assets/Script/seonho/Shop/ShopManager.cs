using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;  // 상점 UI
    public GameObject inventoryUI;  // 새로운 인벤토리 UI
    public InventorySlot[] shopSlots;  // 상점에서 사용할 슬롯 배열
    public Image backgroundOverlay;  // 배경을 어둡게 처리할 오버레이 이미지
    public TMP_Text itemNameText;  // 아이템 이름 텍스트
    public TMP_Text itemPriceText;  // 아이템 가격 텍스트
    public float backgroundOpacity = 0.5f;  // 배경 투명도

    private void Start()
    {
        shopUI.SetActive(false);
        inventoryUI.SetActive(false);
    }

    // 상점 오브젝트 클릭 시 상점 UI와 인벤토리 UI를 띄움
    public void OpenShop()
    {
        shopUI.SetActive(true);
        inventoryUI.SetActive(true);
        SetBackgroundOpacity(true);  // 배경 어둡게 처리
    }

    // 상점 UI 닫기
    public void CloseShop()
    {
        shopUI.SetActive(false);
        inventoryUI.SetActive(false);
        SetBackgroundOpacity(false);  // 배경 밝기 복원
    }

    // 배경의 오퍼시티를 조절하는 함수
    private void SetBackgroundOpacity(bool isActive)
    {
        if (isActive)
        {
            backgroundOverlay.color = new Color(0, 0, 0, backgroundOpacity);
        }
        else
        {
            backgroundOverlay.color = new Color(0, 0, 0, 0);  // 배경 밝기 복원
        }
    }
}