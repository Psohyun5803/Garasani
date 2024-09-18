using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerMoney;
    public List<Item> inventoryItems = new List<Item>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item newItem)
    {
        inventoryItems.Add(newItem);
    }

    public void RemoveItem(Item itemToRemove)
    {
        if (inventoryItems.Contains(itemToRemove))
        {
            inventoryItems.Remove(itemToRemove);
        }
    }

    public void AddGold(int amount)
    {
        playerMoney += amount;
        Debug.Log("골드 추가: " + amount);
    }

    public List<Item> GetShopItems()
    {
        // 상점에 표시할 아이템을 반환하는 메서드
        return inventoryItems;
    }

    // 판매할 때 호출되는 메서드
    public void SellItem(Item item)
    {
        // 아이템을 인벤토리에서 제거하고 골드를 추가
        RemoveItem(item);
        AddGold(item.itemPrice);
        Debug.Log("아이템 판매 완료: " + item.itemName);
    }
}