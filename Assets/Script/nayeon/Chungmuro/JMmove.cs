using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class JMmove : MonoBehaviour
{
    public static JMmove instance;

    private void Awake()
    {
       
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
        Debug.Log("대화 시직");
        StartCoroutine(Chungmuro_B2.instance.ChungmuroB2_1());
    }

}
