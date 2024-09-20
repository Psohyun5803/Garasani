using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemImage;  // 아이템 이미지를 나타낼 UI 컴포넌트
    public GameObject[] itemCountImages;  // 개수별 이미지 배열 (1~12)
    public TMP_Text itemNameText;         // 아이템 이름 텍스트
    public TMP_Text itemDescriptionText;  // 아이템 설명 텍스트
    public GameObject descriptionUI;      // 설명 UI

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
        UpdateItemCount(newItem.itemCount);
        itemImage.sprite = newItem.itemSprite;
        itemImage.gameObject.SetActive(true); // 아이템이 있을 경우 이미지를 보이게 설정
    }

    // 슬롯이 비어있는지 확인
    public bool IsEmpty()
    {
        return currentItem == null;
    }

    // 아이템 개수에 따라 이미지 활성화/비활성화
    public void UpdateItemCount(int count)
    {
        for (int i = 0; i < itemCountImages.Length; i++)
        {
            itemCountImages[i].SetActive(i == count - 1);  // 맞는 개수 이미지만 활성화
        }
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

    // 싱글클릭 처리 (설명 UI 표시)
    private System.Collections.IEnumerator SingleClick()
    {
        yield return new WaitForSeconds(clickDelay);

        if (!isDoubleClick && currentItem != null)
        {
            // 기존 설명 UI가 꺼져 있으면 켜고, 켜져 있으면 끄는 방식으로 토글
            descriptionUI.SetActive(!descriptionUI.activeSelf);

            if (descriptionUI.activeSelf)
            {
                itemNameText.text = currentItem.itemName;
                itemDescriptionText.text = currentItem.itemDescription;
            }
        }
    }

    // 더블클릭하면 아이템 장착
    private void OnDoubleClick()
    {
        if (currentItem != null && currentItem.isEquipable)
        {
            InventoryManager inventory = FindObjectOfType<InventoryManager>();
            inventory.EquipItem(currentItem);  // 장착된 아이템을 InventoryManager에서 관리

            // 장착 후 설명 UI를 비활성화
            descriptionUI.SetActive(false);
        }
    }

    public void ClearSlot()
    {
        currentItem = null;
        itemImage.sprite = null;
        itemNameText.text = "";
        itemDescriptionText.text = "";
    }
}