using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Net.Mail;
using TMPro;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System;

public class tutorialscript : MonoBehaviour
{
    public GameObject 말풍선;
    public GameObject 버튼;
    public TMP_Text 내용;
    public TMP_Text 이름;
    int scriptcounter = 0;
    string[] text = new string[10] {"으...","머리를 좀 세게 부딪힌 거 같은데...","...","근데 왜 이리 조용하지? 설마 아무도 없나?","...","열차를 좀 돌아다녀볼까.","...?","...이게 무슨 소리지...?","앞쪽에서 점점 다가오고 있어...","...!" };
    string[] 상호작용 = new string[4] { "[찢겨진 부적] : 영문을 알 수 없는 글씨가 쓰여진 종이. 섬뜩하게 찢겨져있다.", "[누군가 두고 내린 에어팟 한쪽]을 가방에 챙겼다.", "[누군가 흘린 키링]을 가방에 챙겼다.", "무언가에 걸린 듯 문이 열리지 않는다" };
    // Start is called before the first frame update
    void Start()
    {
        말풍선.SetActive(true);
        이름.text = customize.playername;
        내용.text = text[scriptcounter];
        scriptcounter++;
    }
    public void button()
    {
        if (scriptcounter<=5)
        {
            이름.text = customize.playername;
            내용.text = text[scriptcounter];
            scriptcounter++;
        }
        else if (scriptcounter==6)
        {
            말풍선.SetActive(false);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
