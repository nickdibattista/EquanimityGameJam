using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
    public GameObject projectile;
    //private bool manuallyCreate = true;

    private Melee meleeScript;

    void Start()
    {
       /* if (manuallyCreate)
        {
            weaponScript = new Melee(baseDamage, baseRange, baseCooldown);
        }*/
    }


    public void Fire()
    {
        GameObject prop = Instantiate(projectile, transform.position, transform.rotation);
        prop.GetComponent<Projectile>().SetDamage(meleeScript.GetDamage());
        //prop.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void SetMeleeScript(Melee meleeScript)
    {
        this.meleeScript = meleeScript;
        Debug.Log("Set Melee Script");
    }

}
