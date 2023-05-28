using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehaviour : MonoBehaviour
{
    public GameObject throwablePrefab;
    public float fireForce;

    private Ranged rangedScript;
    protected float cooldown;
    protected bool canAttack = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool Fire()
    {
        bool attacked = false;
        if (canAttack)
        {
            GameObject throwable = Instantiate(throwablePrefab, transform.position, transform.rotation);
            throwable.GetComponent<Throwable>().SetDamage(rangedScript.GetDamage());
            throwable.GetComponent<Throwable>().SetRange(rangedScript.GetRange());
            throwable.GetComponent<Throwable>().SetRadius(rangedScript.GetRadius());
            throwable.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
            StartCoroutine(Cooldown());
            attacked = true;
        }
        return attacked;
    }

    public void SetRangedScript(Ranged rangedScript)
    {
        this.rangedScript = rangedScript;
        cooldown = rangedScript.GetCooldown();
        Debug.Log("Set Ranged Script");
    }

    IEnumerator Cooldown()
    {
        Debug.Log("cooldown started");
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }

    private void OnEnable()
    {
        canAttack = true;
    }
}
