using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    void Start()
    {
        Invoke("HideCanvas", 3f);
        Player.moveflag = 0;
    }

    void HideCanvas()
    {
        gameObject.SetActive(false);
        Player.moveflag = 1;
    }
}