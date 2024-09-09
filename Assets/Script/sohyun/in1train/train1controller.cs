using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class train1controller : MonoBehaviour
{
    public static int gotoflag = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name=="1호선내부1"&&gotoflag==2)
        {
            Debug.Log("실행됨");
            GameObject door1 = GameObject.Find("1호선문1");
            Vector2 door1position = new Vector2(door1.transform.position.x, door1.transform.position.y);
            Player.playertrans(door1position.x-3, door1position.y);
            gotoflag = 0; //이동 후 초기화


        }
        if (SceneManager.GetActiveScene().name == "1호선내부2"&&gotoflag==1)
        {
            GameObject door2 = GameObject.Find("1호선문2");
            Vector2 door2position = new Vector2(door2.transform.position.x, door2.transform.position.y);
            Player.playertrans(door2position.x+3, door2position.y);
            gotoflag = 0;  //이동 후 초기화
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Player")
        {
            if (gameObject.name == "1호선문1")
            {
                gotoflag = 1; //내부1에서 내부2로 갈 때
                SceneManager.LoadScene("1호선내부2");

            }
            if (gameObject.name == "1호선문2")
            {
                gotoflag = 2; //내부2에서 내부1로 갈 때
                SceneManager.LoadScene("1호선내부1");

            }
        }
       



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
