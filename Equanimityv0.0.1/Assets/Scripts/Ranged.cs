using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Weapon
{
    protected float radius;
    public Ranged(int baseDamage, int baseRange, int baseCooldown, float radius) : base(baseDamage, baseRange, baseCooldown, 0)
    {
        this.radius = radius;
    }

    public float GetRadius()
    {
        return radius;
    }
}
