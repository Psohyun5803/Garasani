using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopInventorySlot : MonoBehaviour
{
    public TMP_Text itemNameText;  // 아이템 이름
    public TMP_Text itemPriceText;  // 아이템 가격
    public GameObject descriptionUI;  // 아이템 설명 UI
    private Item currentItem;  // 현재 슬롯에 있는 아이템
    private float clickTime = 0.0f;
    private float clickDelay = 0.25f;
    private bool isDoubleClick = false;

    private void Start()
    {
        descriptionUI.SetActive(false);  // 처음에는 설명 UI 비활성화
    }

    // 슬롯에 아이템 설정
    public void SetItem(Item newItem)
    {
        currentItem = newItem;
        // 상점 슬롯에 아이템 정보를 표시할 수 있도록 설정
    }

    // 슬롯 클릭 시
    public void OnClick()
    {
        if (currentItem == null) return; // 아이템이 없는 경우 무시

        float currentTime = Time.time;
        float timeSinceLastClick = currentTime - clickTime;

        if (timeSinceLastClick <= clickDelay)
        {
            isDoubleClick = true;
            OnDoubleClick();  // 더블클릭으로 간주
        }
        else
        {
            isDoubleClick = false;
            StartCoroutine(SingleClick());
        }

        clickTime = currentTime;
    }

    // 싱글 클릭 시 아이템 이름과 가격 표시
    private System.Collections.IEnumerator SingleClick()
    {
        yield return new WaitForSeconds(clickDelay);

        if (!isDoubleClick && currentItem != null)
        {
            itemNameText.text = currentItem.itemName;
            itemPriceText.text = currentItem.itemPrice.ToString();  // 가격 표시
            descriptionUI.SetActive(true);  // 설명 UI 활성화
        }
    }

    // 더블클릭 시 아이템 판매
    private void OnDoubleClick()
    {
        if (currentItem != null)
        {
            // 판매 처리 (게임 매니저에서 처리)
            Debug.Log(currentItem.itemName + "을(를) 판매했습니다.");
            SellItem();
        }
    }

    // 아이템 판매 처리
    private void SellItem()
    {
        GameManager.instance.SellItem(currentItem);  // GameManager에서 판매 처리
        descriptionUI.SetActive(false);  // 설명 UI 비활성화
    }
}