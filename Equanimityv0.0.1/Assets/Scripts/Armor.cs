using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    // 0 - 1. Percentage of damage taken.
    protected float damageCoef;
    protected float weight;

    public Armor(float damageCoef, float weight) : base()
    {
        this.damageCoef = damageCoef;
        this.weight = weight;
    }

    public int GetDamage(int baseDamage)
    {
        int totalDamage = Mathf.FloorToInt(baseDamage * damageCoef);
        return totalDamage;
    }

    public float GetWeight()
    {
        return weight;
    }
}
