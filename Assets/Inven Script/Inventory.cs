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
    public Item[] items = new Item[14];
    public Slot[] slots = new Slot[20];


    public DoubleClickToggleButton toggleButton;

    void Start()
    {
       

        //??? ?? ??? 
        items[0] = new Item { name = "????", info = "???" };
        items[1] = new Item { name = "???", info = "????? ???? ?? ?" };
        items[2] = new Item { name = "??? ??", info = "????? ???? ?? ?" };
        items[3] = new Item { name = "???", info = "??? ???. ?? ??? ??? ??." };
        items[4] = new Item { name = "??", info = "??? ??. ?? ??? ??? ??.)" };
        items[5] = new Item { name = "?", info = "??? ??? ??? ??" };
        items[6] = new Item { name = "????", info = "??? ????. ???? ?? ??? ??? ??." };
        items[7] = new Item { name = "???", info = "????? ??? ???. ??? ??? ??? ?? ." };
        items[8] = new Item { name = "???", info = "??? ????? ?? ???." };
        items[9] = new Item { name = "???? ???", info = "?????? ? ??? ???." };
        items[10] = new Item { name = "??", info = "?????? ? ??." };
        items[11] = new Item { name = "? ???", info = "?????? ? ??." };
        items[12] = new Item { name = "???", info = "?????? ? ???. ????? ????." };
        items[13] = new Item { name = "???? ???", info = "?????? ? ??? ???." };


        // ?? ?? ??? 
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

        // ??? ?? ??? ??? ?? 
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemName == newItemName)
            {
                slots[i].quantity++;
                slots[i].quantityText.text = slots[i].quantity.ToString();
                Debug.Log($"?? ??? ?? ?? ??" + slots[i].quantity);
                toggleButton.UpdateQuantity(slots[i].quantity);
                itemAdded = true;
                break;
            }
        }

        // ? ??? ??? ??? ??
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
                    toggleButton.UpdateQuantity(slots[i].quantity);
                    Debug.Log("?? ? ??? ??" + slots[i].itemName);
                    break;
                }
            }
        }
    }
}
