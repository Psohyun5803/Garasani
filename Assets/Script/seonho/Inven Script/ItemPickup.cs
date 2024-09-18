using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;  // 주울 아이템 데이터

    private void OnMouseDown()
    {
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager != null)
        {
            inventoryManager.AddItemToSlot(item);
            Destroy(gameObject); // 아이템 오브젝트를 게임에서 제거
        }
    }
}