using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopUIOpener : MonoBehaviour
{
    public GameObject shopUI;  // ShopManager 참조

    void Start()
    {
        shopUI.SetActive(false); // 게임 시작 시 UI 비활성화
    }

    void OnMouseDown()
    {
        shopUI.SetActive(!shopUI.activeSelf);
        Player.moveflag = 0;
    }
}