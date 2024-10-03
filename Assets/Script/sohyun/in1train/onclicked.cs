using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclicked : MonoBehaviour
{
    public static int onclickedflag = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(onclickedflag);
    }
    void OnMouseDown()
    {
        onclickedflag = 1;
    }
}
