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
    //public TextMeshProUGUI itemText;
    //public TextMeshProUGUI quantityText;
    //public TextMeshProUGUI itemInfoText;
    public bool isItem;
}

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[30];
    public Slot[] slots = new Slot[20];

    public static Inventory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
       
        items[0] = new Item { name = "LED손전등", info = "어둠을 밝힐 수 있다." };
        items[1] = new Item { name = "건전지", info = "건전지." };
        items[2] = new Item { name = "교통카드", info = "개찰구에 찍어 세이브를 할 수 있다." };
        items[3] = new Item { name = "구호물품", info = "역 내에 있는 구호물품보관함에 있던 것이다." };
        items[4] = new Item { name = "김밥", info = "할머니에게서 산 김밥." };
        items[5] = new Item { name = "낡은책", info = "50대 아저씨가 볼 법한 책이다." };
        items[6] = new Item { name = "단소", info = "유명한 할아버지의 단소이다." };
        items[7] = new Item { name = "델리만쥬", info = "달달한 델리만쥬. 체력, 정신력 회복에 도움이 된다." };
        items[8] = new Item { name = "델리만쥬 봉투", info = "델리만쥬가 들어있는 봉투이다." };
        items[9] = new Item { name = "물", info = "마시면 정신력 회복에 도움이 된다." };
        items[10] = new Item { name = "반짝고글", info = "패션용 고글." };
        items[11] = new Item { name = "보조배터리", info = "핸드폰 충전에 사용할 수 있다." };
        items[12] = new Item { name = "복권", info = "인생 한방을 노려보자." };
        items[13] = new Item { name = "비상망치", info = "비상용 망치이다." };
        items[14] = new Item { name = "비상조명등", info = "비상용 조명." };
        items[15] = new Item { name = "사다리", info = "사다리." };
        items[16] = new Item { name = "소방도끼", info = "소방용 도끼." };
        items[17] = new Item { name = "소주", info = "취하고 싶을 때 마셔보자." };
        items[18] = new Item { name = "신문지", info = "언제 신문일까?" };
        items[19] = new Item { name = "에어팟한쪽", info = "누군가 두고 내린 에어팟 한쪽." };
        items[20] = new Item { name = "움직이는강아지", info = "잡상인에게 산 귀여운 강아지 장난감이다." };
        items[21] = new Item { name = "이온음료", info = "마시면 체력, 정신력 회복에 도움이 된다." };
        items[22] = new Item { name = "찐옥수수", info = "할머니에게서 산 옥수수." };
        items[23] = new Item { name = "찢겨진부적", info = "영문을 알 수 없는 글씨가 쓰여진 종이. 섬뜩하게 찢겨져있다." };
        items[24] = new Item { name = "캔커피", info = "마시면 정신력 회복에 도움이 된다." };
        items[25] = new Item { name = "키토산파스", info = "붙이면 체력 회복에 도움이 된다." };
        items[26] = new Item { name = "탄산음료1", info = "마시면 정신력 회복에 도움이 된다." };
        items[27] = new Item { name = "탄산음료2", info = "마시면 정신력 회복에 도움이 된다." };
        items[28] = new Item { name = "탄산음료3", info = "마시면 정신력 회복에 도움이 된다." };
        items[29] = new Item { name = "풀페이스두건", info = "패션용 두건." };


        // ?? ?? ??? 
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].itemName = "";
            slots[i].itemInfo = "";
            slots[i].quantity = 0;
            //slots[i].itemText.text = "";
            //slots[i].quantityText.text = "";
            //slots[i].itemInfoText.text = "";
        }
    }

    public void AddItem(string newItemName, string newItemInfo)
    {
        bool itemAdded = false;

        //add item 
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemName == newItemName)
            {
                slots[i].quantity++;
                //slots[i].quantityText.text = slots[i].quantity.ToString();
                DoubleClickToggleButton.instance.UpdateQuantity(slots[i].quantity); //수량 업데이트
                
                itemAdded = true;
                slots[i].isItem = true;
                item_setActive.instance.updateItem(slots[i].itemName);
                break;
            }
        }

        // new item 
        if (!itemAdded)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].itemName == "")
                {
                    slots[i].itemName = newItemName;
                    slots[i].itemInfo = newItemInfo;
                    slots[i].quantity = 1;
                    //slots[i].itemText.text = newItemName;
                    //slots[i].quantityText.text = "1";
                    //slots[i].itemInfoText.text = newItemInfo;
                    DoubleClickToggleButton.instance.UpdateQuantity(slots[i].quantity); //수량 업데이트

                    item_setActive.instance.updateItem(slots[i].itemName);
                    break;
                }
            }
        }
    }
}
