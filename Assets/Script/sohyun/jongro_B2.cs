using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jongro_B2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       if(npc.B1toB2==1)
        {
            GameObject upstair = GameObject.Find("[계단]_상단");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x, upstair.transform.position.y - 5);
            npc.B1toB2 = 0;
        }
       else if(npc.S3toB2==1)
        {
            GameObject upstair = GameObject.Find("[계단]_하단");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x, upstair.transform.position.y + 10);
            npc.S3toB2 = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
