using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npctonext : MonoBehaviour //npc가 대화를 끝 마치고 옆칸으로 이동하게함 
{
    public int firstflag=0;
    public Transform target;

    // 이동 속도
    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name=="잡상인")
        {
            if (firstflag == 0 && NPCManager.jobflag == 1)
            {
                firstflag = 1;
                StartCoroutine(move(target.position));


            }
        }

        if (gameObject.name=="사이비")
        {
            if (firstflag == 0 && NPCManager.godflag == 1)
            {
                firstflag = 1;
                StartCoroutine(move(target.position));


            }
        }


    }

    public IEnumerator move(Vector3 targetPosition)
    {
        // 현재 위치와 목표 위치의 거리가 0.1보다 클 동안 계속 이동
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            // 현재 위치에서 목표 위치로 매 프레임 조금씩 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 다음 프레임을 기다림
            yield return null;
        }

        // 도착한 후 정확하게 목표 위치로 설정
        transform.position = targetPosition;
        gameObject.SetActive(false);
    }
   
}
