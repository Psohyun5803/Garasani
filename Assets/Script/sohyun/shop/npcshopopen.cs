using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcshopopen : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public GameObject ShopUI;
    public static int sellflag = 0;
    public static bool jobcouflag = false;//코루틴 중복방지
    public static bool grandcouflag = false;//코루틴 중복방지
    public static bool angcouflag = false;//코루틴 중복방지
    bool coufirst = true;
    public static string nowinter;

    // Start is called before the first frame update
    void Start()
    {
      
        ShopUI.SetActive(false);
    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        nowinter = gameObject.name;
       
        ShopUI.SetActive(true);

        if (SellManager.instance != null)
        {
            SellManager.instance.putinlist(Items);
        }
        else
        {
            Debug.LogError("SellManager 인스턴스를 찾을 수 없습니다.");
        }


    }
    void Update()
    {
      
        if (SellManager.instance != null && SellManager.instance.sellitem)
        {
            sellflag = 1;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && sellflag == 1)
        {
            if (coufirst == true)
            {
                coufirst = false;

                // NPCManager.instance가 null인지 확인

                if (nowinter == "잡상인")
                {
                    jobcouflag = true;
                }
                else if (nowinter == "음식 파는 할머니")
                {
                    grandcouflag = true;
                }
                else if (nowinter == "앵벌이")
                {
                    angcouflag = true;
                }

            }
        }

        // ESC 키 입력 처리
        if (Input.GetKeyDown(KeyCode.Escape) && sellflag != 1)
        {
            sellflag = 2;

            if (coufirst == true)
            {
                coufirst = false;

            }
            else if (nowinter == "잡상인")
            {
                jobcouflag = true;
            }
            else if (nowinter == "앵벌이")
            {
                angcouflag = true;
            }


            }
        }


    }

