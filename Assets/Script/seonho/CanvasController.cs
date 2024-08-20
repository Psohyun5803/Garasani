using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public string playerName = "Player"; // 플레이어 오브젝트의 이름
    private GameObject player; // 플레이어 오브젝트

    void Start()
    {
        player = GameObject.Find(playerName);

        if (player != null)
        {
            Invoke("HideCanvas", 3f);
        }
        else
        {
            Debug.LogError($"플레이어 오브젝트 '{playerName}'을(를) 찾을 수 없습니다.");
        }
    }

    void HideCanvas()
    {

        // 캔버스 비활성화
        gameObject.SetActive(false);
    }
}