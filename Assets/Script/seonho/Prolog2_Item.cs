using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prolog2_Item : MonoBehaviour
{
    public TMP_Text content; //?? 
    public TMP_Text name; //?? 
    public GameObject talkBubble; //??? 
    public GameObject hammer;
    public GameObject hammerInfo;

    int hammerflag = 0;

    public Inventory inventory; // Inventory ???? ??

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

        if (intertest.colitemname == "???")
        {
            talkBubble.SetActive(true);
            name.text = "System";
            content.text = "??? ?? ??? ???.";
            Debug.Log("Loading scene Chungmuro_B3");
            SceneManager.LoadScene("Chungmuro_B3");
        }

        else if (intertest.colitemname == "????")
        {
            talkBubble.SetActive(true);
            name.text = "System";
            content.text = "[????] : ??? ??? ?? ?? ? ?? ? ??.";
            hammer.SetActive(false);
            hammerInfo.SetActive(false);
            inventory.AddItem("????", "??? ??? ?? ?? ? ?? ? ??.");
            hammerflag = 1;
            Debug.Log("Hammer collected, hammerflag set to 1");
        }
    }
}