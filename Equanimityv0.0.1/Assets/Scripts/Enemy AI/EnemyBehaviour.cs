using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool manuallyCreate;
    private Enemy enemyScript;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void SetEnemyScript(Enemy enemyScript)
    {
        this.enemyScript = enemyScript;
    }

    public void TakeDamage(int damage)
    {
        int health = enemyScript.TakeDamage(damage);
        if (enemyScript.IsDead())
        {
            Destroy(gameObject);
        }
        Debug.Log(health);
    }

    /*IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }*/
}
