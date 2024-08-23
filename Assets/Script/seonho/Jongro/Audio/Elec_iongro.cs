using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elec_iongro : MonoBehaviour
{
    public AudioClip clip2; // 루프 재생할 오디오 클립

    private AudioSource audioSource2;

    void Start()
    {
        audioSource2 = gameObject.AddComponent<AudioSource>();

        // 2초 후에 오디오 클립을 재생
        Invoke("PlayAudioClips", 2f);
    }

    void PlayAudioClips()
    {
        // 2번 오디오 클립을 루프 재생
        audioSource2.clip = clip2;
        audioSource2.loop = true;
        audioSource2.Play();
    }
}