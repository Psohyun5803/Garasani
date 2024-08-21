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
        jihoon_B2.jihoonmove = 1;
        trainflag = 1;
        if(npc.T2toT1==1)
        {
            GameObject upstair = GameObject.Find("1È£¼±¹®1");
            Debug.Log(upstair.transform.position.x);
            Player.playertrans(upstair.transform.position.x-7, upstair.transform.position.y );
            npc.T2toT1 = 0;
        }
        if (npc.saigo == 1)
        {
            sai.SetActive(false);
        }
        if (npc.jobflag == 1 && npc.saigo == 0)
        {
            sai.SetActive(true);

        }
        if (npc.saiflag == 1)
        {
            ang.SetActive(true);

        }
        if (npc.angflag == 1)
        {
            possibletogo = 1;
        }

    }
    void Awake()
    {
        sai.SetActive(false);
        ang.SetActive(false);
        job.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(npc.saigo==1)
        {
            sai.SetActive(false);
        }
        if(npc.jobflag==1&&npc.saigo==0)
        {
            sai.SetActive(true);
            
        }
        if (npc.saiflag==1)
        {
            ang.SetActive(true);
            
        }
        if (npc.angflag==1)
        {
            possibletogo = 1;
        }
    }
}
