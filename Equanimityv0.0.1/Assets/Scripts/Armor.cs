using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    // 0 - 1. Percentage of damage taken.
    protected float damageCoef;
    protected int weight;

    public Armor(int damageCoef, int weight) : base()
    {
        this.damageCoef = damageCoef;
        this.weight = weight;
    }

    public int GetDamage(int baseDamage)
    {
        int totalDamage = Mathf.FloorToInt(baseDamage * damageCoef);
        return totalDamage;
    }

    public int GetWeight()
    {
        return weight;
    }
}
