// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // [System.Serializable]
// // // public struct Item
// // // {
// // //     public string name;
// // //     public string info;
// // //     public Sprite itemImage;
// // // }

// // [System.Serializable]
// // public struct Slot
// // {
// //     public string itemName;
// //     public string itemInfo;
// //     public int quantity;
// //     //public TextMeshProUGUI itemText;
// //     //public TextMeshProUGUI quantityText;
// //     //public TextMeshProUGUI itemInfoText;
// //     public bool isItem;
// // }

// public class Inventory : MonoBehaviour
// {
//     public List<Item> items; //아이템 담을 리스트 

//     [SerializeField]
//     private Transform slotParent; //슬롯 부모 
//     [SerializeField]
//     private Slot[] slots; //각 슬롯 

// #if UNITY_EDITOR
//     private void OnValidate() { //슬롯 자동 등록 
//         slots = slotParent.GetComponentsInChildren<Slot>();
//     }
// #endif

//     void Awake() { //Item.cs의 아이템을 인벤토리에 넣음 
//         FreshSlot();
//     }

//     public void FreshSlot() {
//         int i = 0;
//         for (; i < items.Count && i < slots.Length; i++) {
//             slots[i].item = items[i];
//         }
//         for (; i < slots.Length; i++) {
//             slots[i].item = null;
//         }
//     }

//     public void AddItem(Item _item) {
//         // if (items.Count < slots.Length) {
//         //     items.Add(_item);
//         //     FreshSlot();
//         // } else {
//         //     print("슬롯이 가득 차 있습니다.");
//         // }

//         // 먼저 빈 슬롯을 찾는다
//         for (int i = 0; i < slots.Length; i++) {
//             if (slots[i].item == null) { // 빈 슬롯을 찾음
//                 items.Add(_item); // 아이템을 리스트에 추가
//                 slots[i].item = _item; // 슬롯에 아이템 할당
//                 return;
//             }
//         }
//     }

//     // // public Item[] items = new Item[31];
//     // // public Slot[] slots = new Slot[20];

//     // public static Inventory instance;

//     // private void Awake()
//     // {
//     //     if (instance == null)
//     //     {
//     //         instance = this;
//     //         DontDestroyOnLoad(gameObject);
//     //     }
//     //     else
//     //     {
//     //         Destroy(gameObject);
//     //     }
//     // }


//     // void Start()
//     // {

//     // public void AddItem(string newItemName)
//     // {
//     //     bool itemAdded = false;

//     //     newItemName = newItemName.Trim();
//     //     // Find the index of the item in the items array
//     //     int itemIndex = -1;
//     //     for (int j = 0; j < items.Length; j++)
//     //     {
//     //         Debug.Log("Trying to add item: " + newItemName);
//     //         if (items[j].name.Equals(newItemName))
//     //         {
//     //             Debug.Log("item found");
//     //             itemIndex = j;
//     //             break;
//     //         }
//     //     }

//     //     if (itemIndex == -1)
//     //     {
//     //         Debug.LogError("Item not found in items array");
//     //         return;
//     //     }

//     //     // Add item 
//     //     for (int i = 0; i < slots.Length; i++)
//     //     {
//     //         if (slots[i].itemName == newItemName)
//     //         {
//     //             slots[i].quantity++;
//     //             // Uncomment the lines below if needed
//     //             // slots[i].quantityText.text = slots[i].quantity.ToString();
//     //             DoubleClickToggleButton.instance.UpdateQuantity(slots[i].quantity); //수량 업데이트

//     //             itemAdded = true;
//     //             slots[i].isItem = true;
//     //             item_setActive.instance.updateItem(slots[i].itemName);
//     //             break;
//     //         }
//     //     }

//     //     // Add new item to an empty slot
//     //     if (!itemAdded)
//     //     {
//     //         for (int i = 0; i < slots.Length; i++)
//     //         {
//     //             if (slots[i].itemName == "")
//     //             {
//     //                 slots[i].itemName = newItemName;
//     //                 slots[i].itemInfo = items[itemIndex].info;
//     //                 slots[i].quantity = 1;
//     //                 // Uncomment the lines below if needed
//     //                 // slots[i].itemText.text = newItemName;
//     //                 // slots[i].quantityText.text = "1";
//     //                 // slots[i].itemInfoText.text = items[itemIndex].info;
//     //                 DoubleClickToggleButton.instance.UpdateQuantity(slots[i].quantity); //수량 업데이트

//     //                 item_setActive.instance.updateItem(slots[i].itemName);
//     //                 break;
//     //             }
//     //         }
//     //     }
//     // }
// }
