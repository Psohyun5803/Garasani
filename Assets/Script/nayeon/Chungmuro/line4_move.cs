using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line4_move : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        Debug.Log("클릭 - 4호선 승강장 이동");
        StartCoroutine(TalkManager.instacne.isMove("4호선 승강장", "4_Chungmuro_B3"));
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
