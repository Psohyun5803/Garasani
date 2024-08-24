using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train2_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (npc.T1toT2 == 1)
        {
            GameObject upstair = GameObject.Find("1호선문2");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x +7, upstair.transform.position.y);
            npc.T1toT2 = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
