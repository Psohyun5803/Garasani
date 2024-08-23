using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantityAssign : MonoBehaviour
{
    public GameObject[] itemSlots;

    void Start()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("quantity"); // or Find with Name
        itemSlots = new GameObject[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            itemSlots[i] = items[i];
        }
    }
}
