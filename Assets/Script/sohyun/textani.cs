using UnityEngine;
using TMPro;
using System.Collections;

public class textani : MonoBehaviour
{
    public TMP_Text textComponent;  // TextMeshPro 텍스트 컴포넌트
    public float typingSpeed = 0.05f;  // 타이핑 속도 조절

    private string fullText;  // 전체 텍스트

    void Start()
    {
        if (textComponent != null)
        {
            fullText = textComponent.text;  // 텍스트 컴포넌트에서 전체 텍스트 가져오기
            textComponent.text = "";  // 텍스트를 초기화하여 빈 상태로 설정
            StartCoroutine(TypeText());  // 코루틴 시작
        }
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            textComponent.text += letter;  // 한 글자씩 텍스트에 추가
            yield return new WaitForSeconds(typingSpeed);  // 타이핑 속도에 맞춰 대기
        }
    }

}
