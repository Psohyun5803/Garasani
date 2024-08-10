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
        Debug.Log(intertest.colitemname);

        if (intertest.colitemname == "Door")
        {
            SceneManager.LoadScene("Chungmuro_B2");
        }
    }
}