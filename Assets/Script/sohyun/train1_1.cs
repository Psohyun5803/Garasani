using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train1_1 : MonoBehaviour
{
    public GameObject sai;
    public GameObject job;
    public GameObject ang;
    public static int possibletogo = 0;
    // Start is called before the first frame update
    void Start()
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
