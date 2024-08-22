using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JM_b1 : MonoBehaviour
{
    public static JM_b1 instance;
    void Awake(){
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("기존 인스턴스 파괴1  " + instance.GetInstanceID());
            gameObject.SetActive(false);

            // 기존 인스턴스가 있다면, 새로운 인스턴스는 파괴
            if (instance != this)
            {
                Destroy(gameObject);
                Debug.Log("기존 인스턴스 파괴2  " + instance.GetInstanceID());
                gameObject.SetActive(false);
            }
        }
        else
        {
            // 새 인스턴스가 없다면, 현재 인스턴스를 저장하고 씬 전환 시에도 유지
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("새로운 인스턴스 생성됨: " + GetInstanceID());
        }

    }
    private void OnMouseDown()
    {
        StartCoroutine(Chungmuro_B1.instance.ChungmuroB1());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
