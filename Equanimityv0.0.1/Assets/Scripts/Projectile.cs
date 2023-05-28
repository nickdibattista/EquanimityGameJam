using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected int damage;
    protected float radius = 0.5f;

    private void Start()
    {
        var cols = Physics2D.OverlapCircleAll(transform.position, radius);
        int enemies = 0;
        foreach (var col in cols)
        {
            switch (col.gameObject.tag)
            {
                case "Enemy":
                    Debug.Log(damage);
                    enemies++;
                    col.GetComponent<EnemyBehaviour>().TakeDamage(damage);
                    break;
            }
        }
        Debug.Log($"{enemies} colliders");
        StartCoroutine(Decay());
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                Debug.Log(damage);
                other.GetComponent<EnemyBehaviour>().TakeDamage(damage);
            break;
        }
        Destroy(gameObject);
    }*/

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetRadius(float radius)
    {
        this.radius = radius;
    }

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
