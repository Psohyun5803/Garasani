using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b1_rock3 : MonoBehaviour
{
    public static b1_rock3 instance;
    public int rockCount = 0;
    public bool rockFlag = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.name == "Player")
    //     {
    //         Rigidbody rb = GetComponent<Rigidbody>();
    //         if (rb != null)
    //         {
    //             rb.velocity = Vector3.zero; // 이동 중지
    //             rb.angularVelocity = Vector3.zero; // 회전 중지
    //         }
    //         rockCount++;
    //         Debug.Log("돌 미는 중");
    //     }
        
    // }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rockCount == 3)
        {
            //Challenge.instance.ch_rock3 = true;
            //Debug.Log("도전 과제 달성");
            rockFlag = true;
        }
    }
}
