using UnityEngine;
using TMPro;
using System.Collections;

public class textani : MonoBehaviour
{

    public TMP_Text textDisplay;  // TextMeshPro를 사용할 경우
    // public Text textDisplay;  // 기본 UI 텍스트를 사용할 경우
    public float typingSpeed = 0.05f; // 타이핑 속도 조절

    private Coroutine typingCoroutine;

    public void DisplayDialogue(string dialogue)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // 기존 코루틴 중지
        }
        typingCoroutine = StartCoroutine(TypeText(dialogue));
    }

    private IEnumerator TypeText(string text)
    {
        textDisplay.text = ""; // 텍스트 초기화
        foreach (char letter in text.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed); // 타이핑 속도 조절
        }
    }

}
