using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingUIController : MonoBehaviour
{
    public GameObject SettingUI;
    void Start()
    {
        SettingUI.SetActive(false);
    }

    public void ActivateUI()
    {
        SettingUI.SetActive(true);
    }

    public void DeactivateUI()
    {
        SettingUI.SetActive(false);
    }
}
