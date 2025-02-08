using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIKI_JONGRO : MonoBehaviour
{
    public static Wiki_Chungmuro instance;
    public GameObject ui_Wiki;

    public bool checkWiki = false;
    // Start is called before the first frame update
    void Start()
    {
        WikiSystem.instance.title.text = "종로3가역";
        WikiSystem.instance.text.text =
            "1, 3, 5호선 모두 서울교통공사가 관리한다. 2017년 이전에는 1호선과 3호선은 서울메트로(구 서울특별시지하철공사), 5호선은 서울특별시도시철도공사가 관리했다.\n\n운행정보\n\n1호선????\n3호선????\n5호선????";
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
