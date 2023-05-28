using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Entity
{
    protected List<Item> items;
    protected int maxHealth = 100;
    public Player() : base(100, 10, 10)
    {
        items = new List<Item>();
    }

    public void SetItems(List<Item> newItems)
    {
        items = newItems;
        Debug.Log(items);
    }

    public List<Item> GetItems()
    {
        return items;
    }

    /*public Item SwapItems(Item swapIn, Item swapOut)
    {
        int index = Array.IndexOf(items, swapOut);
        items[index] = swapIn;
        return swapOut;
    }*/

    public int getHealth()
    {
        return health;
    }

    public override int TakeDamage(int damage)
    {
        //todo add armor to mitigate damage taken
        float finalDamage = damage;
        foreach (Item item in items)
        {
            if (item is Armor)
            {
                if (item.IsEquipped())
                {
                    finalDamage = (item as Armor).GetDamage(damage);
                }
            }
        }
        health -= (int)finalDamage;

        Debug.Log(finalDamage);

        return health;
    }


}
