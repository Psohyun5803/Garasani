using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject slotSelectUI;

    void Start()
    {
        // 슬롯 선택 UI 비활성화
        slotSelectUI.SetActive(false);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("newcustomize");
    }

    public void ContinueGame()
    {
        slotSelectUI.SetActive(true);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}