using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{

    public GameObject ui_Phone;
    public GameObject ui_WikiView;
    public GameObject ui_TwitterView;
    public GameObject ui_GalleryView;
    public GameObject ui_TodoView;
    public GameObject ui_CallMessageView;

    public GameObject Wiki_Button;
    public GameObject Twitter_Button;
    public GameObject Gallery_Button;
    public GameObject Todo_Button;
    public GameObject Call_Button;
    public GameObject Message_Button;
    public GameObject Setting_Button;

    public GameObject[] viewList = new GameObject[4];


    private bool phone_onoff;
    private bool isTabPressed;
    private bool isViewOn = false;



    public void checkPhone()
    {
        if (phone_onoff == false)
        {
            ui_Phone.SetActive(true);
            phone_onoff = true;
            Debug.Log("phone on: " + phone_onoff.ToString());

        }
        else
        {
            ui_Phone.SetActive(false);
            phone_onoff = false;
            Debug.Log("phone off: " + phone_onoff.ToString());

        }
    }

    public void OnClickIcon()
    {
        while (!isViewOn)
        {
            string clickIcon = GetButtonName();
            if (clickIcon != "CallButton" && clickIcon != "MessageButton")
                ui_Phone.transform.position -= new Vector3(40, 0, 0);

            isViewOn = true;
            switch (clickIcon)
            {
                case "TwitterButton":
                    ui_TwitterView.SetActive(true);
                    break;
                case "WikiButton":
                    ui_WikiView.SetActive(true);
                    break;
                case "TodoButton":
                    ui_TodoView.SetActive(true);
                    break;
                case "GalleryButton":
                    ui_GalleryView.SetActive(true);
                    break;
                case "CallButton":
                case "MessageButton":
                    ui_CallMessageView.SetActive(true);
                    break;
                case "SettingButton":
                    OnClickSetting();
                    break;
            }
        }
        
    }

    public void OnClickOff()
    {
        ui_Phone.transform.position += new Vector3(40, 0, 0);
        isViewOn = false;
        Debug.Log("view off" + isViewOn.ToString());

        string clickIcon = GetButtonName();
        Debug.Log("Button name: " + GetButtonName());

        switch (clickIcon)
        {
            case "OffTwitter":
                ui_TwitterView.SetActive(false);
                Debug.Log("twitter off");
                break;
            case "OffWiki":
                ui_WikiView.SetActive(false);
                Debug.Log("wiki off");
                break;
            case "OffTodo":
                ui_TodoView.SetActive(false);
                Debug.Log("todo off");
                break;
            case "OffGallery":
                ui_GalleryView.SetActive(false);
                Debug.Log("gallery off");
                break;
            default:
                Debug.LogWarning("Unknown button name: " + clickIcon);
                break;

        }

    }

    public void OnClickPre()
    {
        string clickIcon = GetParentName();
        Debug.Log(clickIcon.ToString());
        Debug.Log("Pre 실행중");

        int nowView = -1;
        for(int i = 0; i < viewList.Length; i++)
        {
            if (viewList[i].name.Equals(clickIcon))
            {
                nowView = i;
                break;
            }
        }

        if (nowView > 0)
        {
            int preView = nowView - 1;
            Debug.Log($"Changing from {nowView} to {preView}");
            if (viewList[nowView] != null && viewList[preView] != null)
            {
                viewList[nowView].SetActive(false);
                viewList[preView].SetActive(true);
            }
        }


    }

    public void OnClickNext()
    {
        string clickIcon = GetParentName();
        int nowView = -1;
        Debug.Log("Next 실행중");
        Debug.Log(clickIcon);
        for (int i = 0; i < viewList.Length; i++)
        {
            if (viewList[i].name.Equals(clickIcon))
            {
                nowView = i;
                Debug.Log(nowView);
                break;
            }
        }

        if (nowView >= 0 && nowView < viewList.Length - 1)
        {
            int nextView = nowView + 1;
            Debug.Log(nextView);
            if(viewList[nowView] != null && viewList[nextView] != null)
            {
                viewList[nowView].SetActive(false);
                viewList[nextView].SetActive(true);
            }
            
        }
    }
    public string GetButtonName()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        return ButtonName;

    }

    public string GetParentName()
    {
        GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
        string parentName = clickedObject.transform.parent.name;

        return parentName;

    }

    public void OnClickSetting()
    {
        Wiki_Button.SetActive(false);
        Message_Button.SetActive(false);
        Call_Button.SetActive(false);
        Todo_Button.SetActive(false);
        Gallery_Button.SetActive(false);
        Twitter_Button.SetActive(false);
        Setting_Button.SetActive(false);

    }
   

    void Start()
    {
        ui_Phone.SetActive(false);
        ui_GalleryView.SetActive(false);
        ui_TodoView.SetActive(false);
        ui_TwitterView.SetActive(false);
        ui_WikiView.SetActive(false);
        ui_CallMessageView.SetActive(false);
        phone_onoff = false;
        isTabPressed = false;

        Wiki_Button.SetActive(true);
        Message_Button.SetActive(true);
        Call_Button.SetActive(true);
        Todo_Button.SetActive(true);
        Gallery_Button.SetActive(true);
        Twitter_Button.SetActive(true);
        Setting_Button.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isTabPressed)
        {
            checkPhone();
            isTabPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            isTabPressed = false;
        }

        if(ui_CallMessageView.activeSelf && Input.GetMouseButtonDown(0))
        {
            ui_CallMessageView.SetActive(false);
            isViewOn = false;
        }
    }

   
}
