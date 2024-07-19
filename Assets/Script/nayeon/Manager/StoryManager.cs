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

    public void StoryStart()
    {
        switch (DataManager.instance.csv_FileName)
        {
            case "Dialogue": // ***씬 이름 및 csv파일명 변경 필요 (prologue2)***
                sceneNum = 1;
                StartCoroutine(ProceedToNextScene());
                break;
        }
    }

    private IEnumerator ProceedToNextScene()
    {
        while (sceneNum <= 3)
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

    void Start()
    {
        StoryStart();
    }

    void Update()
    {

    }
}
