using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WikiSystem : MonoBehaviour
{
    public static WikiSystem instance; 
    public TMP_Text title; //위키 제목
    public TMP_Text text; //위키 내용 

    private void Awake()
    {
        if(instance == null)
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
