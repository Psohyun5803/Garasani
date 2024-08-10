using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prolog2_Item : MonoBehaviour
{
    public TMP_Text 내용;
    public TMP_Text 이름;
    public GameObject 말풍선;
    public GameObject hammer;
    public GameObject hammerInfo;

    int hammerflag = 0;

    public Inventory inventory; // Inventory 스크립트 참조

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
        Debug.Log(intertest.충돌아이템명);
        Debug.Log("Hammer flag: " + hammerflag);

        if (intertest.충돌아이템명 == "비상문")
        {
            말풍선.SetActive(true);
            이름.text = "System";
            내용.text = "창문을 깨고 밖으로 나갔다.";
            Debug.Log("Loading scene Chungmuro_B3");
            SceneManager.LoadScene("Chungmuro_B3");
        }

        else if (intertest.충돌아이템명 == "비상망치")
        {
            말풍선.SetActive(true);
            이름.text = "System";
            내용.text = "[비상망치] : 이걸로 창문을 깨고 나갈 수 있을 것 같다.";
            hammer.SetActive(false);
            hammerInfo.SetActive(false);
            inventory.AddItem("비상망치", "이걸로 창문을 깨고 나갈 수 있을 것 같다.");
            hammerflag = 1;
            Debug.Log("Hammer collected, hammerflag set to 1");
        }
    }
}