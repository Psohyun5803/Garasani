using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jihoon : MonoBehaviour
{
    public static int jihoonmove = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null&&jihoonmove==1)
        {
            
            transform.position = new Vector3(player.transform.position.x+1,
                            player.transform.position.y+1, 0);


        }
    }
}
