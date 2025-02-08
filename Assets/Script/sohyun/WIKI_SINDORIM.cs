using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIKI_SINDORIM : MonoBehaviour
{
    public GameObject ui_Wiki;
    public bool checkWiki = false;
    // Start is called before the first frame update
    void Start()
    {
        WikiSystem.instance.title.text = "신도림역";
        WikiSystem.instance.text.text =
            "신도림역은 지하철 1호선의 개통과 함께 서울과 인천, 서울과 수원을 잇는 역으로 이용되다가 1984년 서울지하철 2호선의 개통과 함께 주요 환승역 역할을 하게 되었다.\n\n운행정보\n\n1호선????\n2호선???? ";
    }

    // Update is called once per frame
    void Update()
    {
        if (ui_Wiki.activeSelf)
        {
            checkWiki = true;
            Debug.Log("check wiki " + checkWiki);
        }
    }
}
