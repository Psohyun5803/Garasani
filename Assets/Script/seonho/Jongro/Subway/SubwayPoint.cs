using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SubwayPoint : MonoBehaviour
{
    public string[] sceneNames; // 이동할 씬들의 이름
    public string playerObjectName = "Player";
    public MovingSubway movingSubway; // MovingSubway 스크립트에 대한 참조

    private bool eventTriggered = false;

    private void Start()
    {
        if (movingSubway == null)
        {
            // MovingSubway 스크립트를 씬에서 찾아 할당
            movingSubway = FindObjectOfType<MovingSubway>();
            if (movingSubway == null)
            {
                Debug.LogError("MovingSubway reference is not assigned and no MovingSubway object found in the scene.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == playerObjectName)
        {
            Debug.Log($"Collision detected with {playerObjectName}");

            // 현재 지하철 상태와 이벤트 트리거 상태를 로그로 출력
            Debug.Log($"IsSubwayStopped: {movingSubway?.IsSubwayStopped}, EventTriggered: {eventTriggered}");

            // 지하철이 stopPoint에 도달했고 이벤트가 아직 발생하지 않았으면
            if (movingSubway != null && movingSubway.IsSubwayStopped && !eventTriggered)
            {
                Debug.Log("Subway is stopped and event is not triggered yet. Triggering event.");
                eventTriggered = true; // 이벤트 발생 플래그 설정
                StartCoroutine(TriggerEvent());
            }
            else
            {
                Debug.Log("Subway is either not stopped or the event has already been triggered.");
            }
        }
    }

    IEnumerator TriggerEvent()
    {
        Player.moveflag = 0;

        yield return new WaitForSeconds(2f); // 문이 열리는 시간 대기

        // 랜덤으로 씬 선택
        string selectedScene = sceneNames[Random.Range(0, sceneNames.Length)];
        Debug.Log("Selected scene: " + selectedScene);

        Player.moveflag = 1;

        // 씬 이동
        if (!string.IsNullOrEmpty(selectedScene))
        {
            Debug.Log("Loading scene: " + selectedScene);
            SceneManager.LoadScene(selectedScene);
            Player.playertrans(0, 0);
        }
        else
        {
            Debug.LogError("Selected scene name is invalid.");
        }
    }
}