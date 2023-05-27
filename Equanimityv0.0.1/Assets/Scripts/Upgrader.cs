using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader
{
    protected Item item;

    public Upgrader()
    {

    }

    public Item SwapItem(Item newItem)
    {
        UpgradeItem();

        Item oldItem = item;
        item = newItem;

        oldItem.SetInUpgrader(false);
        newItem.SetInUpgrader(true);

        return oldItem;
    }

    private void UpgradeItem()
    {
        item.LevelUp();
    }

    public void InsertItem(Item newItem)
    {
        item = newItem;
        item.SetInUpgrader(true);
    }

    public Item GetItem()
    {
        return item;
    }

    public bool HasItem()
    {
        return item != null;
    }
}
