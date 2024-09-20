using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;  // 상점 UI
    public ShopSlot[] shopSlots;  // 상점에서 사용할 슬롯 배열

    private void Start()
    {
        InitializeShopSlots();
    }

    private void Update()
    {
        // ESC 키를 눌렀을 때 상점 UI를 닫기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopUI.SetActive(false);
            Player.moveflag = 1;
        }
        InitializeShopSlots();
    }

    private void InitializeShopSlots()
    {
        List<Item> inventoryItems = GameManager.instance.inventoryItems;

        for (int i = 0; i < shopSlots.Length; i++)
        {
            if (i < inventoryItems.Count)
            {
                shopSlots[i].SetItem(inventoryItems[i]);
            }
            else
            {
                shopSlots[i].ClearSlot();
            }
        }
    }

    // 아이템을 판매하는 메서드
    public void SellItem(int slotIndex)
    {
        Debug.Log("판매 시도 슬롯 인덱스: " + slotIndex);

        if (slotIndex < 0 || slotIndex >= shopSlots.Length)
        {
            Debug.LogError("유효하지 않은 슬롯 인덱스");
            return;
        }

        ShopSlot slot = shopSlots[slotIndex];
        if (slot.IsEmpty())
        {
            Debug.LogError("비어 있는 슬롯입니다."); // 이 메시지가 뜨는 이유 확인
            return;
        }

        Item itemToSell = slot.GetItem();
        if (itemToSell != null)
        {
            GameManager.instance.SellItem(itemToSell); // 아이템을 GameManager에서 판매
            slot.ClearSlot(); // 슬롯 비우기
            InitializeShopSlots(); // 상점 슬롯 업데이트
        }
    }
}