using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MovingSubway : MonoBehaviour
{
    public GameObject movingObjectPrefab;
    public Transform spawnPoint;
    public Transform stopPoint;
    public Transform exitPoint;
    public float moveSpeed = 2f;
    public float spawnInterval = 60f;
    public float stopDuration = 10f;
    public float initialDelay = 5f;

    public AudioClip[] audioClips; // 오디오 클립 배열
    public AudioClip scene1Clip1; // 1번 씬으로 이동할 때의 오디오 클립
    public AudioClip scene1Clip2; // 1번 씬으로 이동할 때의 오디오 클립
    public string scene1Name = "1호선내부1"; // 1번 씬 이름
    public string scene2Name = "1호선내부1_False"; // 2번 씬 이름

    public delegate void AudioClipPlayedHandler(AudioClip clip);
    public event AudioClipPlayedHandler OnAudioClipPlayed;

    public AudioClip CurrentAudioClip { get; private set; }

    public bool IsSubwayStopped { get; private set; } = false;
    private GameObject currentSubway;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(StartAfterDelay(initialDelay));
    }

    IEnumerator StartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        InvokeRepeating("SpawnMovingObject", 0f, spawnInterval);
    }

    void SpawnMovingObject()
    {
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        IsSubwayStopped = false;
        currentSubway = Instantiate(movingObjectPrefab, spawnPoint.position, Quaternion.identity);

        // 랜덤으로 오디오 클립 선택
        AudioClip selectedClip = audioClips[Random.Range(0, audioClips.Length)];
        CurrentAudioClip = selectedClip;
        audioSource.clip = selectedClip;
        audioSource.Play();

        // 오디오 클립이 재생 완료될 때까지 대기
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        // 오디오 클립 재생 완료 후 이벤트 발생
        OnAudioClipPlayed?.Invoke(selectedClip);

        // 오브젝트가 스톱 포인트까지 이동
        while (Vector3.Distance(currentSubway.transform.position, stopPoint.position) > 0.1f)
        {
            currentSubway.transform.position = Vector3.MoveTowards(currentSubway.transform.position, stopPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // 지하철이 스톱 포인트에 도달했을 때 상태 업데이트
        IsSubwayStopped = true;
        Debug.Log("Subway has reached the stop point. IsSubwayStopped = " + IsSubwayStopped);

        // 10초간 정지
        yield return new WaitForSeconds(stopDuration);

        IsSubwayStopped = false;
        Debug.Log("Subway is leaving the stop point. IsSubwayStopped = " + IsSubwayStopped);

        // 오브젝트가 익스잇 포인트로 이동 후 제거
        while (Vector3.Distance(currentSubway.transform.position, exitPoint.position) > 0.1f)
        {
            currentSubway.transform.position = Vector3.MoveTowards(currentSubway.transform.position, exitPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(currentSubway);
    }
}