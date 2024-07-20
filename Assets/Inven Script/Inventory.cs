using UnityEngine;
using TMPro;

[System.Serializable]
public struct Item
{
    public string name;
    public string info;
}

[System.Serializable]
public struct Slot
{
    public string itemName;
    public string itemInfo;
    public int quantity;
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI itemInfoText;
}

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[6];
    public Slot[] slots = new Slot[5];

    void Start()
    {
        items[0] = new Item { name = "예1", info = "예시1" };
        items[1] = new Item { name = "예2", info = "예시2" };
        items[2] = new Item { name = "예3", info = "예시3" };
        items[3] = new Item { name = "예4", info = "예시4" };
        items[4] = new Item { name = "예5", info = "예시5" };
        items[5] = new Item { name = "예6", info = "예시6" };

        // 초기화 시 슬롯의 아이템 이름을 빈 문자열로 설정
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].itemName = "";
            slots[i].itemInfo = "";
            slots[i].quantity = 0;
            slots[i].itemText.text = "";
            slots[i].quantityText.text = "";
            slots[i].itemInfoText.text = "";
        }
    }

    public void AddItem(string newItemName, string newItemInfo)
    {
        bool itemAdded = false;

        // 이미 있는 아이템인지 확인
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemName == newItemName)
            {
                slots[i].quantity++;
                slots[i].quantityText.text = slots[i].quantity.ToString();
                Debug.Log($"슬롯 {i + 1}: {newItemName} (수량: {slots[i].quantity})");
                itemAdded = true;
                break;
            }
        }

        // 새로운 아이템이면 빈 슬롯에 추가
        if (!itemAdded)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].itemName == "")
                {
                    slots[i].itemName = newItemName;
                    slots[i].itemInfo = newItemInfo;
                    slots[i].quantity = 1;
                    slots[i].itemText.text = newItemName;
                    slots[i].quantityText.text = "1";
                    slots[i].itemInfoText.text = newItemInfo;
                    Debug.Log($"슬롯 {i + 1}: {newItemName} (수량: 1)");
                    break;
                }
            }
        }
    }
}
