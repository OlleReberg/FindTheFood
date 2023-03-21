using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemData itemData;
    //TODO: add this if we want several of a certain item: public int stackSize;

    public InventoryItem(ItemData item)
    {
        itemData = item;
        //AddToStack();
    }

    //Following two methods if we want stackable items later
    public void AddToStack()
    {
        //stackSize++;
    }
    public void RemoveFromStack()
    {
        //stackSize--;
    }
}
