using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class timerManager : MonoBehaviour
{
    public static timerManager Instance { get; private set; }

    public float timeRemaining = 300f; // 타이머 초기화 (5분)
    private bool isTimerRunning = false;

    void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 오브젝트가 파괴되지 않음
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 파괴
        }
    }

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                isTimerRunning = false;
                timeRemaining = 0;
                OnTimerEnd(); // 타이머 종료 시 호출
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    private void OnTimerEnd()
    {
        // 타이머 종료 시 원하는 행동을 여기에 추가

        SceneManager.LoadScene("1호선절연"); // 종료 시 다음 씬으로 전환
        Player.playertrans(3.34f, 0.003f);
    }
}