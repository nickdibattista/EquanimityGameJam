using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{

    public GameObject projectile;
    protected int damage, range;
    protected float radius;
    protected Vector2 startingPosition;
    protected bool exploded = false;

    void Start()
    {
        startingPosition = transform.position; //new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (Vector2.Distance(startingPosition, transform.position) >= range)
        {
            Explode();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!exploded)
        {
            switch (other.gameObject.tag)
            {
                case "Player":
                    break;
                default:
                    Debug.Log("TRIGGER");
                    Explode();
                    break;
            }
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public void SetRange(int range)
    {
        this.range = range;
    }
    public void SetRadius(float radius)
    {
        this.radius = radius;
    }

    private void Explode()
    {
        exploded = true;
        GameObject prop = Instantiate(projectile, transform.position, transform.rotation);
        prop.GetComponent<Projectile>().SetDamage(damage);
        prop.GetComponent<Projectile>().SetRadius(radius);
        //prop.GetComponent<Projectile>().SetAnimator(anim);

        Destroy(gameObject);
    }

}
