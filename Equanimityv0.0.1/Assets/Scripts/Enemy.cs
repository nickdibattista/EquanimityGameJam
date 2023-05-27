using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected int spawnRate;
    public Enemy(int spawnRate, int health, int speed, int damage) : base(health, speed, damage)
    {
        this.spawnRate = spawnRate;
    }
}
