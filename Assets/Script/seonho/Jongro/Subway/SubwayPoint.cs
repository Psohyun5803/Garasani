using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SubwayPoint : MonoBehaviour
{
    public Transform zoomInPosition; // 클로즈업할 위치
    public float zoomInTime = 2f; // 클로즈업 시간
    public Animator doorAnimator; // 문 애니메이션
    public string[] sceneNames; // 이동할 씬들의 이름
    public string playerObjectName = "Player";

    private bool eventTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == playerObjectName)
        {
            Debug.Log($"Collision detected with {playerObjectName}"); // 충돌된 오브젝트 이름 로그
            
            if (!eventTriggered)
            {
                eventTriggered = true; // 이벤트 발생 플래그 설정
                StartCoroutine(TriggerEvent());
            }
        }
    }

    IEnumerator TriggerEvent()
    {
        Player.moveflag = 0;
        // 문 열기 애니메이션
        doorAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(2f); // 문이 열리는 시간 대기

        // 랜덤으로 씬 선택
        string selectedScene = sceneNames[Random.Range(0, sceneNames.Length)];
        Player.moveflag = 1;
        // 씬 이동
        SceneManager.LoadScene(selectedScene);
    }
}