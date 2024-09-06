using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : MonoBehaviour
{
    /*도전과제 관리 스크립트*/
    public static Challenge instance;
    public bool ch_rock3 = false; //충무로 b1 돌 3번 이상 밀기

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
