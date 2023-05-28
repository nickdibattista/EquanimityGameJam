using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehaviour : MonoBehaviour
{
    public GameObject throwablePrefab;
    public float fireForce;

    private Ranged rangedScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Fire()
    {
        GameObject throwable = Instantiate(throwablePrefab, transform.position, transform.rotation);
        throwable.GetComponent<Throwable>().SetDamage(rangedScript.GetDamage());
        throwable.GetComponent<Throwable>().SetRange(rangedScript.GetRange());
        throwable.GetComponent<Throwable>().SetRadius(rangedScript.GetRadius());
        throwable.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
    }

    public void SetRangedScript(Ranged rangedScript)
    {
        this.rangedScript = rangedScript;
        Debug.Log("Set Ranged Script");
    }

}
