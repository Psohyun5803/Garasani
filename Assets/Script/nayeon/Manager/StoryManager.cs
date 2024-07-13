using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public void StoryStart()
    {
        switch (DataManager.instance.csv_FileName)
        {
            case "Dialogue": // ***씬 이름 및 csv파일명 변경 필요 (prologue2)***
                StartCoroutine(Prologue2Dialogue.instance.prologue2());
                break;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StoryStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
