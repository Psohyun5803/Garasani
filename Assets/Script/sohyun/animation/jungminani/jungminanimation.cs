using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TreeEditor.TreeGroup;

public class jungminanimation : MonoBehaviour
{
    Animator animator;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x - 1,
                            player.transform.position.y, 0);
        }
        if(Player.moveflag!=0) // 플레이어가 움직일 수 있으면 
        {
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("walk", true);
                animator.SetBool("left", true);
                animator.SetBool("right", false);
                animator.SetBool("back", false);
                animator.SetBool("front", false);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("left", false);
                animator.SetBool("back", false);
                animator.SetBool("front", false);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("walk", true);
                animator.SetBool("front", true);
                animator.SetBool("left", false);
                animator.SetBool("right", false);
                animator.SetBool("back", false);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("walk", true);
                animator.SetBool("front", false);
                animator.SetBool("left", false);
                animator.SetBool("right", false);
                animator.SetBool("back", true);
            }
            else
            {
                animator.SetBool("walk", false);
            }

        }
        else// moveflag 0이면 walk 비활성화 
        {
            animator.SetBool("walk", false);
        }
    }
}
