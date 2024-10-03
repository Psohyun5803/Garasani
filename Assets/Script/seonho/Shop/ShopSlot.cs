using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image itemImage;  // 아이템 이미지를 나타낼 UI 컴포넌트
    public TMP_Text itemNameText;  // 아이템 이름 텍스트
    public TMP_Text itemPriceText;  // 아이템 가격 텍스트
    public GameObject descriptionUI;  // 아이템 설명 UI
    public float descriptionDuration = 3f;  // 설명 UI 표시 시간

    private Item currentItem;  // 현재 슬롯의 아이템
    private float clickTime = 0.0f;  // 클릭 시간
    private float clickDelay = 0.5f;  // 더블클릭 인식 시간 간격
    private bool isDoubleClick = false;

    void Start()
    {
        descriptionUI.SetActive(false);  // 처음에 설명 UI는 비활성화
    }

    // 슬롯에 아이템 설정
    public void SetItem(Item newItem)
    {
        currentItem = newItem;
        itemImage.sprite = newItem.itemSprite;
        itemNameText.text = newItem.itemName;
        itemPriceText.text = newItem.itemPrice.ToString();  // 아이템 가격 설정
       //디버그 메세지 잠시 지웠습니다 ! -소현 
    }

    public bool IsEmpty()
    {
        return currentItem == null;  // currentItem이 null이면 슬롯이 비어 있음
    }

    public Item GetItem()
    {
        return currentItem;
    }

    // 슬롯 클릭 시
    public void OnClick(int index)
    {
        if (currentItem == null) return;

        float currentTime = Time.time;
        float timeSinceLastClick = currentTime - clickTime;

        if (timeSinceLastClick <= clickDelay)
        {
            isDoubleClick = true;
            OnDoubleClick(index);  // 인덱스 전달
        }
        else
        {
            isDoubleClick = false;
            StartCoroutine(SingleClick());
        }

        clickTime = currentTime;
    }

    // 더블클릭 처리
    private void OnDoubleClick(int index)
    {
        if (currentItem != null)
        {
            ShopManager shopManager = FindObjectOfType<ShopManager>();
            if (shopManager != null)
            {
                Debug.Log("슬롯 더블클릭, 인덱스: " + index);
                shopManager.SellItem(index);  // 인덱스를 전달하여 판매
            }
        }
    }

    // 싱글클릭 처리 (설명 UI 표시)
    private IEnumerator SingleClick()
    {
        yield return new WaitForSeconds(clickDelay);

        if (!isDoubleClick && currentItem != null)
        {
            descriptionUI.SetActive(true);  // 설명 UI 활성화
            yield return new WaitForSeconds(descriptionDuration);  // 3초 기다림
            descriptionUI.SetActive(false);  // 설명 UI 비활성화
        }
    }

    // 슬롯 비우기
    public void ClearSlot()
    {
        currentItem = null;
        itemImage.sprite = null;
        itemNameText.text = "";
        itemPriceText.text = "";
    }
}