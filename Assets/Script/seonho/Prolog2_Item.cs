using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prolog2_Item : MonoBehaviour
{
    public static Prolog2_Item instance;
    public TMP_Text content; //?? 
    public TMP_Text name; //?? 
    public GameObject talkBubble; //??? 
    public GameObject hammer;
    public GameObject hammerInfo;

    public int hammerflag = 0;

    public Inventory inventory; // Inventory ???? ??

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("Mouse Click");
        Debug.Log(gameObject.name);
        Debug.Log(intertest.colitemname);
        Debug.Log("Hammer flag: " + hammerflag);

        if (intertest.colitemname == "비상문")
        {
            if(hammerflag == 1)
            {
                talkBubble.SetActive(true);
                DialogueManager.instance.name.text = "System";
                DialogueManager.instance.dialogue_text.text = "창문을 깨고 밖으로 나가자.";
                Debug.Log("Loading scene Chungmuro_B3");
                SceneManager.LoadScene("Chungmuro_B3");
            }
            else
            {
                talkBubble.SetActive(true);
                name.text = "System";
                content.text = "여길 통해서 나갈 수 있을 것 같다. 방법을 찾아보자.";
            }
            
        }

        else if (intertest.colitemname == "비상망치")
        {
            talkBubble.SetActive(true);
            DialogueManager.instance.name.text = "System";
            DialogueManager.instance.dialogue_text.text = "[비상망치] : 이걸로 창문을 깨고 나갈 수 있을 것 같다.";
            hammer.SetActive(false);
            hammerInfo.SetActive(false);
            inventory.AddItem("비상망치", "이걸로 창문을 깨고 나갈 수 있을 것 같다.");
            hammerflag = 1;
            Debug.Log("Hammer collected, hammerflag set to 1");
        }
    }
}