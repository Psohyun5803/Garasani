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
        //slot.SetActive(false);
        //selected.SetActive(false);
        //status.SetActive(false);
    }

    void Update()
    {
        // E ?? ??? ?
        if (Input.GetKeyDown(KeyCode.E))
        {
            // ???? ?? ????? ??, ????? ??.
            if (isEPressed)
            {
                inventoryWindow.SetActive(false);
                //slot.SetActive(false);
                //selected.SetActive(false);
                //status.SetActive(false);
            }
            else
            {
                inventoryWindow.SetActive(true);
                //slot.SetActive(true);
                //selected.SetActive(true);
                //status.SetActive(true);
            }

            // ??? ?? ?????.
            isEPressed = !isEPressed;
        }
    }
}
