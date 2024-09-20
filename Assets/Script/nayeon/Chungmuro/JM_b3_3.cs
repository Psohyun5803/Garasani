using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JM_b3_3 : MonoBehaviour
{
    public static JM_b3_3 instance;

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

    // private void OnMouseDown()
    // {
    //     Debug.Log("클릭 확인");
    //    if (Chungmuro_B3.instance != null)
    //     {
    //         StartCoroutine(Chungmuro_B3.instance.ChungmuroB3_1());
    //     }
    //     else
    //     {
    //         Debug.LogError("Chungmuro_B3 instance is not initialized.");
    //     }
    // }
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name=="4_Chungmuro_B3") //4호선 승강장에서는 정민이가 없어야하므로 
        {
            GameObject persistentObject = GameObject.FindWithTag("jeongmin");

            // 오브젝트가 존재하면 삭제
            if (persistentObject != null)
            {
                Destroy(persistentObject);
            }
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
