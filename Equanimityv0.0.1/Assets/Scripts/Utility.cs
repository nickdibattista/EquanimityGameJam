using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : Weapon
{
    protected int radius;
    public Utility(int radius) : base(10, 10)
    {
        this.radius = radius;
    }

    public int GetRadius()
    {
        return radius;
    }
}
