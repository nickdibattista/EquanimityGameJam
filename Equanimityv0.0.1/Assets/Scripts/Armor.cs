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

    public float GetDamage(float baseDamage)
    {
        float totalDamage = baseDamage * damageCoef;
        Debug.Log($"{baseDamage} * {damageCoef} = {totalDamage}");
        return totalDamage;
    }

    public float GetWeight()
    {
        return weight;
    }
}
