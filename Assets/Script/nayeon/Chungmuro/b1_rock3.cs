using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b1_rock3 : MonoBehaviour
{
    public static b1_rock3 instance;
    public int rockCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            rockCount++;
            Debug.Log("돌 미는 중");
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rockCount == 3)
        {
            Challenge.instance.ch_rock3 = true;
            Debug.Log("도전 과제 달성");
            StartCoroutine(Chungmuro_B1.instance.ChungmuroB1_2());
        }
    }
}
