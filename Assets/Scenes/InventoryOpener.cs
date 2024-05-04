using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    public GameObject inventoryWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 'e' 키를 누르면 인벤토리 창을 엽니다.
            inventoryWindow.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 'escape' 키를 누르면 인벤토리 창을 닫습니다.
            inventoryWindow.SetActive(false);
        }
    }
}
