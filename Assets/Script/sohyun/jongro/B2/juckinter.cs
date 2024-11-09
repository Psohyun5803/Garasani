using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juckinter : MonoBehaviour
{
    public GameObject juckobj;
    public static bool juckactive = false;
    // Start is called before the first frame update
    void Start()
    {
        juckobj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
        if (juckactive==true)
        {
           
            juckobj.SetActive(true);
        }
      
    }
}
