using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jongro_3_Audio : MonoBehaviour
{
    public AudioClip audioClip; // 루프로 재생할 오디오 클립
    private AudioSource audioSource; // 오디오 소스

    void Start()
    {
        // 오디오 소스를 추가하고 설정
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true; // 루프 재생 설정
        audioSource.Play(); // 오디오 재생 시작    
    }
}