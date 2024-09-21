using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_PlayerPosition1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject upstair = GameObject.Find("ÀÚÆÇ±â01"); 
        Player.playertrans(upstair.transform.position.x, upstair.transform.position.y -5);
        Player.moveflag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
