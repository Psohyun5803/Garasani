using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject ui_Phone;

    public void checkPhone()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            ui_Phone.SetActive(true);
        }
    }

    public void OnClickWiki()
    {

    }

    public void OnClickTwitter()
    {

    }

    public void OnClickGallery()
    {

    }

    public void OnClickTodo()
    {

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
    }

    // Update is called once per frame
    void Update()
    {
        checkPhone();
    }
}
