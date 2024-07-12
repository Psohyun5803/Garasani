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

        
        string[] data = csvData.text.Split(new char[]{'\n'}); //엔터 단위로 나눠줄 것 (줄별로 가져올거라서)
        
        for(int i = 1;i<data.Length;i++) //실제 내용은 1부터 시작 
        {
            string[] row = data[i].Split(new char[] { ',' }); //각 csv데이터의 줄을 row array에 할당 

            if (row.Length < 7)
            {
                Debug.LogWarning("Row does not have enough columns: " + data[i]);
                continue; // 다음 줄로 넘어감
            }

            Dialogue dialogue = new Dialogue(); // 대화 정보 들어있는 Dialogue 객체 생성 

            if (!int.TryParse(row[0], out dialogue.id))
            {
                dialogue.id = 0; // 파싱 실패 시 기본값 설정
            }

            if (row[1].CompareTo("주인공") == 0)
                dialogue.name = customize.playername;
            else
                dialogue.name = row[1]; // 이름

            dialogue.contexts = row[2]; // 대사 내용

            dialogue.chosen1 = row[3]; // 선택지1

            if (!int.TryParse(row[4], out dialogue.chosen1_ID))
            {
                dialogue.chosen1_ID = 0; // 파싱 실패 시 기본값 설정
            }

            dialogue.chosen2 = row[5]; // 선택지2

            if (!int.TryParse(row[6], out dialogue.chosen2_ID))
            {
                dialogue.chosen2_ID = 0; // 파싱 실패 시 기본값 설정
            }

            dialogue.contexts = dialogue.contexts.Replace("`", ",");
            dialogue.chosen1 = dialogue.chosen1.Replace("`", ",");
            dialogue.chosen2 = dialogue.chosen2.Replace("`", ",");

            dialogueList.Add(dialogue); //리스트의 각 요소에 dialgoue 객체 저장 
        }


        return dialogueList.ToArray();
    }

        
}

