using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{


    public GameObject Target;               // 카메라가 따라다닐 타겟

    public float offsetX = 0f;            // 카메라의 x좌표
    public float offsetY = 0f;           // 카메라의 y좌표
            // 카메라의 z좌표

    public float CameraSpeed = 0.001f;       // 카메라의 속도
    Vector3 TargetPos;                      // 타겟의 위치


    void Start()
    {
        Target = GameObject.Find("Player");
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {

        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정

        Vector3 TargetPos = Camera.main.WorldToViewportPoint(Target.transform.position);
        /*TargetPos = new Vector2(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY
           
            );*/

        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
 
    
}


