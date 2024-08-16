using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractSave : MonoBehaviour
{
    public int slotNumber; // 슬롯 번호를 설정할 변수

    void OnMouseDown()
    {
        // 현재 씬 이름을 SaveLoadManager에 저장
        SaveLoadManager.currentSceneName = SceneManager.GetActiveScene().name;

        // 플레이어 위치를 슬롯에 저장
        SaveLoadManager.GameState currentState = new SaveLoadManager.GameState
        {
            playerPosition = PlayerController.instance.transform.position
        };
        SaveLoadManager.instance.SaveGame(slotNumber, currentState);

        // UI를 숨김
        gameObject.SetActive(false);
    }
}