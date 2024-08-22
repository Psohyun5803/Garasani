using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jihoon_B2 : MonoBehaviour
{

    public Sprite[] basebody;
    public GameObject player;
    int spriteindex = 0;

    int frontflag = 0;
    int leftflag = 0;
    int rightflag = 0;
    int backflag = 0;


    public static int jihoonmove = 0;


    int interjihoon1 = 0;


    public static int colflag = 0;

    SpriteRenderer spriteRenderer;

    private IEnumerator coroutine;

    private IEnumerator walkfront;
    private IEnumerator walkright;
    private IEnumerator walkleft;
    private IEnumerator walkback;


    public static int sitdown = 0;
    public static int lookaround = 0;
    public static int shock = 0;


    int coroutineflag = 0;
    int coroutineflag2 = 0;
    public static int moveflag = 1;
    void Start()
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


    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && jihoonmove == 1)
        {

            transform.position = new Vector3(player.transform.position.x + 1,
                            player.transform.position.y + 1, 0);


        }
        //move();
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D))) //??????
        {

            if (coroutineflag == 1) // ????????
            {

                StopAllCoroutines();
                coroutineflag = 0;


            }
            move();
        }
        else //????????
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
        if ((Input.GetKeyUp(KeyCode.A)))
        {
            leftflag = 1;
        }
        if ((Input.GetKeyUp(KeyCode.S)) )
        {
            frontflag = 1;
        }
        if ((Input.GetKeyUp(KeyCode.D)))
        {
            rightflag = 1;
        }
        if ((Input.GetKeyUp(KeyCode.W)) )
        {
            backflag = 1;
        }







    }


    public void apply()
    {
        spriteRenderer.sprite = basebody[spriteindex];
        Debug.Log("??'");
    }
    private float Speed = 0.82f;//0.42f
    //[SerializeField] LayerMask layermask;
    public float distance;

    void FindGround()
    {
        RaycastHit hitinfo;
        //hitinfo = Physics2D.Raycast(transform.position, transform.right, distance);
        Debug.DrawRay(transform.position, Vector2.down, new Color(1, 0, 0));

        //Debug.Log("????");
        if (Physics.Raycast(transform.position, Vector3.back, out hitinfo, 10f, LayerMask.GetMask("ground")))
        {
            transform.position = new Vector3(transform.position.x, hitinfo.point.y, transform.position.z);//????
            Debug.Log("??");

        }
    }


    public void move()
    {
        if (customize.sceneflag > 1 && moveflag == 1&&jihoonmove==1)
        {
            //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            //if (pos.x < 0f) pos.x = 0f;
            //if (pos.x > 1f) pos.x = 1f;
            //if (pos.y < 0f) pos.y = 0f;
            //if (pos.y > 1f) pos.y = 1f;
            //transform.position = Camera.main.ViewportToWorldPoint(pos);
            //FindGround();

            //player.transform.position = Camera.main.ViewportToWorldPoint(pos); //????




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


        }

    }


    private IEnumerator breathfront()
    {
        while (true)
        {

            coroutineflag = 1;
            if (sitdown == 1)
            {


                spriteRenderer.sprite = basebody[20];


                yield return new WaitForSeconds(0.5f);
                if (sitdown == 1)
                {
                    spriteRenderer.sprite = basebody[21];

                    yield return new WaitForSeconds(0.5f);
                }
            }
            else if (lookaround == 1)
            {


                spriteRenderer.sprite = basebody[16];


                yield return new WaitForSeconds(0.5f);
                if (lookaround == 1)
                {
                    spriteRenderer.sprite = basebody[17];

                    yield return new WaitForSeconds(0.5f);
                }
            }

            else if (shock == 1)
            {


                spriteRenderer.sprite = basebody[18];


                yield return new WaitForSeconds(0.5f);
                if (shock == 1)
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
                if (backflag == 1)
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
        while (true)
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
    private ContactPoint2D contact;
    private Vector2 pos;
    private void OnCollisionEnter2D(Collision2D collision)
    {


        colflag = 1;
        if (customize.sceneflag > 1 && (collision.transform.CompareTag("ground")))
        {
            moveflag = 1;
            Vector2 pos = transform.position;




        }




    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (customize.sceneflag > 1 && (collision.transform.CompareTag("ground")))
        {
            pos = transform.position;


        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (customize.sceneflag > 1 && (collision.transform.CompareTag("ground")))
        {
            moveflag = 0;

            transform.position = pos;



        }
    }












   
}
