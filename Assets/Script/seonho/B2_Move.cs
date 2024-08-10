using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B2_Move : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Mouse Click");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.colitemname);

        if (intertest.colitemname == "Door")
        {
            SceneManager.LoadScene("Chungmuro_B1");
        }
    }
}