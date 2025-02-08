using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SNS_4_ChungmuroB3 : MonoBehaviour
{
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
                if (child.CompareTag("sns_prol"))  // 특정 태그가 달린 자식인지 확인
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
