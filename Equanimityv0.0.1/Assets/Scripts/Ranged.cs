using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Weapon
{
    protected int radius;
    public Ranged(int radius) : base(10, 10)
    {
        this.radius = radius;
    }

    public int GetRadius()
    {
        return radius;
    }
}
