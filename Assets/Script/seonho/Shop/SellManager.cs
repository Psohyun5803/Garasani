using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellManager : MonoBehaviour
{
    public GameObject itemSlotPrefab;  // ������ ���� ������
    public Transform contentArea;  // ������ ������ ��ġ�� ����
    public List<Item> availableItems = new List<Item>();  // ������ �� �ִ� ������ ��� (�ܺο��� ����)

    private void Start()
    {
        LoadAvailableItems();
    }

    public void SetAvailableItems(List<Item> items)
    {
        availableItems = items;
        LoadAvailableItems();
    }

    private void LoadAvailableItems()
    {
        foreach (Transform child in contentArea)
        {
            Destroy(child.gameObject);  // ���� ���� ����
        }

        foreach (var item in availableItems)
        {
            if (item != null)  // �������� null���� Ȯ��
            {
                CreateItemSlot(item);
            }
            else
            {
                Debug.LogWarning("Available item is null");
            }
        }
    }

    private void CreateItemSlot(Item item)
    {
        if (itemSlotPrefab == null || contentArea == null)  // null üũ
        {
            Debug.LogError("itemSlotPrefab or contentArea is not set.");
            return;
        }

        GameObject slot = Instantiate(itemSlotPrefab, contentArea);  // ���� ����
        SellItemSlot itemSlot = slot.GetComponent<SellItemSlot>();   // ������ SellItemSlot ������Ʈ ������

        if (itemSlot != null)  // null üũ
        {
            itemSlot.SetItem(item);  // ������ ���� ����

            // ��ư Ŭ�� �̺�Ʈ �߰�
            Button button = slot.GetComponent<Button>();
            button.onClick.AddListener(() => OnItemClicked(itemSlot));  // Ŭ�� �� ������ �޼��� ���
        }
        else
        {
            Debug.LogError("SellItemSlot component is missing in the item slot prefab.");
        }
    }

    private void OnItemClicked(SellItemSlot itemSlot)
    {
        Debug.Log("������ ���� �õ�: " + itemSlot.item.itemName);
        GameManager.instance.AddItem(itemSlot.item);  // �������� GameManager�� �߰� (����)
        GameManager.instance.AddGold(-itemSlot.item.itemPrice);  // ������ ���ݸ�ŭ �� ����
        Debug.Log("������ ���� �Ϸ�: " + itemSlot.item.itemName);
    }
}