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
    public static int 충돌flag = 0;
    
    SpriteRenderer spriteRenderer;
    public static Action 적용함수;
    private IEnumerator coroutine;
   
    private IEnumerator walkfront;
    private IEnumerator walkright;
    private IEnumerator walkleft;
    private IEnumerator walkback;
   
    public static Action<float, float> playertrans;
    public static Action<float, float,float,float> 이동범위;
    public static Action 앉은자세;
    public static Action 앉은자세해제;
   

    public static int sitdown = 0;
    public static int 두리번 = 0;
    public static int 버둥 = 0;


    int coroutineflag = 0;
    int coroutineflag2 = 0;
    public static int moveflag = 1;
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
        //이동범위 = (float x1, float x2,float y1, float y2) => { 플레이어이동범위(x1,x2,y1, y2); };

    }
    
    void Update()
    {

        플레이어이동범위(-4f, 10f, 0f, 2f);
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
    public void 플레이어이동범위(float x1, float x2,float y1, float y2)
    {
        if (player.transform.position.x <x1)
        {
           
        }
        /*if(player.transform.position.x >x2)
        {
            player.transform.Translate = new Vector3(x2, player.transform.position.y, player.transform.position.z);
        }
        if (player.transform.position.y <y1 )
        {
            player.transform.Translate = new Vector3(player.transform.position.x, y1, player.transform.position.z);
        }
        if (player.transform.position.y > y2)
        {
            player.transform.Translate = new Vector3(player.transform.position.x, y2, player.transform.position.z);
        }*/
        else
        {
            moveflag = 1;
        }
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
    private float Speed = 0.42f;
    public void move()
    {   
        if(customize.sceneflag>1&&moveflag==1)
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

            //player.transform.Translate(new Vector2(Mathf.Clamp(X,-4f,10f), Y) * Time.deltaTime * Speed);
            player.transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);
            //Vector3 localPosition;
            //localPosition = new Vector3(Mathf.Clamp(player.transform.position.x, -4f, 10f),
            //    (localPosition = player.transform.localPosition).y, localPosition.z);
            //player.transform.localPosition = localPosition;
        }
       
    }


    private IEnumerator breathfront()
    {
        while (true)
        {

            coroutineflag = 1;
            if(sitdown==1)
            {

            
                spriteRenderer.sprite = basebody[20];


                yield return new WaitForSeconds(0.5f);
                if (sitdown == 1)
                {
                    spriteRenderer.sprite = basebody[21];

                    yield return new WaitForSeconds(0.5f);
                }
            }
            else if (두리번 == 1)
            {


                spriteRenderer.sprite = basebody[16];


                yield return new WaitForSeconds(0.5f);
                if (두리번 == 1)
                {
                    spriteRenderer.sprite = basebody[17];

                    yield return new WaitForSeconds(0.5f);
                }
            }

            else if (버둥 == 1)
            {


                spriteRenderer.sprite = basebody[18];


                yield return new WaitForSeconds(0.5f);
                if (버둥 == 1)
                {
                    spriteRenderer.sprite = basebody[19];

                    yield return new WaitForSeconds(0.5f);
                }
            }
            else if (frontflag == 1)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌감지");
        충돌flag = 1;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("충돌벗어남");
        충돌flag = 0;
    }












}
