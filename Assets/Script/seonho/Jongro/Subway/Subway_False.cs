using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Subway_False : MonoBehaviour
{
    public Image image;
    public Image fadeInImage; // 천천히 켜질 이미지
    public float displayDuration = 5f; // 이미지 표시 시간
    public float fadeInDuration = 2f; // 페이드 인 시간
    public string nextSceneName; // 이동할 씬 이름

    private void Start()
    {
        Player.moveflag = 0;
        fadeInImage.canvasRenderer.SetAlpha(0f);
        StartCoroutine(HandleSceneTransition());
    }

    IEnumerator HandleSceneTransition()
    {
        image.gameObject.SetActive(true);

        // 5초 기다리기
        yield return new WaitForSeconds(displayDuration);

        // 현재 활성화된 이미지를 비활성화
        image.gameObject.SetActive(false);

        // 페이드 인 이미지 초기 상태 설정
        fadeInImage.gameObject.SetActive(true);

        // 페이드 인 애니메이션
        fadeInImage.CrossFadeAlpha(1f, fadeInDuration, false); // 천천히 보이게 만들기

        // 페이드 인 완료 대기
        yield return new WaitForSeconds(fadeInDuration);

        // 씬 이동
        SceneManager.LoadScene(nextSceneName);
    }
}