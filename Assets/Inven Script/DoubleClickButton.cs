using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro?? ???????? ???? ????
using System.Collections;

public class DoubleClickToggleButton : MonoBehaviour
{
    public Button button; // UI 버튼
    //public Image buttonImage; // 버튼 이미지 컴포넌트
    //public Sprite newSprite; // 버튼을 더블 클릭했을 때 변경될 이미지
    //private Sprite originalSprite; // 버튼의 원래 이미지
    private int clickCount = 0; // 클릭 횟수를 추적
    private float clickTime = 0; // 첫 번째 클릭이 발생한 시간
    private float clickDelay = 0.5f; // 더블 클릭 간격 (0.5초)
    //private bool isOriginal = true; // 현재 버튼 이미지가 원래 이미지인지 여부

    public TextMeshProUGUI itemNameText; // 장착된 아이템 이름 
    public TextMeshProUGUI itemInfoText; // 장착된 아이템 설명 
    public TextMeshProUGUI itemName; // 현재 선택된 아이템 이름 
    public TextMeshProUGUI itemInfo; // 현재 선택된 아이템 설명 
    public GameObject[] item_quantity; // 아이템 수량 관리 

    public static DoubleClickToggleButton instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
        //originalSprite = buttonImage.sprite; // ?? ?? ???? ??
        for(int i = 0; i < 12; i++)
        {
            item_quantity[i].SetActive(false); 
        }
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
            //if (isOriginal)
            //{
            //    buttonImage.sprite = newSprite; // ?? ???? ??
            //    Debug.Log("???? ???????.");
            //}
            //else
            //{
            //    buttonImage.sprite = originalSprite; // ?? ???? ???
            //    Debug.Log("???? ?? ???? ???????.");
            //}
            //isOriginal = !isOriginal; // ??? ??? ??
            clickCount = 0;

            // ??? ?? ????
            UpdateItemInfo();

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
            clickCount = 0; // ?? ?? ??? ???? ?? ??? ???
        }
    }


    void UpdateItemInfo()
    {
        itemNameText.text = itemName.text;
        itemInfoText.text = itemInfo.text;
        Debug.Log($"??? ??: {itemName}, ??? ??: {itemInfo}");
    }


    public void UpdateQuantity(int quantity) //?? ???? 
    {

        item_quantity[quantity - 1].SetActive(true); //?? ???? ui ?? 
        if (quantity != 1) //?? 1? ?? ?? ??? ?? 
        {
            item_quantity[quantity - 2].SetActive(false); //?? ?? ui? ?? 
        }
        Debug.Log($"??? ??? ?????????: {quantity}");
    }

}
