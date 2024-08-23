using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortingmanager : MonoBehaviour
{
  
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // 유저가 오브젝트보다 앞에 있는지 확인
        Vector2 playerTransform = new Vector2(player.transform.position.x,player.transform.position.y);
        if (playerTransform.y > transform.position.y)
        {
            spriteRenderer.sortingOrder = 8; // 유저가 오브젝트 뒤에 있을 때
        }
        else
        {
            spriteRenderer.sortingOrder = 4; // 유저가 오브젝트 앞에 있을 때
        }
    }
}
