using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singletone : MonoBehaviour
{
    private static singletone instance;

    void Awake()
    {
        // 이미 인스턴스가 존재하는지 확인
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // 이 오브젝트를 파괴하지 않도록 설정
        }
        else
        {
            Destroy(gameObject);  // 중복 생성된 경우 파괴
        }
    }
}
