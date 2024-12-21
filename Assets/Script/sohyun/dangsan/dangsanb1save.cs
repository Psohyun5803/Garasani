using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangsanb1save : MonoBehaviour
{
    

    public GameObject ui_dialogue; //말풍선
    public GameObject player;
    public Dialogue[] contextList;
    private int dialogueid = 14;
    private bool saveflag = false;

    // Start is called before the first frame update
    void Update()
    {

    }


    void Start()
    {


        player = GameObject.Find("Player");

        if (player != null)
        {
            Debug.Log("Player object found!");
        }
        else
        {
            Debug.Log("Player object not found!");
        }



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.CompareTag("Player")&&saveflag==false)
        {
            Debug.Log("Player entered the trigger zone!");
            Player.moveflag = 0;
            StartCoroutine(NpcRoutine());
        }
    }
  





    public IEnumerator NpcRoutine()
    {
        ui_dialogue.SetActive(true);
        while (dialogueid < 15)
        {
            switch (dialogueid)
            {
                case 14:
                    contextList = DataManager.instance.GetDialogue(27, 27);
                    DialogueManager.instance.processChoose(contextList);
                    yield return new WaitUntil(() => DialogueManager.instance.chooseFlag != 0);
                    if (DialogueManager.instance.chooseFlag == 1)
                    {
                        dialogueid = 15;
                        //재화차감
                        Player.moveflag = 1;
                        //moveflag 다시 1
                        saveflag = true;
                    }
                    else if (DialogueManager.instance.chooseFlag == 2)
                    {
                        dialogueid = 15;

                        Player.moveflag = 1;
                        Vector3 currentPosition = player.transform.position;

                        // Y축으로 +0.5만큼 이동
                        player.transform.position = new Vector3(currentPosition.x, currentPosition.y + 0.5f, currentPosition.z);

                    }

                    DialogueManager.instance.chooseFlag = 0;

                    break;
                case 15:
                    dialogueid = 15;
                    break;
                default:
                    dialogueid = 15;
                    break;

            }


        }

        ui_dialogue.SetActive(false);
        if(saveflag==false)
        {
            dialogueid = 14;
        }


    }

}
