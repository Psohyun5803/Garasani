using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platerState : MonoBehaviour
{

    public static platerState instance;

    public bool isTired; //피로이상 상태 


    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isTired = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
