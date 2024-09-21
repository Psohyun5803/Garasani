using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI;   // 인벤토리 UI
    public Transform playerUI;  // 플레이어 오브젝트를 나타낼 위치(UI)
    private GameObject playerInstance;  // 씬의 Player 오브젝트 인스턴스
    public InventorySlot[] slots;    // 20개의 슬롯 배열

    public Image equippedItemImage;  // 장착된 아이템 슬롯
    public TMP_Text equippedItemName;  // 장착된 아이템 이름
    public TMP_Text equippedItemDescription;  // 장착된 아이템 설명
    public bool isInventoryOpen = false; // 인벤토리 UI 상태
    public Item equippedItem;

    private void Start()
    {
        inventoryUI.SetActive(false);
        UpdatePlayerImage();
        LoadInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
        if (isInventoryOpen)
        {
            LoadInventory(); // 아이템 리스트를 주기적으로 업데이트
        }
    }

    // 씬에서 Player 오브젝트를 찾아서 플레이어 UI에 반영
    void UpdatePlayerImage()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerInstance = Instantiate(player, playerUI);  // Player 오브젝트를 복제하여 UI에 배치
            playerInstance.transform.localScale = Vector3.one;  // 적절한 크기 조정 (필요시 변경)
        }
    }

    // 아이템을 슬롯에 추가하는 함수
    public void AddItemToSlot(Item newItem)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.SetItem(newItem);
                GameManager.instance.AddItem(newItem);  // GameManager에 아이템 추가
                break;
            }
        }
    }

    // 인벤토리 열기/닫기
    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);
    }

    // 아이템 장착 함수
    public void EquipItem(Item newItem)
    {
        equippedItem = newItem;  // 현재 장착된 아이템을 새 아이템으로 교체

        // UI에 장착된 아이템 정보 업데이트
        equippedItemImage.sprite = newItem.itemSprite;
        equippedItemName.text = newItem.itemName;
        equippedItemDescription.text = newItem.itemDescription;

        Debug.Log("장착된 아이템: " + equippedItem.itemName);
    }

    // 씬 이동 후 인벤토리 상태 로드
    private void LoadInventory()
    {
        List<Item> inventoryItems = GameManager.instance.inventoryItems;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventoryItems.Count)
            {
                slots[i].SetItem(inventoryItems[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  // 씬이 로드될 때 호출되는 이벤트 등록
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // 이벤트 해제
    }

    // 씬 이동 시 아이템 상태를 로드하는 함수
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadInventory();  // 씬이 로드될 때 인벤토리 상태를 로드
    }
}