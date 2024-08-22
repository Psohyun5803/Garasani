using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    public GameObject inventoryWindow;
    //public GameObject slot;
    //public GameObject selected;
    //public GameObject status;

    public bool isEPressed = false;

    void Start()
    {
        inventoryWindow.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isEPressed)
            {
                inventoryWindow.SetActive(false);
            }
            else
            {
                inventoryWindow.SetActive(true);
            }
            
            isEPressed = !isEPressed;
        }
    }
}
