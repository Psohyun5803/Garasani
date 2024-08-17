using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNS_ChungmuroB2 : MonoBehaviour
{
    public static SNS_ChungmuroB2 instance;

    // 콘텐츠 GameObject 리스트
    public List<GameObject> contentList;
    public float spacing = 100f; // 콘텐츠 사이의 간격
    private int currentIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // 콘텐츠를 초기화
        InitializeContent();
    }

    void Update()
    {
        if (inSubway_0.instance.dialogueID >= 20)
        {
            ShowAdditionalContent();
        }
    }

    // 콘텐츠를 초기화하고 인덱스 0~2의 콘텐츠만 보이도록 설정
    void InitializeContent()
    {
        // 모든 콘텐츠를 비활성화
        foreach (GameObject content in contentList)
        {
            content.SetActive(false);
        }

        // 인덱스 0~2의 콘텐츠만 활성화
        for (int i = 0; i < Mathf.Min(3, contentList.Count); i++)
        {
            contentList[i].SetActive(true);
        }

        // 콘텐츠의 Y좌표 조정
        AdjustContentPosition();
    }

    // 추가 콘텐츠를 활성화
    void ShowAdditionalContent()
    {
        // 인덱스 4~7의 콘텐츠 활성화
        for (int i = 4; i < Mathf.Min(8, contentList.Count); i++)
        {
            contentList[i].SetActive(true);
        }

        // 콘텐츠의 Y좌표 조정
        AdjustContentPosition();
    }

    // 콘텐츠의 Y좌표를 조정
    void AdjustContentPosition()
    {
        for (int i = 0; i < contentList.Count; i++)
        {
            Vector3 position = contentList[i].transform.localPosition;
            position.y = -i * spacing; // 각 콘텐츠의 Y좌표를 조정
            contentList[i].transform.localPosition = position;
        }
    }
}
