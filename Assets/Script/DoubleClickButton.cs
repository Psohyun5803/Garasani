using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoubleClickToggleButton : MonoBehaviour
{
    public Button button; // 버튼 컴포넌트
    public Image buttonImage; // 버튼의 이미지 컴포넌트
    public Sprite newSprite; // 교체할 새로운 이미지 스프라이트
    private Sprite originalSprite; // 원래 이미지 스프라이트
    private int clickCount = 0; // 클릭 횟수
    private float clickTime = 0; // 클릭 시간
    private float clickDelay = 0.5f; // 더블 클릭 감지 시간 간격
    private bool isOriginal = true; // 현재 이미지가 원래 이미지인지 여부

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
        originalSprite = buttonImage.sprite; // 원래 이미지 저장
    }

    void OnButtonClick()
    {
        clickCount++;
        if (clickCount == 1)
        {
            clickTime = Time.time;
        }
        else if (clickCount == 2 && Time.time - clickTime < clickDelay)
        {
            if (isOriginal)
            {
                buttonImage.sprite = newSprite; // 새로운 이미지로 변경
                Debug.Log("버튼이 선택되었습니다.");
            }
            else
            {
                buttonImage.sprite = originalSprite; // 원래 이미지로 변경
                Debug.Log("버튼이 원래 이미지로 돌아갔습니다.");
            }
            isOriginal = !isOriginal; // 이미지 상태 토글
            clickCount = 0;
        }
        else
        {
            clickCount = 0;
        }
    }

    void Update()
    {
        if (clickCount == 1 && Time.time - clickTime >= clickDelay)
        {
            clickCount = 0; // 더블 클릭 간격이 지나면 클릭 횟수 초기화
        }
    }
}
