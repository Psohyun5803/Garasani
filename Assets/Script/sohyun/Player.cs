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
   
    private IEnumerator walkfront;
    private IEnumerator walkright;
    private IEnumerator walkleft;
    private IEnumerator walkback;
   
    public static Action<float, float> playertrans;

    int coroutineflag = 0;
    int coroutineflag2 = 0;
    void Start ()
    {
        frontflag = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = basebody[0];
        coroutine = breathfront();
      
        walkfront = walkmotionfront();
        walkleft = walkmotionleft();
        walkright = walkmotionright();
        walkback = walkmotionback();
      
    }
    public void player이동(float x, float y)
    {
        Vector3 newPosition = new Vector3(x , y , 0);
        player.transform.position = newPosition;
    }
    void Awake()
    {
        playertrans = (float x, float y) => { player이동(x, y); };
    }
    void Update()
    {   
        //move();
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D))) //누를때
        {

            if (coroutineflag == 1) // 움직일때
            {

                StopAllCoroutines();
                coroutineflag = 0;
                

            }
            move();
        }
        else //안누를때
        {
            if (coroutineflag2 == 1)
            {
                StopAllCoroutines();

                coroutineflag2 = 0;
               

            }

            if (coroutineflag == 0)
            {
                StartCoroutine(coroutine);
            }
        }
        if((Input.GetKeyUp(KeyCode.A)))
        {
            leftflag = 1;
        }
        if ((Input.GetKeyUp(KeyCode.S)))
        {
            frontflag = 1;
        }
        if ((Input.GetKeyUp(KeyCode.D)))
        {
            rightflag = 1;
        }
        if ((Input.GetKeyUp(KeyCode.W)))
        {
            backflag = 1;
        }




        /* if ((Input.GetKeyUp(KeyCode.A))|| (Input.GetKeyUp(KeyCode.W))|| (Input.GetKeyUp(KeyCode.S))|| (Input.GetKeyUp(KeyCode.D))) //멈췄을때
         {


             if (coroutineflag2==1)
             {
                 StopAllCoroutines();

                 coroutineflag2 = 0;
                 coroutineflag = 0;

             }

             if (coroutineflag == 0)
             {
                 StartCoroutine(coroutine);
             }


         }
         else
         {

             if (coroutineflag==1) // 움직일때
             {

                 StopCoroutine(coroutine);
                 coroutineflag = 0;

             }

         }*/



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
    private float Speed = 0.5f;
    public void move()
    {   
        if(customize.sceneflag>1)
        {
            float X = Input.GetAxisRaw("Horizontal");
            float Y = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.W))
            {
                frontflag = 0;
                rightflag = 0;
                leftflag = 0;
                backflag = 1;
                //spriteindex = 12;
                //spriteRenderer.sprite = basebody[spriteindex];


                if (coroutineflag2 == 0)
                {
                    StopAllCoroutines();
                    coroutineflag = 0;
                    StartCoroutine(walkback);
                }

            }
            else if (Input.GetKey(KeyCode.S))
            {
                frontflag = 1;
                rightflag = 0;
                leftflag = 0;
                backflag = 0;
                //spriteindex = 0;
                //spriteRenderer.sprite = basebody[spriteindex];




                if (coroutineflag2 == 0)
                {
                    StopAllCoroutines();
                    coroutineflag = 0;
                    StartCoroutine(walkfront);
                }


            }
            else if (Input.GetKey(KeyCode.A))
            {
                frontflag = 0;
                rightflag = 0;
                leftflag = 1;
                backflag = 0;
                //spriteindex = 4;
                //spriteRenderer.sprite = basebody[spriteindex];


                if (coroutineflag2 == 0)
                {
                    StopAllCoroutines();
                    coroutineflag = 0;
                    StartCoroutine(walkleft);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                frontflag = 0;
                rightflag = 1;
                leftflag = 0;
                backflag = 0;
                //spriteindex = 8;
                //spriteRenderer.sprite = basebody[spriteindex];


                if (coroutineflag2 == 0)
                {
                    StopAllCoroutines();
                    coroutineflag = 0;
                    StartCoroutine(walkright);
                }
            }

            player.transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);

        }
       
    }


    private IEnumerator breathfront()
    {
        while (true)
        {

            coroutineflag = 1;

            if (frontflag == 1)
            {
                

                spriteRenderer.sprite = basebody[0];


                yield return new WaitForSeconds(0.5f);
                
                if (frontflag == 1)
                {
                    spriteRenderer.sprite = basebody[1];

                   
                    yield return new WaitForSeconds(0.5f);
                }


                ;
            }

            else if (leftflag == 1)
            {
               

                spriteRenderer.sprite = basebody[4];


                yield return new WaitForSeconds(0.5f);
                if (leftflag == 1)
                {
                    spriteRenderer.sprite = basebody[5];

                    yield return new WaitForSeconds(0.5f);
                }


            }
            else if (rightflag == 1)
            {
                

                spriteRenderer.sprite = basebody[8];


                yield return new WaitForSeconds(0.5f);
                if (rightflag == 1)
                {
                    spriteRenderer.sprite = basebody[9];

                   
                    yield return new WaitForSeconds(0.5f);
                }



            }
            else if (backflag == 1)
            {


                spriteRenderer.sprite = basebody[12];

                yield return new WaitForSeconds(0.5f);
                if(backflag==1)
                {
                    spriteRenderer.sprite = basebody[13];



                    yield return new WaitForSeconds(0.5f);
                }
               
            }

            else
            {
                break;
            }
        }
    }


    private IEnumerator walkmotionfront()
    {
        while(true)
        {
            coroutineflag2 = 1;
            
            if (frontflag == 1)
            {

                spriteRenderer.sprite = basebody[2];
                
            }
                
            yield return new WaitForSeconds(0.6f);
            if (frontflag == 1)
            {
                spriteRenderer.sprite = basebody[3];
               
                yield return new WaitForSeconds(0.6f);
            }
               

            
        }
        
    }
    private IEnumerator walkmotionleft()
    {
        while (true)
        {
            coroutineflag2 = 1;
          
            if (leftflag == 1)
            {

                spriteRenderer.sprite = basebody[6];
               
            }

            yield return new WaitForSeconds(0.6f);
            if (leftflag == 1)
            {
                spriteRenderer.sprite = basebody[7];
               
                yield return new WaitForSeconds(0.6f);
            }




        }

    }
    private IEnumerator walkmotionright()
    {
        while (true)
        {
            coroutineflag2 = 1;
           
            if (rightflag == 1)
            {

                spriteRenderer.sprite = basebody[10];
              
            }

            yield return new WaitForSeconds(0.6f);
            if (rightflag == 1)
            {
                spriteRenderer.sprite = basebody[11];
              
                yield return new WaitForSeconds(0.6f);
            }


           
        }

    }
    private IEnumerator walkmotionback()
    {
        while (true)
        {
            coroutineflag2 = 1;
            
            if (backflag == 1)
            {

                spriteRenderer.sprite = basebody[14];
               
            }

            yield return new WaitForSeconds(0.6f);
            if (backflag == 1)
            {
                spriteRenderer.sprite = basebody[15];
               
                yield return new WaitForSeconds(0.6f);
            }


           
        }

    }


   
    
            
              
            
                

    

    
}
