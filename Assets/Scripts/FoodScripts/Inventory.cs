using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static event Action<List<InventoryItem>> OnInventoryChange; 

    public List<InventoryItem> inventory = new List<InventoryItem>();
    //TODO: uncomment this if we want stackable items:
    //private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

    private void Start()
    {
        OnInventoryChange?.Invoke(inventory);
    }

    private void OnEnable()
    {
        DragAndDrop.OnFoodCollected += Add;
    }

    private void OnDisable()
    {
        DragAndDrop.OnFoodCollected -= Add;
    }

    public void Add(ItemData itemData)
    {
        // if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        // {
        //     item.AddToStack();
        //     OnInventoryChange?.Invoke(inventory);
        // }
        //TODO: Make beneath into an else

        InventoryItem newItem = new InventoryItem(itemData);
        inventory.Add(newItem);
        Debug.Log("Added " + itemData.displayName + " to inventory");
        OnInventoryChange?.Invoke(inventory);
        //itemDictionary.Add(itemData, newItem);
    }

    public void Remove(ItemData itemData)
    {
        // if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        // {
        //     item.RemoveFromStack();
        //     if (item.stackSize == 0)
        //     {
        //         inventory.Remove(item);
        //         itemDictionary.Remove(itemData);
        //         OnInventoryChange?.Invoke(inventory);
        //     }
        // }
    }
}
