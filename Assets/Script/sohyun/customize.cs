using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Net.Mail;
using TMPro;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System;


public class customize : MonoBehaviour
{
    //?????? ?????????????? ????
    public GameObject Player_front;

    public GameObject eye1;
    public GameObject eye2;
    public GameObject eye3;
    public GameObject eye4;
    public GameObject eye5;

  /*  public GameObject eye1_1;
    public GameObject eye2_1;
    public GameObject eye3_1;
    public GameObject eye4_1;
    public GameObject eye5_1;
  */
    public GameObject mineye1;
    public GameObject mineye2;
    public GameObject mineye3;
    public GameObject mineye4;
    public GameObject mineye5;



    public GameObject eye1_left;
    public GameObject eye2_left;
    public GameObject eye3_left;
    public GameObject eye4_left;
    public GameObject eye5_left;

    public GameObject eye1_right;
    public GameObject eye2_right;
    public GameObject eye3_right;
    public GameObject eye4_right;
    public GameObject eye5_right;

    public GameObject hair1;
    public GameObject hair2;
    public GameObject hair3;
    public GameObject hair4;
    public GameObject hair5;

   /* public GameObject hair1_1;
    public GameObject hair2_1;
    public GameObject hair3_1;
    public GameObject hair4_1;
    public GameObject hair5_1;*/

    public GameObject minhair1;
    public GameObject minhair2;
    public GameObject minhair3;
    public GameObject minhair4;
    public GameObject minhair5;

    public GameObject hair1_left;
    public GameObject hair2_left;
    public GameObject hair3_left;
    public GameObject hair4_left;
    public GameObject hair5_left;

    public GameObject hair1_right;
    public GameObject hair2_right;
    public GameObject hair3_right;
    public GameObject hair4_right;
    public GameObject hair5_right;

    public GameObject hair1_back;
    public GameObject hair2_back;
    public GameObject hair3_back;
    public GameObject hair4_back;
    public GameObject hair5_back;

    public GameObject hood_front;
   //public GameObject hood_front_1;
    public GameObject hood_left;
    public GameObject hood_right;
    public GameObject hood_back;

    public GameObject img1;
    public GameObject img2;



    public GameObject eyeleft;
    public GameObject eyeright;
    public GameObject hairright;
    public GameObject hairleft;
    //public GameObject Player_front1;
    public GameObject Player_left;
    public GameObject Player_right;
    public GameObject Player_back;
    public GameObject eyeclose;
    //public GameObject Player;//????
    public TMP_Text hairtxt;
    public TMP_Text eyetxt;
    public GameObject[] Playermotion;
    public static int eyenum = 0; //?????? ???????? ???????? ??????????
    public static int hairnum = 0; //?????? ?????????? ???????? ??????????
    public static int sceneflag = 0; //?????????? ???????????? ???????? ????????????!

    string[] hair = new string[5] { "  헤어01", "  헤어02", "  헤어03", "  헤어04", "  헤어05" }; 
    string[] eye = new string[5] { "  눈01", "  눈02", "  눈03", "  눈04", "  눈05" };
    [SerializeField] private float Speed;
    public static Action eyec;
    public static Action eyeo;
    public static Action<float,float> playertrans;
    public static int moveflag = 1;
    // Start is called before the first frame update
    
   
    public TMP_Text playernameinput;
    public TMP_Text playerbirthinput;
    public GameObject birthwrong;
    public GameObject mingroup;
    public static string playername ;
    public static string playerbirth;
    //public static string finalplayername;

    //[SerializeField] private InputField usernameinput;
    bool IsValidDate(string date, out DateTime validDate)
    {
        validDate = DateTime.MinValue;
        if (date != null)
        {
           



            int month = int.Parse(date.Substring(0, 2));
            int day = int.Parse(date.Substring(2, 2));
            Debug.Log(month);
            Debug.Log(day);
            try
            {
                // 1997???? ???????? DateTime ????
                validDate = new DateTime(1997, month, day);
                return true; // ?????? ?????? ???? true ????
            }
            catch (ArgumentOutOfRangeException)
            {

                return false;
            }
        }
        
        return false;
           
        

        
    }

    private void Awake()
    {
        eyec = () => { eyeclosefun(); };
        eyeo = () => { puton(); };
        playertrans = (float x, float y) => { playertransform(x,y); };

    }
    private IEnumerator coroutine;
    void Start() //?????????????? ???????? ???? ???????? ????????????
    {
        birthwrong.SetActive(false);
        eyenum = 0; //?????? ???????? ???????? ??????????
        hairnum = 0; //
        Playermotion = new GameObject[4]{Player_front,Player_back,Player_left,Player_right/*Player_front1*/};
        Player_front.SetActive(true); //?????????? ?????? 
        Player_back.SetActive(false);
        Player_left.SetActive(false);
        Player_right.SetActive(false);
        hood_front.SetActive(true); // ?????? ???? 
        hood_left.SetActive(true);
        hood_right.SetActive(true);
        hood_back.SetActive(true);
        eye1.SetActive(true); //???? ?? 1
        hair1.SetActive(true); // ???? ???? 1
                               //coroutine = breathfront();
                               //StartCoroutine(coroutine);
        
       




    }
    public void move() 
    {
        if (sceneflag >1 &&moveflag ==1) //?????????????? ?? ???????? ?????????? ???????????????? ?????? ?? ?????????? .
        {

            float X = Input.GetAxisRaw("Horizontal");
            float Y = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.W))
            {
                playeroff();
                Player_back.SetActive(true);

            }
            if (Input.GetKey(KeyCode.S))
            {
                playeroff();
                Player_front.SetActive(true);

            }
            if (Input.GetKey(KeyCode.A))
            {
                playeroff();
                Player_left.SetActive(true);

            }
            if (Input.GetKey(KeyCode.D))
            {
                playeroff();
                Player_right.SetActive(true);

            }
            for(int i=0; i<5;i++)
            {
                Playermotion[i].transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);
            }
            
            
            
           // Player_back.transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);
            //Player_front.transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);
            //Player_left.transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);
            //Player_right.transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);

            
        }
       /* if (!Input.anyKeyDown)
        {
            if (Player_front.activeSelf == true || Player_front1.activeSelf ==true)
            {
                
            }
           
        } */



    }
   
   // public GameObject Player;
    public void prologue() //?????????????? ?????????? ?????? ?????? ??????????. ?????????? ???????? ?????? ?????????? ???????????? ??????????
    {
        if (IsValidDate(playerbirthinput.text,out DateTime validDate))
        {
           
            img1.SetActive(false);
            img2.SetActive(false);
            mingroup.SetActive(false);
            //sizetransform(Player_front1);
            sizetransform(Player_front);
            sizetransform(Player_back);
            sizetransform(Player_left);
            sizetransform(Player_right);
            //Player.transform.position = new Vector3(1000, 800, 0);
            eyesize();
            hoodsize();
            hairsize();

            Vector3 newPosition = new Vector3(1000, 500, 0);
            //Player_front1.transform.position = newPosition;
            Player_front.transform.position = newPosition;
            Player_back.transform.position = newPosition;
            Player_left.transform.position = newPosition;
            Player_right.transform.position = newPosition;

            sceneflag = 1;
            playername = playernameinput.text;
            playerbirth = playerbirthinput.text;
            eyeclose.SetActive(false);
            SceneManager.LoadScene("prologuebeta");

        }
        else
        {
            //playerbirthinput = null;
            Debug.Log("?????? ????");
            birthwrong.SetActive(true);
        }
       
        
        //Player.transform.position = newPosition; //????
        //SceneManager.LoadScene("prologuebeta");
    }
    public void playertransform(float x, float y)

    {
        Vector3 newPosition = new Vector3(x+192, y+384, 0);

        //Player_front1.transform.position = newPosition;
        Player_front.transform.position = newPosition;
        Player_back.transform.position = newPosition;
        Player_left.transform.position = newPosition;
        Player_right.transform.position = newPosition;
    }
    public void sizetransform(GameObject a) //?????????????? ?????????? ?????? ?????? ?????? ????????????.
    {
        GameObject p = a;
        
        if(sceneflag==0) 
        {
            RectTransform rectTran1 = p.GetComponent<RectTransform>();
            rectTran1.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 75);
            RectTransform rectTran2 = p.GetComponent<RectTransform>();
            rectTran2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 75);
            a.transform.position = new Vector3(1000, 800, 0);
        }
      
       
    }
    public void eyesize() //?????? ?????????? ???? ?? ???????? ??????????
    {
        sizetransform(eye1);
        sizetransform(eye2);
        sizetransform(eye3);
        sizetransform(eye4);
        sizetransform(eye5);

       /* sizetransform(eye1_1);
        sizetransform(eye2_1);
        sizetransform(eye3_1);
        sizetransform(eye4_1);
        sizetransform(eye5_1);*/

        sizetransform(eye1_left);
        sizetransform(eye2_left);
        sizetransform(eye3_left);
        sizetransform(eye4_left);
        sizetransform(eye5_left);

        sizetransform(eye1_right);
        sizetransform(eye2_right);
        sizetransform(eye3_right);
        sizetransform(eye4_right);
        sizetransform(eye5_right);
        sizetransform(eyeclose);



    }
    public void hairsize() //?????? ?????????? ???? ???? ???????? ??????????
    {
        sizetransform(hair1);
        sizetransform(hair2);
        sizetransform(hair3);
        sizetransform(hair4);
        sizetransform(hair5);

       /* sizetransform(hair1_1);
        sizetransform(hair2_1);
        sizetransform(hair3_1);
        sizetransform(hair4_1);
        sizetransform(hair5_1);*/

        sizetransform(hair1_left);
        sizetransform(hair2_left);
        sizetransform(hair3_left);
        sizetransform(hair4_left);
        sizetransform(hair5_left);

        sizetransform(hair1_right);
        sizetransform(hair2_right);
        sizetransform(hair3_right);
        sizetransform(hair4_right);
        sizetransform(hair5_right);

        sizetransform(hair1_back);
        sizetransform(hair2_back);
        sizetransform(hair3_back);
        sizetransform(hair4_back);
        sizetransform(hair5_back);

    }
    public void hoodsize() //?????? ?????????? ???? ?????? ???????? ??????????
    {
       // sizetransform(hood_front_1);
        sizetransform(hood_front);
        sizetransform(hood_back);
        sizetransform(hood_left);
        sizetransform(hood_right);
       
    }
        public void playeroff() // ?????????? ?????????? ???????? ???? ???????????????? ????????????, ???? ?????? ???????? ???????? ?????? ???? ??????????.
    {
        //Player_front1.SetActive(false);
        Player_front.SetActive(false);
        Player_back.SetActive(false);
        Player_left.SetActive(false);
        Player_right.SetActive(false);
    }
 
    public void eyeleftOnclick() //???????? ?????? ????????????.
    {
        eyenum--;
        if (eyenum<0)
        {
            eyenum = 4;
        }
        eyetxt.text = eye[eyenum];

    }
    public void eyerightOnclick()
    {
        eyenum++;
        if (eyenum > 4)
        {
            eyenum = 0;
        }
        eyetxt.text = eye[eyenum];

    }
    public void hairleftOnclick()
    {
        hairnum--;
        if (hairnum < 0)
        {
            hairnum = 4;
        }
        hairtxt.text = hair[hairnum];

    }
    public void hairrightOnclick()
    {
        hairnum++;
        if (hairnum >4)
        {
            hairnum = 0;
        }
        hairtxt.text = hair[hairnum];

    }
    public void eyeoff() //?????? ???? eye?? ????, ?????????? ???????????? ???? ??????????.
    {
        eye1.SetActive(false);
        eye2.SetActive(false);
        eye3.SetActive(false);
        eye4.SetActive(false);
        eye5.SetActive(false);

      /*  eye1_1.SetActive(false);
        eye2_1.SetActive(false);
        eye3_1.SetActive(false);
        eye4_1.SetActive(false);
        eye5_1.SetActive(false);*/

       mineye1.SetActive(false);
        mineye2.SetActive(false);
        mineye3.SetActive(false);
        mineye4.SetActive(false);
        mineye5.SetActive(false);

        eye1_left.SetActive(false);
        eye2_left.SetActive(false);
        eye3_left.SetActive(false);
        eye4_left.SetActive(false);
        eye5_left.SetActive(false);

        eye1_right.SetActive(false);
        eye2_right.SetActive(false);
        eye3_right.SetActive(false);
        eye4_right.SetActive(false);
        eye5_right.SetActive(false);

        eyeclose.SetActive(false);
    }
    public void hairoff() // ???? ??????????
    {
        hair1.SetActive(false);
        hair2.SetActive(false);
        hair3.SetActive(false);
        hair4.SetActive(false);
        hair5.SetActive(false);

      /*  hair1_1.SetActive(false);
        hair2_1.SetActive(false);
        hair3_1.SetActive(false);
        hair4_1.SetActive(false);
        hair5_1.SetActive(false);*/

        minhair1.SetActive(false);
       minhair2.SetActive(false);
        minhair3.SetActive(false);
        minhair4.SetActive(false);
        minhair5.SetActive(false);

        hair1_left.SetActive(false);
        hair2_left.SetActive(false);
        hair3_left.SetActive(false);
        hair4_left.SetActive(false);
        hair5_left.SetActive(false);

        hair1_right.SetActive(false);
        hair2_right.SetActive(false);
        hair3_right.SetActive(false);
        hair4_right.SetActive(false);
        hair5_right.SetActive(false);

        hair1_back.SetActive(false);
        hair2_back.SetActive(false);
        hair3_back.SetActive(false);
        hair4_back.SetActive(false);
        hair5_back.SetActive(false);


    }
    public void eyeclosefun() //???????? ?? ???? ????
    {
        eyeoff();
        eyeclose.SetActive(true);
        Debug.Log("?? ???? ????");
        
    }
    public void puton() // ???????? eye?? hair?? ?????? ?? ???? ???? ??????????.
    {
         switch(eyenum)
        {
            case 0:
                {
                    eyeoff();
                    eye1.SetActive(true);
                    //eye1_1.SetActive(true);
                    eye1_right.SetActive(true);
                    eye1_left.SetActive(true);
                   mineye1.SetActive(true);
                    break;
                }
            case 1:
                {
                    eyeoff();
                    eye2.SetActive(true);
                    //eye2_1.SetActive(true);
                    eye2_right.SetActive(true);
                    eye2_left.SetActive(true);
                    mineye2.SetActive(true);
                    break;
                }
            case 2:
                {
                    eyeoff();
                    eye3.SetActive(true);
                    //eye3_1.SetActive(true);
                    eye3_right.SetActive(true);
                    eye3_left.SetActive(true);
                    mineye3.SetActive(true);
                    break;
                }
            case 3:
                {
                    eyeoff();
                    eye4.SetActive(true);
                    //eye4_1.SetActive(true);
                    eye4_right.SetActive(true);
                    eye4_left.SetActive(true);
                    mineye4.SetActive(true);
                    break;
                }
            case 4:
                {
                    eyeoff();
                    eye5.SetActive(true);
                    //eye5_1.SetActive(true);
                    eye5_right.SetActive(true);
                    eye5_left.SetActive(true);
                    mineye5.SetActive(true);
                    break;
                }
            default:
                break;



        }
        switch (hairnum)
        {
            case 0:
                {
                    hairoff();
                    hair1.SetActive(true);
                    //hair1_1.SetActive(true);
                    minhair1.SetActive(true);
                    hair1_left.SetActive(true);
                    hair1_right.SetActive(true);
                    hair1_back.SetActive(true);

                    break;
                }
            case 1:
                {
                    hairoff();
                   minhair2.SetActive(true);
                    hair2.SetActive(true);
                    //hair2_1.SetActive(true);
                    hair2_left.SetActive(true);
                    hair2_right.SetActive(true);
                    hair2_back.SetActive(true);
                    break;
                }
            case 2:
                {
                    hairoff();
                    hair3.SetActive(true);
                    //hair3_1.SetActive(true);
                    minhair3.SetActive(true);
                    hair3_left.SetActive(true);
                    hair3_right.SetActive(true);
                    hair3_back.SetActive(true);
                    break;
                }
            case 3:
                {
                    hairoff();
                    hair4.SetActive(true);
                   // hair4_1.SetActive(true);
                    minhair4.SetActive(true);
                    hair4_left.SetActive(true);
                    hair4_right.SetActive(true);
                    hair4_back.SetActive(true);
                    break;
                }
            case 4:
                {
                    hairoff();
                    hair5.SetActive(true);
                    //hair5_1.SetActive(true);
                    minhair5.SetActive(true);
                    hair5_left.SetActive(true);
                    hair5_right.SetActive(true);
                    hair5_back.SetActive(true);
                    break;
                }
            default:
                break;



        }

    }
    // Update is called once per frame
    void Update()
    {
        if(sceneflag==0)
        {
            puton();
        }
        
        move(); 

        
    }
      
        
   
}
