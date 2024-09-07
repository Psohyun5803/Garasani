using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class Dialogue 
{
    [Tooltip("ID")]
    public int id;

    [Tooltip("이름")]
    public string name; 

    [Tooltip("대사 내용")]
    public string contexts;

    [Tooltip("선택지1")]
    public string chosen1;

    [Tooltip("선택지1 ID")]
    public int chosen1_ID;

    [Tooltip("선택지2")]
    public string chosen2;

    [Tooltip("선택지2 ID")]
    public int chosen2_ID;

    [Tooltip("선택지3")]
    public string chosen3;

    [Tooltip("선택지3 ID")]
    public int chosen3_ID;

    [Tooltip("정민표정")]
    public int jungminemo;

    [Tooltip("지훈표정")]
    public int jihoonemo;
}

[System.Serializable]
public class DialogueEvent 
{
    public string name;
    public Vector2 line; 
    public Dialogue[] dialouges;
}