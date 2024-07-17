using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetAsFirst : MonoBehaviour
{


    public RectTransform panelRectTransform;

    //Invoked when the mouse pointer goes down on a UI element.
    public void OnPointerDown(PointerEventData data)
    {
        // Puts the panel to the back as it is now the first UI element to be drawn.
        panelRectTransform.SetAsFirstSibling();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
