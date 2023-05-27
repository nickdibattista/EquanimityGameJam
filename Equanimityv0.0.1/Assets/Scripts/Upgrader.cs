using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrader
{
    protected Item item;

    public Upgrader(Item item)
    {
        this.item = item;
    }

    public void SwapItem(Item newItem)
    {
        UpgradeItem();
        item = newItem;
    }

    private void UpgradeItem()
    {
        item.LevelUp();
    }
}
