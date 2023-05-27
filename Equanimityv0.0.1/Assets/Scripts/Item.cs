using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    protected int level;

    public Item()
    {
        level = 1;
    }

    public int GetLevel()
    {
        return level;
    }

    public void LevelUp()
    {
        level++;
    }
}
