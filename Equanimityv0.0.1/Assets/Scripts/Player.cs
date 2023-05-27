using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    protected Item[] items;
    public Player() : base(100, 10, 10)
    {
        items = new Item[2];
    }

    public void SetItems(Item[] newItems)
    {
        items = newItems;
    }

    public Item[] GetItems()
    {
        return items;
    }

    public Item SwapItems(Item swapIn, Item swapOut)
    {
        int index = Array.IndexOf(items, swapOut);
        items[index] = swapIn;
        return swapOut;
    }

}
