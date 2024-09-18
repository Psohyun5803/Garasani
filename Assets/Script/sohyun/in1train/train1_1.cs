using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train1_1 : MonoBehaviour
{
    public GameObject sai;
    public GameObject job;
    public GameObject ang;
    public static int possibletogo = 0;
    public static int trainflag = 0;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject talksqu = GameObject.Find("말풍선");
        //talksqu.SetActive(false);
        customize.sceneflag = 2;
        Player.moveflag = 1;
        jihoon_B2.jihoonmove = 1;
        trainflag = 1;
        /*if(npc.T2toT1==1)
        {
            GameObject upstair = GameObject.Find("1호선문1");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x-10, upstair.transform.position.y );
            npc.T2toT1 = 0;
        }*/
       
         

    }
    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
