using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class station3 : MonoBehaviour
{
    public GameObject talksqu;
    // Start is called before the first frame update
    void Start()
    {
        customize.sceneflag = 3;
        Player.moveflag = 1;
        talksqu = GameObject.Find("말풍선");
        if (talksqu != null)
        {
            talksqu.SetActive(false);
        }
        if(npc.B2to3==1)
        {
            GameObject upstair = GameObject.Find("3호선승강장계단");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x +5, upstair.transform.position.y+3);
            npc.B2to3 = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
