using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gifimage : MonoBehaviour
{
    public Sprite[] images; // 변경할 이미지들을 담은 배열
    public Image displayImage; // 이미지를 표시할 UI Image 컴포넌트

    private int currentIndex = 0; // 현재 표시 중인 이미지의 인덱스

    void Start()
    {
        if (images.Length > 0)
        {
            StartCoroutine(ChangeImage());
        }
    }

    IEnumerator ChangeImage()
    {
        while (true)
        {
            // 이미지 변경
            displayImage.sprite = images[currentIndex];

            // 다음 이미지로 인덱스 변경 (순환)
            currentIndex = (currentIndex + 1) % images.Length;

            // 0.5초 대기
            yield return new WaitForSeconds(0.5f);
        }
    }
}
