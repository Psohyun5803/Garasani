using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNS_ChungmuroB2 : MonoBehaviour
{
    public static SNS_ChungmuroB2 instance;
    public GameObject twit_subway_1;
    public GameObject twit_subway_2;
    public GameObject twit_subway_3;
    public GameObject twit_subway_4;

    void twitUpdate()
    {
        Debug.Log("막차 트윗 업데이트");
        twit_subway_1.SetActive(true);
        twit_subway_2.SetActive(true);
        twit_subway_3.SetActive(true);
        twit_subway_4.SetActive(true);
    }

    private void Update()
    {
        if(inSubway_0.instance.dialogueID == 20)
        {
            twitUpdate();
        }
    }
}
