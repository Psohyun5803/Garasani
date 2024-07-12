using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //인스펙터 창에서 수정할 수 있도록 함 
public class Dialogue //상속받지 않게 삭제
{
    [Tooltip("ID")]
    public int id;

    [Tooltip("캐릭터 이름")]
    public string name; //누가 대사를 하는지 

    [Tooltip("대사내용")]
    public string contexts;

    [Tooltip("선택지1")]
    public string chosen1;

    [Tooltip("선택지1 ID")]
    public int chosen1_ID;

    [Tooltip("선택지2")]
    public string chosen2;

    [Tooltip("선택지2 ID")]
    public int chosen2_ID;
}

[System.Serializable]
public class DialogueEvent //여러명이 말함 -> 클래스를 배열로 만듬
{
    public string name; //어떤 이벤트인지 명시 
    public Vector2 line; //몇번째 줄부터 몇번째 줄까지 대사 추출 
    public Dialogue[] dialouges;
}