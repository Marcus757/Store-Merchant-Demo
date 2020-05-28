using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float price;
    private StoreCounter storeCounter;

    void Start()
    {
        storeCounter = GameObject.Find("StoreCounter").GetComponent<StoreCounter>(); ;
    }

    public void OnMouseDown()
    {
        if (!gameObject.GetComponentInParent(typeof(StoreCounter)))
            storeCounter.AddItem(this);
        else
            storeCounter.RemoveItem(this);
    }
}
