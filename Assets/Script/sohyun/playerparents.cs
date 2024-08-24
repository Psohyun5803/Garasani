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
public class playerparents : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        GameObject basebody = GameObject.Find("basebody");

        // 현재 객체가 basebody의 부모인지 확인
        if (basebody.transform.parent == transform)
        {
            // basebody의 x, y 좌표를 Vector2로 저장
            Vector2 position = new Vector2(basebody.transform.position.x, basebody.transform.position.y);

            // z 값을 0으로 하여 Vector3로 변환
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }

    }
}
