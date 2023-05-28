using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    protected int level;
    protected bool inUpgrader;
    protected bool equipped;

    public Item()
    {
        level = 1;
        inUpgrader = false;
        equipped = true;
    }

    public int GetLevel()
    {
        return level;
    }

    public void LevelUp()
    {
        level++;
    }

    public void SetInUpgrader(bool inUpgrader)
    {
        this.inUpgrader = inUpgrader;
    }

    public bool InUpgrader()
    {
        return inUpgrader;
    }

    public void SetEquipped(bool equipped)
    {
        this.equipped = equipped;
    }

    public bool IsEquipped()
    {
        return equipped;
    }
}
