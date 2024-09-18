using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIOpener : MonoBehaviour
{
    public ShopManager shopManager;  // ShopManager 참조

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 마우스 왼쪽 버튼 클릭 시
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)  // 클릭된 오브젝트가 현재 오브젝트인지 확인
            {
                Debug.Log("ShopTrigger clicked");  // 디버그 로그 추가
                shopManager.OpenShop();  // 상점 열기
            }
        }
    }
}