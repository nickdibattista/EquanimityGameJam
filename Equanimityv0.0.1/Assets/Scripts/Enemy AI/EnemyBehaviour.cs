using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool manuallyCreate;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        if (manuallyCreate)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnemy(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Damage()
    {
        enemy.TakeDamage();
    }
}
