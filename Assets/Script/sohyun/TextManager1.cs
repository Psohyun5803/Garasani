using UnityEngine;
using TMPro;

public class TextManager1 : MonoBehaviour
{
    public TypingEffect typingEffectScript;  // TypingEffect 스크립트 참조
    public TMP_Text newTextSource;  // 새로운 텍스트를 제공하는 UI 요소

    private void Start()
    {
        // 예를 들어, 게임이 시작될 때 텍스트를 설정
        UpdateText();
    }

    public void UpdateText()
    {
        string textToDisplay = GetTextFromSource();
        typingEffectScript.SetText(textToDisplay);
    }

    // UI 텍스트나 다른 소스에서 텍스트를 가져오는 메서드
    private string GetTextFromSource()
    {
        return newTextSource.text;  // 예시: UI 텍스트의 내용을 반환
    }
}