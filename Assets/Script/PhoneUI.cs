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




    private bool phone_onoff;
    private bool isTabPressed;


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
        string clickIcon = GetButtonName();
        if(clickIcon!="CallButton" && clickIcon!="MessageButton")
            ui_Phone.transform.position -= new Vector3(35, 0, 0);

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

    public void OnClickOff()
    {
        ui_Phone.transform.position += new Vector3(35, 0, 0);
        switch (GetButtonName())
        {
            case "OffTwitter":
                ui_TwitterView.SetActive(false);
                break;
            case "OffWiki":
                ui_WikiView.SetActive(false);
                break;
            case "OffTodo":
                ui_TodoView.SetActive(false);
                break;
            case "OffGallery":
                ui_GalleryView.SetActive(false);
                break;
        }

    }

    public string GetButtonName()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        return ButtonName;

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
        }
    }

   
}
