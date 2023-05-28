using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
    public GameObject projectile;
    //private bool manuallyCreate = true;

    private Melee meleeScript;
    protected float cooldown;
    protected bool canAttack = true;

    void Start()
    {
       /* if (manuallyCreate)
        {
            weaponScript = new Melee(baseDamage, baseRange, baseCooldown);
        }*/
    }


    public bool Fire()
    {
        bool attacked = false;
        if (canAttack)
        {
            GameObject prop = Instantiate(projectile, transform.position, transform.rotation);
            prop.GetComponent<Projectile>().SetDamage(meleeScript.GetDamage());
            prop.GetComponent<Projectile>().SetKnockback(meleeScript.GetKnockback());
            StartCoroutine(Cooldown());
            attacked = true;
        }
        return attacked;
    }

    public void SetMeleeScript(Melee meleeScript)
    {
        this.meleeScript = meleeScript;
        cooldown = meleeScript.GetCooldown();
        Debug.Log("Set Melee Script");
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
