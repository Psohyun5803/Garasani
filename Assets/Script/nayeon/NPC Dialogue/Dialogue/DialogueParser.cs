using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
   public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); //대사 리스트 생성 
        //파싱된 데이터를 임시로 저장

        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //csv파일 가져옴
        if (csvData == null)
        {
            Debug.LogError("CSV file not found: " + _CSVFileName);
            return dialogueList.ToArray();
        }
        //엔터 단위로 나눠줄 것 (줄별로 가져올거라서)
        string[] data = csvData.text.Split(new char[]{'\n'});
        
        for(int i = 1;i<data.Length;) //실제 내용은 1부터 시작 
        {
            string[] row = data[i].Split(new char[] { ',' }); //id, 캐릭터, 대사별로 들어감 

            Dialogue dialogue = new Dialogue(); //대사 리스트 생성
            dialogue.name = row[1];
            Debug.Log(row[1]);

            List<string> contextList = new List<string>();

            do{
                contextList.Add(row[2]);
                Debug.Log(row[2]);
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }
            } while (row[0].ToString() == ""); //다음 행이 null전까지 실행

            dialogue.contexts = contextList.ToArray();
            dialogueList.Add(dialogue); //캐릭터와 대사들로 묶여서 리턴 

            
        }
        return dialogueList.ToArray();
    }

}
