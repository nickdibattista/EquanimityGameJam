using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) 
    {
        switch(other.gameObject.tag)
        {
            case "Enemy":
                other.GetComponent<EnemyBehaviour>().Damage();
            break;
        }
        Destroy(gameObject);
    }
}
