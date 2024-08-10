using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SNSsystem : MonoBehaviour
{
    public static SNSsystem instance;
    public GameObject ch1_market;
    public GameObject ch1_home;
    public GameObject ch1_weather;
    public GameObject ch1_movie;
    public GameObject ch1_horror;

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
            case "Pro_map_2": //prologue2
                GameObject[] prol2_sns = GameObject.FindGameObjectsWithTag("sns_prol");
                foreach(GameObject obj in prol2_sns)
                {
                    obj.SetActive(true);
                }
                break;
            case "PhoneUI":
                GameObject[] ch1_sns = GameObject.FindGameObjectsWithTag("sns_ch1");
                foreach (GameObject obj in ch1_sns)
                {
                    obj.SetActive(true);
                }
                break;
            case "Jongro3":
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ch1_home.SetActive(false);
        ch1_market.SetActive(false);
        ch1_weather.SetActive(false);
        ch1_movie.SetActive(false);
        ch1_horror.SetActive(false);
        //SNSmanager();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
