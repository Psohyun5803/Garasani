using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiki_Chungmuro : MonoBehaviour
{
    public GameObject ui_Wiki;
    
    // Start is called before the first frame update
    void Start()
    {
        WikiSystem.instance.title.text = "충무로역";
        WikiSystem.instance.text.text =
            "충무로역(Chungmuro station)은 서울특별시 중구 퇴계로에 있는 수도권 전철 3호선과 수도권 전철 4호선의 환승역이다. 역명은 충무로에서 따왔다. 4호선이 위층에, 3호선이 아래층에 있다. 대합실을 공용하며, 4호선의 역으로 취급한다. 3호선과 4호선의 환승은 계단 하나만 이용하면 바로 환승할 수 있으며, 우회 통로도 존재한다.\n\n운행정보\n\n4호선????\n3호선 : 오금행 운행종료/대화행 곧 도착 ";

            
    }

    // Update is called once per frame
    void Update()
    {
        if (ui_Wiki.activeSelf)
        {
            Chungmuro_B3.instance.checkWiki = true;
        }
    }
}
