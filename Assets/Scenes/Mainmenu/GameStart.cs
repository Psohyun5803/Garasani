using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string StartScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(StartScene);
    }
}