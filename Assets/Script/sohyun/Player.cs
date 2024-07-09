using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Sprite[] basebody;
    public GameObject player;
    int spriteindex = 0;
    int keydown = 0;
    int frontflag = 0;
    int leftflag = 0;
    int rightflag = 0;
    int backflag = 0; 
    SpriteRenderer spriteRenderer;
    public static Action 적용함수;
    private IEnumerator coroutine;
    private IEnumerator walk;

    void Start ()
    {
        frontflag = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = basebody[0];
        coroutine = breathfront();
        walk = walkmotion();
        StartCoroutine(walk);
        StartCoroutine(coroutine);
    }

    void Update()
    {   
        move();
        
    }
    void flagreset()
    {
        frontflag = 0;
        rightflag = 0;
        leftflag = 0;
        backflag = 0;

    }
    public void 적용()
    {
        spriteRenderer.sprite = basebody[spriteindex];
        Debug.Log("적용됨");
    }
    private float Speed = 0.1f;
    public void move()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);

        if (Input.GetKey(KeyCode.W))
        {
            spriteindex = 12;
            spriteRenderer.sprite = basebody[spriteindex];

            frontflag = 0;
            rightflag = 0;
            leftflag = 0;
            backflag = 1;

        }
        if (Input.GetKey(KeyCode.S))
        {
            spriteindex = 0;
            spriteRenderer.sprite = basebody[spriteindex];
            flagreset();
            frontflag = 1;
            rightflag = 0;
            leftflag = 0;
            backflag = 0;
            

        }
        if (Input.GetKey(KeyCode.A))
        {
            spriteindex = 4;
            spriteRenderer.sprite = basebody[spriteindex];
            flagreset();
            frontflag = 0;
            rightflag = 0;
            leftflag = 1;
            backflag = 0;

        }
        if (Input.GetKey(KeyCode.D))
        {
            spriteindex = 8;
            spriteRenderer.sprite = basebody[spriteindex];
            flagreset();
            frontflag = 0;
            rightflag = 1;
            leftflag = 0;
            backflag = 0;

        }
        player.transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);

    }


    private IEnumerator breathfront()
    {
        while (true)
        {
            if ((!Input.anyKeyDown))
            {
                yield return new WaitForSeconds(0.8f);
                if (frontflag == 1)
                {

                    spriteRenderer.sprite = basebody[0];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[1];
                    yield return new WaitForSeconds(0.2f);
                }

                else if (leftflag == 1)
                {

                    spriteRenderer.sprite = basebody[4];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[5];
                    yield return new WaitForSeconds(0.2f);
                }

                else if (rightflag == 1)
                {

                    spriteRenderer.sprite = basebody[8];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[9];
                    yield return new WaitForSeconds(0.2f);
                }
                else if (backflag == 1)
                {

                    spriteRenderer.sprite = basebody[12];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[13];
                    yield return new WaitForSeconds(0.2f);
                }


            }
        }
    }

    private IEnumerator walkmotion()
    {
        while(true)
        {
            if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
            {
                Debug.Log("진입");
                yield return new WaitForSeconds(0.8f);
                if (frontflag == 1)
                {

                    spriteRenderer.sprite = basebody[2];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[3];
                    yield return new WaitForSeconds(0.2f);
                }

                else if (leftflag == 1)
                {

                    spriteRenderer.sprite = basebody[6];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[7];
                    yield return new WaitForSeconds(0.2f);
                }

                else if (rightflag == 1)
                {

                    spriteRenderer.sprite = basebody[10];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[11];
                    yield return new WaitForSeconds(0.2f);
                }
                else if (backflag == 1)
                {

                    spriteRenderer.sprite = basebody[14];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[15];
                    yield return new WaitForSeconds(0.2f);
                }
            }

        }
    
    }
            
              
            
                

    

    
}
