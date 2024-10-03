using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class b3_board : MonoBehaviour
{
    public GameObject ui_dialogue; //말풍선
    public Dialogue[] contextList;
   
    private void OnMouseDown()
    {

        Debug.Log("clicked");
        StartCoroutine(Routine());
    }
   

    // Start is called before the first frame update
    void Start()
    {
        DataManager.instance.csv_FileName = "b3board";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
        Debug.Log("csv load");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public IEnumerator Routine()
    {
        Debug.Log("시작됨");
        ui_dialogue.SetActive(true);
       
                contextList = DataManager.instance.GetDialogue(1, 3);
                yield return StartCoroutine(DialogueManager.instance.processing(contextList));
              
        ui_dialogue.SetActive(false);
    }
}
