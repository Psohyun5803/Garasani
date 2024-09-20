using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneclick : MonoBehaviour
{
    public static stoneclick instance;
    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
    public bool firstmove = true;
    private int dialogueID = 0;
    // Start is called before the first frame update
    void Start()
    {
        /*dialogueID = 32;
        DataManager.instance.csv_FileName = "Prologue2";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        Debug.Log("csv load");*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D()
    {
       /* if (!firstmove)
        {
            StartCoroutine(stonecol());   
        }*/
    }
    void OnMouseDown()
    {
        
    }
   

}
