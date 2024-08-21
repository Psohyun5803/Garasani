using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        // 초기 대기 시간 후 InvokeRepeating 시작
        StartCoroutine(StartAfterDelay(initialDelay));
    }

    IEnumerator StartAfterDelay(float delay)
    {
        // 대기 시간 동안 기다립니다.
        yield return new WaitForSeconds(delay);

        // 1분 간격으로 오브젝트 생성
        InvokeRepeating("SpawnMovingObject", 0f, spawnInterval);
    }

    void SpawnMovingObject()
    {
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        GameObject obj = Instantiate(movingObjectPrefab, spawnPoint.position, Quaternion.identity);
        Vector3 startPos = obj.transform.position;

        // 오브젝트가 스톱 포인트까지 이동
        while (Vector3.Distance(obj.transform.position, stopPoint.position) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, stopPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // 10초간 정지
        yield return new WaitForSeconds(stopDuration);

        // 오브젝트가 익스잇 포인트로 이동 후 제거
        while (Vector3.Distance(obj.transform.position, exitPoint.position) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, exitPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(obj);
    }
}