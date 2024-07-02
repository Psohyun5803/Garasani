using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) //플레이어 충돌 감지 
    {
        Debug.Log("플레이어 충돌 감지");
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
