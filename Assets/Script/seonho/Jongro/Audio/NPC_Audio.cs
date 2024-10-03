using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Audio : MonoBehaviour
{
    public AudioClip backgroundMusicClip;  // 배경 음악 오디오 클립
    public AudioClip dialogueMusicClip;    // 대화 음악 오디오 클립
    public float fadeDuration = 1f;        // 페이드인/페이드아웃에 걸리는 시간
    public string targetNPCName = "NPC";  // 대화 음악 전환을 할 NPC 이름

    private AudioSource audioSource;        // 동적으로 생성할 AudioSource
    private bool isDialoguePlaying = false; // 대화 음악 재생 여부 체크

    void Start()
    {
        // 새로운 AudioSource를 동적으로 생성
        audioSource = gameObject.AddComponent<AudioSource>();

        // 배경음악 설정 및 재생
        audioSource.clip = backgroundMusicClip;
        audioSource.loop = true; // 배경음악을 루프로 설정
        audioSource.Play();

        GameObject upstair = GameObject.Find("계단_우측중앙"); 
        Player.playertrans(upstair.transform.position.x - 7, upstair.transform.position.y);
    }

    void Update()
    {
        if (DialogueManager.instance != null)
        {
            string currentNPCName = DialogueManager.instance.name.text;
            //Debug.Log($"Current NPC Name: {currentNPCName}");

            if (currentNPCName == targetNPCName)
            {
                if (!isDialoguePlaying)
                {
                    StartCoroutine(SwitchToDialogueMusic());
                }
            }
            else
            {
                if (isDialoguePlaying)
                {
                    StartCoroutine(SwitchToBackgroundMusic());
                }
            }
        }
        else
        {
            Debug.LogWarning("DialogueManager.instance is null.");
        }
    }


    private IEnumerator SwitchToDialogueMusic()
    {
        Debug.Log("Switching to dialogue music...");
        isDialoguePlaying = true;

        // 배경 음악 페이드아웃
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }
        audioSource.Stop();

        // 대화 음악으로 전환 및 페이드인
        audioSource.clip = dialogueMusicClip;
        audioSource.loop = true; // 대화 음악을 루프로 설정
        audioSource.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }
    }


    private IEnumerator SwitchToBackgroundMusic()
    {
        Debug.Log("Switching to background music...");
        // 대화 음악 페이드아웃
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }
        audioSource.Stop();

        // 배경 음악으로 전환 및 페이드인
        audioSource.clip = backgroundMusicClip;
        audioSource.loop = true; // 배경 음악을 루프로 설정
        audioSource.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        isDialoguePlaying = false;
    }
}