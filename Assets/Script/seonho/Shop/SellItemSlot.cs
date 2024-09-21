using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SellItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;  // 아이템 이미지
    public TMP_Text itemNameText;  // 아이템 이름
    public TMP_Text itemPriceText;  // 아이템 가격
    public TMP_Text itemDescriptionText;  // 아이템 설명
    public Item item;  // 이 슬롯에 해당하는 아이템

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;  // 원래 스케일 저장
    }

    // 아이템 설정
    public void SetItem(Item newItem)
    {
        item = newItem;
        itemImage.sprite = newItem.itemSprite;
        itemNameText.text = newItem.itemName;
        itemPriceText.text = newItem.itemPrice.ToString();
        itemDescriptionText.text = newItem.itemDescription;
    }

    // 클릭 이벤트 처리
    public void OnClick()
    {
        // 구매 처리
        if (GameManager.instance.playerMoney >= item.itemPrice)
        {
            GameManager.instance.AddItem(item);  // 아이템 추가
            GameManager.instance.RemoveGold(item.itemPrice);  // 돈 감소
            Debug.Log("구매 완료: " + item.itemName);
            // 추가 UI 업데이트 로직...
        }
        else
        {
            Debug.Log("돈이 부족합니다.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("마우스가 슬롯에 들어갔습니다.");  // 로그 추가
        transform.localScale = originalScale * 1.1f;  // 크기 키우기
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("마우스가 슬롯에서 나갔습니다.");  // 로그 추가
        transform.localScale = originalScale;  // 원래 크기로 되돌리기
    }
}