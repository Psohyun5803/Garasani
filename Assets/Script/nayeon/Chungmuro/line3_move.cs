using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line3_move : MonoBehaviour
{
    private void OnMouseDown()
    {
        StartCoroutine(TalkManager.instacne.isMove("3호선 승강장", "3_Chungmuro_B3"));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
