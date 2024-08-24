using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController1 : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            player.transform.position = new Vector3(-3,-1,0);
            Debug.Log("플레이어 위치가 (0,0,0)으로 이동되었습니다.");
        }
        else
        {
            Debug.LogError("Player라는 이름의 오브젝트를 찾을 수 없습니다.");
        }
    }
}