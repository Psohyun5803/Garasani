using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public GameObject Player;
    public GameObject eye1;
    public GameObject eye2;
    public GameObject eye3;
    public GameObject eye4;
    public GameObject eye5;

    public GameObject hair1;
    public GameObject hair2;
    public GameObject hair3;
    public GameObject hair4;
    public GameObject hair5;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
       
        if (customize.sceneflag >= 1)
        {
            Player.SetActive(true);
            puton();
        }

    }

    // Update is called once per frame
    void Update()
    {

        

    }

    public void eyeoff()
    {
        eye1.SetActive(false);
        eye2.SetActive(false);
        eye3.SetActive(false);
        eye4.SetActive(false);
        eye5.SetActive(false);
    }
    public void hairoff()
    {
        hair1.SetActive(false);
        hair2.SetActive(false);
        hair3.SetActive(false);
        hair4.SetActive(false);
        hair5.SetActive(false);
    }

    public void puton() // 커스텀된 eye와 hair를 착용할 수 있게 하는 함수입니다.
    {
        switch (customize.eyenum)
        {
            case 0:
                {
                  
                    eye1.SetActive(true);
                    eye2.SetActive(false);
                    eye3.SetActive(false);
                    eye4.SetActive(false);
                    eye5.SetActive(false);
                   
                    break;
                }
            case 1:
                {
                    eye1.SetActive(false);
                    eye2.SetActive(true);
                    eye3.SetActive(false);
                    eye4.SetActive(false);
                    eye5.SetActive(false);

                    break;
                }
            case 2:
                {
                    eye1.SetActive(false);
                    eye2.SetActive(false);
                    eye3.SetActive(true);
                    eye4.SetActive(false);
                    eye5.SetActive(false);

                    break;
                }
            case 3:
                {
                    eye1.SetActive(false);
                    eye2.SetActive(false);
                    eye3.SetActive(false);
                    eye4.SetActive(true);
                    eye5.SetActive(false);
                    
                  
                    break;
                }
            case 4:
                {
                    eye1.SetActive(false);
                    eye2.SetActive(false);
                    eye3.SetActive(false);
                    eye4.SetActive(false);
                    eye5.SetActive(true);

                    break;
                }
            default:
                
                break;



        }
        switch (customize.hairnum)
        {
            case 0:
                {
                    hair1.SetActive(true);
                    hair2.SetActive(false);
                    hair3.SetActive(false);
                    hair4.SetActive(false);
                    hair5.SetActive(false);
                  
                   

                    break;
                }
            case 1:
                {
                    hair1.SetActive(false);
                    hair2.SetActive(true);
                    hair3.SetActive(false);
                    hair4.SetActive(false);
                    hair5.SetActive(false);

                 
                   
                    break;
                }
            case 2:
                {
                    hair1.SetActive(false);
                    hair2.SetActive(false);
                    hair3.SetActive(true);
                    hair4.SetActive(false);
                    hair5.SetActive(false);
                 
                    
                    break;
                }
            case 3:
                {
                    hair1.SetActive(false);
                    hair2.SetActive(false);
                    hair3.SetActive(false);
                    hair4.SetActive(true);
                    hair5.SetActive(false);


                    break;
                }
            case 4:
                {

                    hair1.SetActive(false);
                    hair2.SetActive(false);
                    hair3.SetActive(false);
                    hair4.SetActive(false);
                    hair5.SetActive(true);

                    break;
                }
            default:
                break;



        }

    }
}
