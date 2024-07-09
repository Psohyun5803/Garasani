using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customtest : MonoBehaviour
{
    public Sprite[] basebody;
   
    int spriteindex = 0;
    int frontflag = 0;
    int leftflag = 0;
    int rightflag = 0;
    int backflag = 0; 
    SpriteRenderer spriteRenderer;
    private IEnumerator coroutine;
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = basebody[0];
       // coroutine = breathfront();
       // StartCoroutine(coroutine);
    }

    void Update()
    {

        
    }
    void flagreset()
    {
        frontflag = 0;
        rightflag = 0;
        leftflag = 0;
        backflag = 0;

    }
    void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            spriteindex = 12;
            spriteRenderer.sprite = basebody[spriteindex];
            flagreset();
            backflag = 1;

        }
        if (Input.GetKey(KeyCode.S))
        {
            spriteindex = 0;
            spriteRenderer.sprite = basebody[spriteindex];
            flagreset();
            frontflag = 1;

        }
        if (Input.GetKey(KeyCode.A))
        {
            spriteindex = 4;
            spriteRenderer.sprite = basebody[spriteindex];
            flagreset();
            leftflag = 1;

        }
        if (Input.GetKey(KeyCode.D))
        {
            spriteindex = 8;
            spriteRenderer.sprite = basebody[spriteindex];
            flagreset();
            rightflag = 1;

        }

    }


    private IEnumerator breathfront()
    {
        while (true)
        {
            if ((!Input.anyKeyDown))
            {
                if(frontflag==1)
                {

                    spriteRenderer.sprite = basebody[0];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[1];
                }

                else if(leftflag==1)
                {

                    spriteRenderer.sprite = basebody[4];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[5];
                }

                else if (rightflag == 1)
                {

                    spriteRenderer.sprite = basebody[8];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[9];
                }
                else if (backflag == 1)
                {

                    spriteRenderer.sprite = basebody[12];
                    yield return new WaitForSeconds(0.8f);
                    spriteRenderer.sprite = basebody[13];
                }


            }
                

           

        }


    }
}
