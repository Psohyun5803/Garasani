using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapter1_Scenemove : MonoBehaviour
{
    public string playername = "hair (2)";
    public string nextSceneName = "3호선승강장_종로"; // 이동할 씬 이름
    public Image fadeImage; // 화면을 어둡게 할 이미지
    public float fadeDuration = 2f; // 화면이 어두워지는 데 걸리는 시간

    public AudioClip audioClip; // 오디오 소스
    public float audioFadeDuration = 0.7f; // 오디오 페이드아웃 시간
    private AudioSource audioSource;

    private bool isFading = false;

    public Transform objectToMove;

    void Start()
    {
        // 시작할 때 이미지의 알파값을 0으로 설정
        SetFadeImageAlpha(0);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌 발생: " + other.gameObject.name); // 충돌이 발생할 때의 오브젝트 이름을 출력

        // 이름이 "Player"인 오브젝트와 충돌했는지 확인
        if (other.gameObject.name == playername && !isFading)
        {
            Debug.Log("플레이어와 충돌 감지됨!"); // 플레이어와 충돌이 감지되었음을 출력
            Player.moveflag = 0;
            StartCoroutine(FadeAndLoadScene());
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        isFading = true;

        yield return MoveObject();

        fadeImage.gameObject.SetActive(true);
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            SetFadeImageAlpha(alpha);
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / audioFadeDuration);
            yield return null;
        }

        SetFadeImageAlpha(1);
        audioSource.volume = 0;

        Debug.Log("씬 이동 중...");
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator MoveObject()
    {
        float moveDuration = 3f;
        float elapsedTime = 0f;

        Vector3 startPosition = objectToMove.position;
        Vector3 endPosition = startPosition + new Vector3(startPosition.x + 5, startPosition.y, startPosition.z);

        // 오브젝트 이동
        while (elapsedTime < moveDuration)
        {
            objectToMove.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 최종 위치로 설정
        objectToMove.position = endPosition;
    }

    void SetFadeImageAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
}