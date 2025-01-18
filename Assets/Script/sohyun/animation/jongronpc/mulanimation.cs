using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mulanimation : MonoBehaviour
{
    Animator animator;
    public float minPosition = -3f; // 이동 가능한 최소 위치
    public float maxPosition = 3f;  // 이동 가능한 최대 위치
    public float speed = 2f;        // 이동 속도
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    

    private bool movingfront = true; // NPC가 현재 앞으로 이동 중인지 여부

    void Update()
    {
        if (movingfront)
        {
            // 애니메이션 상태를 먼저 변경
            animator.SetBool("front", true);
            animator.SetBool("back", false);

            // 이동 로직
            transform.position += Vector3.up * speed * Time.deltaTime;

            if (transform.position.y >= maxPosition)
            {
                movingfront = false;
            }
        }
        else
        {
            // 애니메이션 상태를 먼저 변경
            animator.SetBool("front", false);
            animator.SetBool("back", true);

            // 이동 로직
            transform.position += Vector3.down * speed * Time.deltaTime;

            if (transform.position.y <= minPosition)
            {
                movingfront = true;
            }
        }
    }


}
