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

    public void SellItem(Item item)
    {
        playerMoney += item.itemPrice;  // 판매 가격만큼 골드 추가
        Debug.Log("판매 완료: " + item.itemName);
        // 인벤토리에서 해당 아이템 제거 로직 추가 가능
    }
}