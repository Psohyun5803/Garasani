using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNS_JONGRO : MonoBehaviour
{
    public GameObject twit1;
    public GameObject twit2;
    public GameObject twit3;
    public GameObject twit4;
    public GameObject twit5;
    public GameObject twit6;
    public GameObject whole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (whole.activeSelf)
        {
            foreach (Transform child in whole.transform)
            {
                if (child.CompareTag("SNS_JONGRO"))  // 특정 태그가 달린 자식인지 확인
                {
                    child.gameObject.SetActive(true);  // 해당 자식만 활성화
                    Debug.Log("활성됨");
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
