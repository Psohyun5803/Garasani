using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public int helpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.instance.csv_FileName = "npc";
        DataManager.instance.DialogueLoad(); // CSV 파일 로드
    }

   void onMouseDown(){
        StartCoroutine(NpcRoutine());
   }

   public IEnumerator NpcRoutine(){
        switch(gameObject.name){
                case "리어카 끄는 노인":
                    //물건 구매 기능 추가
                    contextList = DataManager.instance.GetDialogue(1, 1);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;
                
                case "시비거는노인":
                    contextList = DataManager.instance.GetDialogue(2, 4);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;

                case "물건을 훔치는 노인":
                    contextList = DataManager.instance.GetDialogue(5, 11);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;
                
                case "헛소리 하는 노인":
                    contextList = DataManager.instance.GetDialogue(12, 19);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;

                case "도움이 필요해보이는 노인":
                    if(helpCount == 0){
                        contextList = DataManager.instance.GetDialogue(20, 22);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }
                    else if(helpCount == 1){
                        contextList = DataManager.instance.GetDialogue(23, 28);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }
                    else if(helpCount == 2){
                        contextList = DataManager.instance.GetDialogue(29, 29);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }
                    else{
                        contextList = DataManager.instance.GetDialogue(30, 30);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }
                    helpCount ++; //안경 가져다 주기 구현 필요 
                    break;
                
                case "사주 봐주눈 노인":
                    contextList = DataManager.instance.GetDialogue(31, 35);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1){ //사주 보기 선택 
                        //돈 조정 
                        contextList = DataManager.instance.GetDialogue(36, 39);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    break;
                
                case "잡상인":
                    //물건 사는 경우
                    contextList = DataManager.instance.GetDialogue(44, 44);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    //물건 사지 않는 경우 
                    contextList = DataManager.instance.GetDialogue(45, 46);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;

                case "사이비" :
                    contextList = DataManager.instance.GetDialogue(47, 51);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1){ //진짜요 선택지 
                        contextList = DataManager.instance.GetDialogue(52, 54);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }
                    else if (DialogueManager.instance.chooseFlag == 3){ //시비를 건다 선택지 
                        contextList = DataManager.instance.GetDialogue(55, 58);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }

                    DialogueManager.instance.chooseFlag = 0;
                    break;
                
                case "음식 파는 할머니" :
                    //음식 구매시 구현 필요 
                    contextList = DataManager.instance.GetDialogue(59, 59);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;

                case "앵벌이":
                    contextList = DataManager.instance.GetDialogue(60, 60);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    break;

                
                case "시비거는 취객":
                    contextList = DataManager.instance.GetDialogue(61, 61);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                    if (DialogueManager.instance.chooseFlag == 1){ //가위바위보 구현 필요 
                        contextList = DataManager.instance.GetDialogue(62, 62); //이겼을 때 대사 
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }
                    break;
                default : break;
            }
    }
}
