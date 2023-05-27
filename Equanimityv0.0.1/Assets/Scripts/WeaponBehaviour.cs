using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
   public GameObject projectile;
   public Transform firePoint;

   public float fireForce;
   public void Fire()
   {
      GameObject prop = Instantiate(projectile, firePoint.position, firePoint.rotation);
      prop.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
   }
}
