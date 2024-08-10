using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B3_Move : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Mouse Click");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.충돌아이템명);

        if (intertest.충돌아이템명 == "Door")
        {
            SceneManager.LoadScene("Chungmuro_B2");
        }
    }
}