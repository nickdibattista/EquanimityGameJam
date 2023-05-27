using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    protected Item[] item;
    public Player() : base(100, 10, 10)
    {
        item = new Item[2];
    }

    public Item[] GetItem()
    {
        return item;
    }

    public Item SwapItems(Item swapIn, Item swapOut)
    {
        int index = Array.IndexOf(item, swapOut);
        item[index] = swapIn;
        return swapOut;
    }

}
