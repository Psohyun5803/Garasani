using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellManager : MonoBehaviour
{
    public static SellManager instance;  // 싱글톤 인스턴스
    public bool sellitem = false;
    public GameObject itemSlotPrefab;  // 아이템 슬롯 프리팹
    public Transform contentArea;  // 아이템 슬롯이 배치될 영역
    public List<Item> availableItems = new List<Item>();  // 구매할 수 있는 아이템 목록 (외부에서 설정)


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("SellManager instance 설정 완료.");
        }
        else
        {
            Debug.LogWarning("SellManager instance가 이미 존재합니다.");
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        LoadAvailableItems();
    }
    public void putinlist(List<Item> items)
    {
        availableItems = items;
        LoadAvailableItems();
    }

    public void SetAvailableItems(List<Item> items)
    {
        availableItems = items;
        LoadAvailableItems();
    }
   

    private void  LoadAvailableItems()
    {
        foreach (Transform child in contentArea)
        {
            Destroy(child.gameObject);  // 기존 슬롯 제거
        }

        foreach (var item in availableItems)
        {
            if (item != null)  // 아이템이 null인지 확인
            {
                CreateItemSlot(item);
            }
            else
            {
                Debug.LogWarning("Available item is null");
            }
        }
    }

    private void CreateItemSlot(Item item)
    {
        if (itemSlotPrefab == null || contentArea == null)  // null 체크
        {
            Debug.LogError("itemSlotPrefab or contentArea is not set.");
            return;
        }

        GameObject slot = Instantiate(itemSlotPrefab, contentArea);  // 슬롯 생성
        SellItemSlot itemSlot = slot.GetComponent<SellItemSlot>();   // 슬롯의 SellItemSlot 컴포넌트 가져옴

        if (itemSlot != null)  // null 체크
        {
            itemSlot.SetItem(item);  // 아이템 정보 설정

            // 버튼 클릭 이벤트 추가
            Button button = slot.GetComponent<Button>();
            button.onClick.AddListener(() => OnItemClicked(itemSlot));  // 클릭 시 실행할 메서드 등록
        }
        else
        {
            Debug.LogError("SellItemSlot component is missing in the item slot prefab.");
        }
    }

    private void OnItemClicked(SellItemSlot itemSlot)
    {
        Debug.Log("아이템 구매 시도: " + itemSlot.item.itemName);
        GameManager.instance.AddItem(itemSlot.item);  // 아이템을 GameManager에 추가 (구매)
        GameManager.instance.AddGold(-itemSlot.item.itemPrice);  // 아이템 가격만큼 돈 차감
        Debug.Log("아이템 구매 완료: " + itemSlot.item.itemName);
        sellitem = true;
    }
}