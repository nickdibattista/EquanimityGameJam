using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Weapon
{
    protected int radius;
    public Ranged(int baseDamage, int baseRange, int baseCooldown, int radius) : base(baseDamage, baseRange, baseCooldown)
    {
        this.radius = radius;
    }

    public int GetRadius()
    {
        return radius;
    }
}
