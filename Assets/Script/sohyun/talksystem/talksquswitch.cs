using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class talksquswitch : MonoBehaviour
{
    public TMP_Text who;
    public bool isfliped = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject whoobj = GameObject.Find("이름");
        who = whoobj.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(who.text==customize.playername)
        {
            if(isfliped==false)
            {
                flip();
            }
          
        }
        else
        {
            if(isfliped==true)
            {
                flip();
                isfliped = false;
            }
        }
    }
    public void flip()
    {
        isfliped = true;
        Vector3 parentScale = transform.localScale;
        parentScale.x *= -1;
        transform.localScale = parentScale;

       
        foreach (Transform child in transform)
        {
          
            Vector3 childPosition = child.localPosition;
            childPosition.x *= -1;
            child.localPosition = childPosition; // 원래대로 유지
            Vector3 childScale = child.localScale;
            childScale.x *= -1;
            child.localScale = childScale;

            /*if (child.name =="이름")
            {
                Vector3 childScale = child.localScale;
                childScale.x *= -1;
                child.localScale = childScale;
            }*/

        }
    }
}
