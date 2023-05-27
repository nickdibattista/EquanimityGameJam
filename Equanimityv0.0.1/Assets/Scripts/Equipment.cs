using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    protected int level;

    public Equipment()
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
