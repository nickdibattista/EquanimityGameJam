using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    protected int baseRange, baseCooldown, baseDamage;
    public Weapon(int baseRange, int baseCooldown) : base ()
    {
        this.baseRange = baseRange;
        this.baseCooldown = baseCooldown;
    }

    public int GetRange()
    {
        int totalRange = baseRange * level;
        return totalRange;
    }
    public int GetCooldown()
    {
        int totalCooldown = baseCooldown / level;
        return totalCooldown;
    }

    public int GetDamage()
    {
        int totalDamage = baseDamage * level;
        return GetDamage();
    }

}
