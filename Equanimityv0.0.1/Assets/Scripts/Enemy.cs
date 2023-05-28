using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected GameLoop gameLoop;
    protected int id;
    public Enemy(int health, int speed, int damage, GameLoop gameLoop, int id) : base(health, speed, damage)
    {
        this.gameLoop = gameLoop;
        this.id = id;
        this.damage = damage;
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    public int GetId()
    {
        return id;
    }

    public override int TakeDamage(int damage)
    {
        health -= damage;
        if (IsDead())
        {
            gameLoop.KillEnemy(id);
            Debug.Log("Enemy killed");
        }
        return health;
    }

}
