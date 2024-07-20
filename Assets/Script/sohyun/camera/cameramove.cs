using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{


    public GameObject Target;               // 카메라가 따라다닐 타겟

    
    Transform AT;
   
    


    void Start()
    {
        Target = GameObject.Find("Player");
        AT = Target.transform;
    }
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            //플레이어의 위치와 연동
            transform.position = new Vector3(player.transform.position.x,
                             player.transform.position.y, -10);

            
        }
        else
        {
            Debug.Log("null");
        }
    }
    // Update is called once per frame
    /*void LateUpdate()
    {
        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
    }*/
    /*void FixedUpdate()
    {

        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정

        Vector3 TargetPos = Camera.main.WorldToViewportPoint(Target.transform.position);
        /*TargetPos = new Vector2(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY
           
            );

        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }*/
 
    
}


