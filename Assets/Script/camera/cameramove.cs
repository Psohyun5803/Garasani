using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{


    public GameObject Target;      
    Transform AT;
    public static cameramove instance;
    public float cameraSpeed = 1.0f;  // ??? ?? ??
    public Vector3 targetPosition;    // ??? ??

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

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
            /*Vector3 velo = Vector3.zero;

            //?????????? ?????? ????
            Vector3 movepos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            transform.position = Vector3.SmoothDamp(transform.position, movepos,ref velo, 0.1f);*/
            transform.position = new Vector3(player.transform.position.x,
                            player.transform.position.y, -10);


        }
        else
        {
            Debug.Log("null");
        }
    }


    //public IEnumerator JMmove()
    //{
    //    // 1. ???? "???" ????? ??
    //    Target = GameObject.FindGameObjectWithTag("jeongmin");
    //    if (Target != null)
    //    {
    //        // target ?? ??
    //        targetPosition = new Vector3(this.transform.position.x, Target.transform.position.y, Target.transform.position.z);

    //        // ?? ?? ?? ??? ??
    //        while (Vector3.Distance(this.transform.position, targetPosition) > 0.01f)
    //        {
    //            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    //            yield return null; // ?? ????? ??
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Target 'jeongmin' not found.");
    //    }

    //    yield return new WaitForSeconds(2.0f);

    //    // 2. ???? ?? ????? ??
    //    Target = GameObject.FindGameObjectWithTag("Player");
    //    if (Target != null)
    //    {
    //        // target ?? ??
    //        targetPosition = new Vector3(this.transform.position.x, Target.transform.position.y, Target.transform.position.z);

    //        // ?? ?? ?? ??? ??
    //        while (Vector3.Distance(this.transform.position, targetPosition) > 0.01f)
    //        {
    //            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    //            yield return null; // ?? ????? ??
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Target 'Player' not found.");
    //    }
    //}


    //private void MoveCameraToTarget(Transform targetTransform)
    //{
    //    if (targetTransform != null)
    //    {
    //        transform.position = new Vector3(targetTransform.position.x,
    //                                         targetTransform.position.y, -10);
    //    }
    //}

    // Update is called once per frame
    /*void LateUpdate()
    {
        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
    }*/
    /*void FixedUpdate()
    {

        // ?????? x, y, z ?????? ???????? ?????? ?????? ???????? ?????? ????

        Vector3 TargetPos = Camera.main.WorldToViewportPoint(Target.transform.position);
        /*TargetPos = new Vector2(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY
           
            );

        // ???????? ???????? ???????? ???? ????(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }*/


}


