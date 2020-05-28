using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCounter : MonoBehaviour
{
    // StoreCounterItems is just simple gameobject that will hold items once they
    // have been added to the counter. It is separate of the StoreCounter gameobject
    // so as not to affect the scale of objects when they are instantiated
    public GameObject storeCounterItems;
    public int maxCounterItems;
    public Transform[] positions;
    private Dictionary<Vector3, Item> itemsMappedByPosition = new Dictionary<Vector3, Item>();


    public void AddItem(Item item)
    {
        if (itemsMappedByPosition.Count == maxCounterItems)
            return;

        foreach (Transform position in positions)
        {
            if (!itemsMappedByPosition.ContainsKey(position.position))
            {
                itemsMappedByPosition.Add(position.position, item);
                Item itemCopy = Instantiate(item, storeCounterItems.transform);
                Transform bottomPosition = itemCopy.transform.Find("BottomPosition");
                Vector3 offset = itemCopy.transform.position - bottomPosition.transform.position;
                itemCopy.transform.position = position.position + offset;
                return;
            }
        }
    }

    public void RemoveItem(Item item)
    {
        if (itemsMappedByPosition.Count == 0)
            return;

        Transform bottomPosition = item.transform.Find("BottomPosition");

        if (itemsMappedByPosition.ContainsKey(bottomPosition.position))
        {
            itemsMappedByPosition.Remove(bottomPosition.position);
            Destroy(item.gameObject);
        } 
    }

    public Dictionary<Item, int> GetDistinctItemCounts()
    {
        Dictionary<Item, int> itemCounts = new Dictionary<Item, int>();

        foreach (Item item in itemsMappedByPosition.Values)
        {
            if (itemCounts.ContainsKey(item))
                itemCounts[item]++;
            else
                itemCounts[item] = 1;
        }

        return itemCounts;
    }

    public decimal GetTotal()
    {
        decimal total = 0;

        foreach (Item item in itemsMappedByPosition.Values)
        {
            total += System.Convert.ToDecimal(item.price);
        }

        Debug.Log(total);
        return total;
    }

    // For testing methods
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Button"))
        {
            print("You clicked the button!");
            GetTotal();
        }
    }
}
