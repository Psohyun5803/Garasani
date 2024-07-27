using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ExcludeAreaClickHandler : MonoBehaviour
{
    public List<RectTransform> excludeAreas; // 제외할 영역 리스트
    public GraphicRaycaster raycaster; // 캔버스에 있는 GraphicRaycaster
    public GameObject LightSet; // 비활성화할 GameObject

    void Update()
    {
        if (LightSet != null && LightSet.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverExcludedArea())
            {
                Debug.Log("Clicked outside excluded areas");
                LightSet.SetActive(false); // LightSet 비활성화
            }
        }
    }

    bool IsPointerOverExcludedArea()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, raycastResults);

        foreach (var result in raycastResults)
        {
            if (excludeAreas.Contains(result.gameObject.GetComponent<RectTransform>()))
            {
                Debug.Log("Slider inside");
                return true;
            }
        }

        return false;
    }
}

