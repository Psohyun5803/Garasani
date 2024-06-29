using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    SpriteRenderer rend;

    public Sprite spriteRight;
    public Sprite spriteLeft;
    public Sprite spriteFront;
    public Sprite spriteBack;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rend.sprite = spriteRight;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rend.sprite = spriteLeft;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rend.sprite = spriteBack;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rend.sprite = spriteFront;
        }
    }
}
