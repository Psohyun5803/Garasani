using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public void StoryStart()
    {
        switch (DataManager.instance.csv_FileName)
        {
            case "Dialogue":
                StartCoroutine(Prologue2Dialogue.instance.Prologue2());            
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
