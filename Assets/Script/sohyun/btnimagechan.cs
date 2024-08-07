using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnimagechan : MonoBehaviour
{

    public Sprite[] btnimg;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = btnimg[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onclickbtn()
    {
        spriteRenderer.sprite = btnimg[1];
    }
}
