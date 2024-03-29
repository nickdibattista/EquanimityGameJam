using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool manuallyCreate;
    private Enemy enemyScript;
    public PlayerController player;
    private float attackDelay = 1; 
    private float attackTimer = 0;
    private bool isTouching = false;
    public SpriteRenderer sprite;



    void Start()
    {
        player = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isTouching==true)
        {
            attackTimer -= Time.deltaTime;  
        }
    }

    public void SetEnemyScript(Enemy enemyScript)
    {
        this.enemyScript = enemyScript;
    }

    public void TakeDamage(int damage)
    {   
        StartCoroutine(FlashRed());
        int health = enemyScript.TakeDamage(damage);
        if (enemyScript.IsDead())
        {
            Destroy(gameObject);
        }
        Debug.Log($"Took {damage} damage");
    }

    /*IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }*/

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(attackTimer <= 0)
            {
                player.CalculatedHealth(enemyScript.GetDamage());
                Debug.Log("Let him cook"); 
                attackTimer = attackDelay;

            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isTouching = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {   
        if(other.gameObject.tag == "Player")
        {
            isTouching = true;
            player.CalculatedHealth(enemyScript.GetDamage());
            Debug.Log("you have entered the pain domaine "); 
        }
    }

    public IEnumerator FlashRed()
    {
        Debug.Log("Flashing red!");
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }


}
