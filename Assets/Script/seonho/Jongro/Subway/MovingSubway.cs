using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingSubway : MonoBehaviour
{
    public GameObject movingObjectPrefab; // 이동하는 오브젝트 프리팹
    public Transform spawnPoint; // 오브젝트가 생성될 위치
    public Transform stopPoint; // 오브젝트가 멈출 위치
    public Transform exitPoint; // 오브젝트가 사라질 위치
    public float moveSpeed = 2f; // 오브젝트 이동 속도
    public float spawnInterval = 60f; // 오브젝트 생성 간격 (1분)
    public float stopDuration = 10f; // 오브젝트가 멈춰있는 시간
    public float initialDelay = 5f; // 초기 대기 시간 (30초)

    public bool IsSubwayStopped { get; private set; } = false;
    private GameObject currentSubway;

    private void Start()
    {
        StartCoroutine(StartAfterDelay(initialDelay));
    }

    IEnumerator StartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        InvokeRepeating("SpawnMovingObject", 0f, spawnInterval);
    }

    void SpawnMovingObject()
    {
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        IsSubwayStopped = false;
        currentSubway = Instantiate(movingObjectPrefab, spawnPoint.position, Quaternion.identity);

        // 오브젝트가 스톱 포인트까지 이동
        while (Vector3.Distance(currentSubway.transform.position, stopPoint.position) > 0.1f)
        {
            currentSubway.transform.position = Vector3.MoveTowards(currentSubway.transform.position, stopPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // 지하철이 스톱 포인트에 도달했을 때 상태 업데이트
        IsSubwayStopped = true;
        Debug.Log("Subway has reached the stop point. IsSubwayStopped = " + IsSubwayStopped);

        // 10초간 정지
        yield return new WaitForSeconds(stopDuration);

        IsSubwayStopped = false;
        Debug.Log("Subway is leaving the stop point. IsSubwayStopped = " + IsSubwayStopped);

        // 오브젝트가 익스잇 포인트로 이동 후 제거
        while (Vector3.Distance(currentSubway.transform.position, exitPoint.position) > 0.1f)
        {
            currentSubway.transform.position = Vector3.MoveTowards(currentSubway.transform.position, exitPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(currentSubway);
    }
}