using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    protected int level;
    protected bool inUpgrader;

    public Item()
    {
        level = 1;
        inUpgrader = false;
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
}
