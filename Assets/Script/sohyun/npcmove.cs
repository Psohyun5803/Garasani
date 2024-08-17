using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcmove : MonoBehaviour
{
    public Sprite[] bodymove;
    SpriteRenderer spriteRenderer;
    private IEnumerator moveroutine;
    private IEnumerator translateroutine;
    int frontflag = 1;
    public static int moveflag = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bodymove[0];
        moveroutine = moveupdown();
        translateroutine = translate();
        StartCoroutine(translateroutine);
        StartCoroutine(moveroutine);
    }

    // Update is called once per frame
    void Update()

    {  
        if(moveflag==1)
        {
            if (frontflag == 1)
            {
                transform.position = new Vector3(transform.position.x,
                              transform.position.y + 0.05f, 0);
            }
            else
            {
                transform.position = new Vector3(transform.position.x,
                              transform.position.y - 0.05f, 0);
            }
        }
   
        
    }

    private IEnumerator moveupdown()
    {
        while (true)
        {
            if (frontflag!=1&&moveflag==1)
            {
                yield return new WaitForSeconds(0.5f);

                spriteRenderer.sprite = bodymove[2];

                yield return new WaitForSeconds(0.5f);
                spriteRenderer.sprite = bodymove[3];
            }
            else if(frontflag==1&&moveflag==1)
            {
                yield return new WaitForSeconds(0.5f);

                spriteRenderer.sprite = bodymove[1];

                yield return new WaitForSeconds(0.5f);
                spriteRenderer.sprite = bodymove[0];
            }
           

        }
    }
    private IEnumerator translate()
    {
        while(true)
        {

            yield return new WaitForSeconds(1f);

           
            frontflag = 0;
            yield return new WaitForSeconds(1f);
            frontflag = 1;
           
        }
    }
}
