using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jongronpcM : MonoBehaviour
{
     public int helpCount = 0;
     public GameObject ui_dialogue; //¸»Ç³¼±
     public Dialogue[] contextList;
     public int dialogid=0;
    public int manjufirst = 0;
    public int clothesfirst = 0;
     // Start is called before the first frame update
     void Start()
     {
         DataManager.instance.csv_FileName = "jongroB1";
         DataManager.instance.DialogueLoad(); // CSV ÆÄÀÏ ·Îµå
         Debug.Log("csv load");
         dialogid=1;
     }

     void OnMouseDown()
     {
         Debug.Log("NPC clicked");
         StartCoroutine(NpcRoutine());
     }


     public IEnumerator NpcRoutine()
     {
         ui_dialogue.SetActive(true);
         switch (gameObject.name)
         {
             case "Á¤¹Î":
                 contextList = DataManager.instance.GetDialogue(1, 1);
                 DialogueManager.instance.processChoose(contextList);
                 yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);

                 if (DialogueManager.instance.chooseFlag == 1)
                 { 
                     contextList = DataManager.instance.GetDialogue(2, 3);
                     yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                 }

                 DialogueManager.instance.chooseFlag = 0;
                break;

             case "¿Ê °¡°Ô":
                 if(clothesfirst==0)
                 {
                    contextList = DataManager.instance.GetDialogue(21, 23);
                    yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                 }
                clothesfirst = 1;
               
                 
                 break;

                 

             case "µ¨¸®¸¸Áê °¡°Ô":
                if(manjufirst==0)
                {
                    contextList = DataManager.instance.GetDialogue(27, 27);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        contextList = DataManager.instance.GetDialogue(28, 28);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));

                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        contextList = DataManager.instance.GetDialogue(29, 31);
                        yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                    }
                    DialogueManager.instance.chooseFlag = 0;
                    manjufirst = 1;
                   
                   
                }
                break;
               

             case "¿ª¹«½Ç":
                 contextList = DataManager.instance.GetDialogue(35, 38);
                 yield return StartCoroutine(DialogueManager.instance.processing(contextList));
                 break;

          
             default: break;
         }
         ui_dialogue.SetActive(false);
     }
}
