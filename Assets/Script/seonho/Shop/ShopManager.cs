using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;  // 상점 UI
    public ShopSlot[] shopSlots;  // 상점에서 사용할 슬롯 배열
    public Image backgroundOverlay;  // 배경을 어둡게 처리할 오버레이 이미지
    public float backgroundOpacity = 0.5f;  // 배경 투명도

    private void Start()
    {
        shopUI.SetActive(false);
        InitializeShopSlots();
    }

    private void Update()
    {
        // ESC 키를 눌렀을 때 상점 UI를 닫기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseShop();
        }
    }

    // 상점 오브젝트 클릭 시 상점 UI를 띄움
    public void OpenShop()
    {
        Debug.Log("OpenShop called");
        shopUI.SetActive(true);
        SetBackgroundOpacity(true);  // 배경 어둡게 처리
    }

    // 상점 UI 닫기
    public void CloseShop()
    {
        shopUI.SetActive(false);
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

    // 상점 슬롯에 GameManager에서 아이템을 가져와 설정
    private void InitializeShopSlots()
    {
        List<Item> gameItems = GameManager.instance.GetShopItems(); // GameManager에서 아이템 목록 가져옴

        for (int i = 0; i < shopSlots.Length; i++)
        {
            if (i < gameItems.Count)  // 아이템이 슬롯 수보다 적으면 적용
            {
                shopSlots[i].SetItem(gameItems[i]);
            }
            else
            {
                shopSlots[i].ClearSlot();  // 빈 슬롯은 비워둠
            }
        }
    }

    // 아이템을 판매하는 메서드
    public void SellItem(int slotIndex)
    {
        // 인덱스가 유효한지 확인
        if (slotIndex < 0 || slotIndex >= shopSlots.Length)
        {
            Debug.LogError("Invalid slot index");
            return;
        }

        // 슬롯에서 아이템 가져오기
        ShopSlot slot = shopSlots[slotIndex];
        if (slot == null || slot.IsEmpty())
        {
            Debug.LogError("Slot is empty or does not exist");
            return;
        }

        Item itemToSell = slot.GetItem();
        if (itemToSell == null)
        {
            Debug.LogError("Item to sell is null");
            return;
        }

        int itemPrice = itemToSell.itemPrice;  // 아이템 가격 가져오기
        GameManager.instance.RemoveItem(itemToSell);  // GameManager에서 아이템 제거
        GameManager.instance.AddGold(itemPrice);  // GameManager에 골드 추가

        // 슬롯 비우기
        slot.ClearSlot();
    }
}