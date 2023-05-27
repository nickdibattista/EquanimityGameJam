using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    protected int health, speed, damage;

    public Entity(int health, int speed, int damage)
    {
        this.health = health;
        this.speed = speed;
        this.damage = damage;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void TakeDamage()
    {
        health -= 1;
    }
}
