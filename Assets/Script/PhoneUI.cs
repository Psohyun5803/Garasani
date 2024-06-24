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
        ui_Phone.transform.position -= new Vector3(35, 0, 0);
        switch (GetButtonName())
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

    public void OnClickkCall()
    {
        Debug.Log("Call not Available");
    }

    public void OnClickMessage()
    {
        Debug.Log("Message not Available");
    }
   
    // Start is called before the first frame update
    void Start()
    {
        ui_Phone.SetActive(false);
        ui_GalleryView.SetActive(false);
        ui_TodoView.SetActive(false);
        ui_TwitterView.SetActive(false);
        ui_WikiView.SetActive(false);
        phone_onoff = false;
        isTabPressed = false;
    }

    // Update is called once per frame
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
    }

   
}
