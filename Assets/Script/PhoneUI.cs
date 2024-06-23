using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void OffPhone()
    {
        ui_Phone.SetActive(false);
    }

    public void OnClickWiki()
    {
        ui_WikiView.SetActive(true);
    }

    public void OffWiki()
    {
        ui_WikiView.SetActive(false);
    }

    public void OnClickTwitter()
    {
        ui_TwitterView.SetActive(true);
    }

    public void OffTwittwer()
    {
        ui_TwitterView.SetActive(false);
    }

    public void OnClickGallery()
    {
        ui_GalleryView.SetActive(true);
    }

    public void OffGallery()
    {
        ui_GalleryView.SetActive(false);
    }


    public void OnClickTodo()
    {
        ui_TodoView.SetActive(true);
    }

    public void OffTodo()
    {
        ui_TodoView.SetActive(false);
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
