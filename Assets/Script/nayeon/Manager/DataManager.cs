using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance; //참조가 쉽도록

    [SerializeField] string csv_FileName;

    //인덱스에 맞는 dialogue가 꺼내와지는 딕셔너리 
    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();

    public static bool isFinish = false; //데이터가 전부 저장되었는지

    private void Awake()
    {
        if(instance == null)//모든 데이터를 딕셔너리에 넣기 
        {
            instance = this; //자기 자신 넣기 -> 등록된 데이터가 전부 instance로 들어감 
            DialogueParser theParser = GetComponent<DialogueParser>();
            Dialogue[] dialogues = theParser.Parse(csv_FileName); //배열 타입으로 리턴된게 저장 -> 모든 데이터가 담김 

            for(int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true;
        }
    }

    public Dialogue[] GetDialogue(int _StartNum, int _EndNum)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        for(int i=0 ; i<= _EndNum-_StartNum; i++)
        {
            dialogueList.Add(dialogueDic[_StartNum + i]); //딕셔너리에서 꺼내오기 
        }

        return dialogueList.ToArray();
    }
}
