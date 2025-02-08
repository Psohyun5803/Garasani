using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNS_SINDORIM : MonoBehaviour
{
    public GameObject whole;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(whole.activeSelf)
        {
            foreach (Transform child in whole.transform)
            {
                if (child.CompareTag("SNS_SINDORIM"))
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}
