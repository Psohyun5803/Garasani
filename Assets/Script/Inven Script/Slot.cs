using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
   [SerializeField] Image image; //이미지 컴포넌트 

    private Item _item;
    public Item item {
        get { return _item; } //아이템 정보 넘겨줌 
        set {
            _item = value;
            if (_item != null) { //등록된 아이템이 있다면 화면에 표시 
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            } else {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
