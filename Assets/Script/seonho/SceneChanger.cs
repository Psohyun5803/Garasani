using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string targetSceneName;  // 이동할 씬의 이름

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // 플레이어와 충돌했는지 확인
        {
            SceneManager.LoadScene(targetSceneName);  // 씬 이동
        }
    }
}