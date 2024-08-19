using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jongro_B1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        if (npc.B2toB1==1)
        {
           
            GameObject upstair = GameObject.Find("계단_우측중앙");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x - 3, upstair.transform.position.y);
            npc.B2toB1 = 0;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
