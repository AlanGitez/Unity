using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] private Item[] items;
    private Dictionary<string, Item> idToItem;
    
    
    private void Start()
    {
        idToItem = new Dictionary<string, Item>();

    }

    private void SearchingItems()
    {
        foreach (var item in items)
        {
            idToItem.Add(item.Id, item);
        }
    }
}
