using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jongro_B2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        GameObject upstair = GameObject.Find("[계단]_상단");
        Debug.Log(upstair.transform.position.x);
        Player.playertrans(upstair.transform.position.x, upstair.transform.position.y-3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
