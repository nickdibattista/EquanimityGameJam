using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    protected int baseRange, baseDamage;
    protected float baseCooldown, baseKnockback;
    
    public Weapon(int baseDamage, int baseRange, float baseCooldown, float baseKnockback) : base ()
    {
        this.baseDamage = baseDamage;
        this.baseRange = baseRange;
        this.baseCooldown = baseCooldown;
        this.baseKnockback = baseKnockback;
    }

    public int GetRange()
    {
        int totalRange = baseRange * level;
        return totalRange;
    }
    public float GetCooldown()
    {
        float totalCooldown = baseCooldown / level;
        return totalCooldown;
    }

    public int GetDamage()
    {
        int totalDamage = baseDamage * level;
        return totalDamage;
    }

    public float GetKnockback()
    {
        float totalKnockback = baseKnockback * level;
        return totalKnockback;
    }



}
