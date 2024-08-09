using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SNSsystem : MonoBehaviour
{
    public static SNSsystem instance;
    public GameObject ch3_market;
    public GameObject ch3_home;
    public GameObject ch3_weather;
    public GameObject ch3_movie;
    public GameObject ch3_horror;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void SNSmanager() //챕터 시작할 때마다 각 스크립트에 함수 삽입
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "PhoneUI":
                ch3_home.SetActive(true);
                ch3_market.SetActive(true);
                ch3_weather.SetActive(true);
                ch3_movie.SetActive(true);
                ch3_horror.SetActive(true);
                break;
            case "Jongro3":
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ch3_home.SetActive(false);
        ch3_market.SetActive(false);
        ch3_weather.SetActive(false);
        ch3_movie.SetActive(false);
        ch3_horror.SetActive(false);
        //SNSmanager();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
