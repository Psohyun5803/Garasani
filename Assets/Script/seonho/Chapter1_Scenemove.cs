using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapter1_Scenemove : MonoBehaviour
{
    public string playername = "eye";
    public string nextSceneName = "3호선승강장_종로"; // 이동할 씬 이름
    public Image fadeImage; // 화면을 어둡게 할 이미지
    public float fadeDuration = 2f; // 화면이 어두워지는 데 걸리는 시간

    private bool isFading = false;

    void Start()
    {
        // 시작할 때 이미지의 알파값을 0으로 설정
        SetFadeImageAlpha(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌 발생: " + other.gameObject.name); // 충돌이 발생할 때의 오브젝트 이름을 출력

        // 이름이 "Player"인 오브젝트와 충돌했는지 확인
        if (other.gameObject.name == playername && !isFading)
        {
            Debug.Log("플레이어와 충돌 감지됨!"); // 플레이어와 충돌이 감지되었음을 출력
            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        isFading = true;

        // 이미지 활성화
        fadeImage.gameObject.SetActive(true);

        // 화면이 천천히 어두워지게 하기
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            SetFadeImageAlpha(alpha);
            yield return null;
        }

        SetFadeImageAlpha(1);
        Debug.Log("씬 이동 중...");
        // 씬 이동
        SceneManager.LoadScene(nextSceneName);
    }

    void SetFadeImageAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
}