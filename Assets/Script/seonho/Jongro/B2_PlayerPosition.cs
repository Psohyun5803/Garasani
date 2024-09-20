using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_PlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject upstair = GameObject.Find("[계단]_하단"); 
        Player.playertrans(upstair.transform.position.x, upstair.transform.position.y + 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
