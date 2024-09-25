using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class train1npc : MonoBehaviour
{
    public GameObject god;
    public GameObject ang;
    public GameObject job;
    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    public int firstflag=0;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "1호선내부1")//1호선 내부 1이라면 퍼레이드 효과를 위해서 npc들을 찾는다
        {
           god = GameObject.Find("사이비");
           ang = GameObject.Find("앵벌이");
           job = GameObject.Find("잡상인");

            ang.SetActive(false);
            god.SetActive(false);
        }
        DataManager.instance.csv_FileName = "NPC";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        Debug.Log("csv load");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCManager.jobflag == 1&&firstflag==0)
        {
            firstflag = 1;
            god.SetActive(true);
        }
        if (NPCManager.godflag == 1)
        {
            ang.SetActive(true);
        }
       
    }
}
