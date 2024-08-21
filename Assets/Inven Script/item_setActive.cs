using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class item_setActive : MonoBehaviour
{
    public static item_setActive instance;
    public GameObject[] itemSlots; // 각 슬롯에 대한 GameObject 배열
    public Sprite[] itemSprites; // 아이템 이미지를 저장한 배열, 아이템 이름과 일치하는 순서로 넣습니다.

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updateItem(string itemName)
    {
        for(int i = 0; i < Inventory.instance.slots.Length; i++)
        {
            if (!Inventory.instance.slots[i].isItem) //슬롯 비어있는 경우 
            {
               
            }

        }
    }

    // 아이템 이름에 맞는 이미지를 반환하는 메서드
    private Sprite GetItemSprite(string itemName)
    {
        for (int i = 0; i < itemSprites.Length; i++)
        {
            if (itemSprites[i].name == itemName)
            {
                return itemSprites[i];
            }
        }
        return null; // 아이템 이름에 맞는 이미지가 없으면 null 반환
    }
}