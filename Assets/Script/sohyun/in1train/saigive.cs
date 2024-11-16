using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saigive : MonoBehaviour
{
    int given = 0;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NPCManager.saiitem==1&&given==0)
        {
            given = 1;
            InventoryManager.instance.AddItemToSlot(item);
        }
    }
}
