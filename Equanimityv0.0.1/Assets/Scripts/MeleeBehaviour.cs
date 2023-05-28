using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float fireForce;
    //private bool manuallyCreate = true;

    [SerializeField]
    private int baseDamage, baseRange, baseCooldown;
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
        Debug.Log(meleeScript);
        GameObject prop = Instantiate(projectile, firePoint.position, firePoint.rotation);
        prop.GetComponent<Projectile>().SetDamage(meleeScript.GetDamage());
        prop.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void SetMeleeScript(Melee meleeScript)
    {
        this.meleeScript = meleeScript;
        Debug.Log("Set Melee Script");
    }

}
