using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public TMP_Text textDisplay;  // TextMeshPro 텍스트를 사용할 경우
    public float typingSpeed = 0.05f;

    private Coroutine typingCoroutine;

    // 새로운 텍스트를 자동으로 받아와서 타이핑 효과를 적용
    public void SetText(string newText)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // 기존 코루틴 중지
        }
        typingCoroutine = StartCoroutine(TypeText(newText));
    }

    IEnumerator TypeText(string fullText)
    {
        textDisplay.text = ""; // 텍스트 초기화
        foreach (char letter in fullText.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
