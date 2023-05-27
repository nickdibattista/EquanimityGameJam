using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected int spawnRate;
    public Enemy(int spawnRate) : base(20, 5, 5)
    {
        this.spawnRate = spawnRate;
    }
}
