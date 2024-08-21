using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    void Start()
    {
        Player.moveflag = 0;
        Invoke("HideCanvas", 3f);
    }

    void HideCanvas()
    {
        gameObject.SetActive(false);
        Player.moveflag = 1;
    }
}