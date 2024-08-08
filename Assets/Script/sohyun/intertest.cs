using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intertest: MonoBehaviour
{
    private RectTransform interactionViewRectTransform;
    public GameObject InteractionView;
    private bool isMouseOver = false; //현재 오브젝트 위에 커서가 있는지에 대한 플래그
    public Vector3 mousePosition; //마우스 커서 좌표
    public Vector3 worldPosition; //마우스 커서 월드좌표
    public static int playercol = 0;
    public static string colitemname;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("아이템 충돌 감지");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "basebody"|| collision.gameObject.name=="Player")
        {
            playercol = 1;
            colitemname = gameObject.name;
            Debug.Log(colitemname);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basebody" || collision.gameObject.name == "Player")
        {
            playercol = 1;
            colitemname = gameObject.name;
            Debug.Log(colitemname);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("아이템 충돌 감지");
        colitemname = null;
        if (collision.gameObject.name == "basebody"|| collision.gameObject.name=="Player")
        {
            playercol = 0;
        }
    }

    
    private void OnMouseOver() //아이템 위에 커서 있는 것 감지 
    {
        if (!isMouseOver) //커서가 오브젝트 위에 올라갔을 때 최초 1번만 실행
        {
            isMouseOver = true;
            string objectName = gameObject.name; //커서 감지한 오브젝트 name 
            Debug.Log("마우스 감지" + objectName);

            Vector3 mousePosition = Input.mousePosition; //커서 좌표 가져옴 
            //worldPosition = Camera.main.ScreenToWorldPoint(mousePosition); //커서좌표 월드좌표로 변환
            worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
            if(playercol==1)
            {
                Debug.Log("실행");
                ActiveInteraction();
            }
           //상태창 on
        }

    }
    void OnMouseExit()
    {
        // 마우스가 오브젝트에서 벗어났을 때 플래그를 리셋
        isMouseOver = false;
        InteractionView.SetActive(false);
       
    }



    public void ActiveInteraction()
    {
        //InteractionView.transform.position = (worldPosition); //오브젝트 커서 위치로 상태창 이동 
        InteractionView.SetActive(true); //커서 감지 시 상태창 on
    }

    void Start()
    {
        interactionViewRectTransform = InteractionView.GetComponent<RectTransform>();
        InteractionView.SetActive(false);
    }

    void Update()
    {
        
    }

}
