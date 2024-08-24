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

    public AudioClip[] audioClips; // ����� Ŭ�� �迭
    public AudioClip scene1Clip1; // 1�� ������ �̵��� ���� ����� Ŭ��
    public AudioClip scene1Clip2; // 1�� ������ �̵��� ���� ����� Ŭ��
    public string scene1Name = "1호선내부1"; // 1�� �� �̸�
    public string scene2Name = "1호선내부1_False"; // 2�� �� �̸�

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

        // �������� ����� Ŭ�� ����
        AudioClip selectedClip = audioClips[Random.Range(0, audioClips.Length)];
        CurrentAudioClip = selectedClip;
        audioSource.clip = selectedClip;
        audioSource.Play();

        // ����� Ŭ���� ��� �Ϸ�� ������ ���
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        // ����� Ŭ�� ��� �Ϸ� �� �̺�Ʈ �߻�
        OnAudioClipPlayed?.Invoke(selectedClip);

        // ������Ʈ�� ���� ����Ʈ���� �̵�
        while (Vector3.Distance(currentSubway.transform.position, stopPoint.position) > 0.1f)
        {
            currentSubway.transform.position = Vector3.MoveTowards(currentSubway.transform.position, stopPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // ����ö�� ���� ����Ʈ�� �������� �� ���� ������Ʈ
        IsSubwayStopped = true;
        Debug.Log("Subway has reached the stop point. IsSubwayStopped = " + IsSubwayStopped);

        // 10�ʰ� ����
        yield return new WaitForSeconds(stopDuration);

        IsSubwayStopped = false;
        Debug.Log("Subway is leaving the stop point. IsSubwayStopped = " + IsSubwayStopped);

        // ������Ʈ�� �ͽ��� ����Ʈ�� �̵� �� ����
        while (Vector3.Distance(currentSubway.transform.position, exitPoint.position) > 0.1f)
        {
            currentSubway.transform.position = Vector3.MoveTowards(currentSubway.transform.position, exitPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(currentSubway);
    }
}