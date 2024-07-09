using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customtest : MonoBehaviour
{
    public Sprite[] basebody;
   
    int spriteindex = 0;
    
    SpriteRenderer spriteRenderer;
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
  
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            spriteindex = 12;
            spriteRenderer.sprite = basebody[spriteindex];

        }
        if (Input.GetKey(KeyCode.S))
        {
            spriteindex = 0;
            spriteRenderer.sprite = basebody[spriteindex];

        }
        if (Input.GetKey(KeyCode.A))
        {
            spriteindex = 4;
            spriteRenderer.sprite = basebody[spriteindex];

        }
        if (Input.GetKey(KeyCode.D))
        {
            spriteindex = 8;
            spriteRenderer.sprite = basebody[spriteindex];

        }
    }
}
