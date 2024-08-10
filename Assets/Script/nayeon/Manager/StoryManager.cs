using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;
    public int sceneNum;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public bool sceneInitialized= false;
    public void StoryStart()
    {
        switch (DataManager.instance.csv_FileName)
        {
            case "Prologue2": 
                if (!sceneInitialized)
                {
                    sceneNum = 1;
                    sceneInitialized = true;
                }
                StartCoroutine(ProceedToNextScene());
                
                break;
        }
    }

    public IEnumerator ProceedToNextScene()
    {
        Debug.Log(sceneNum);
        while (sceneNum < 4)
        {
            switch (sceneNum)
            {
                case 1:
                    yield return StartCoroutine(Prologue2Dialogue.instance.prologue2_1());
                    break;
                case 2:
                    yield return StartCoroutine(Prologue2Dialogue.instance.prologue2_2());
                    break;
                case 3:
                    yield return StartCoroutine(Prologue2Dialogue.instance.prologue2_3());
                    break;
                default:
                    yield break;
            }
            sceneNum++;
        }
    }
}

   


