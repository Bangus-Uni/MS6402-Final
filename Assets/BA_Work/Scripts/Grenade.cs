using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bullet
{

    public Rigidbody rbGrenade;

    public float flBlastRadius = 6;
    public int intDamage = 15;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        Collider[] Blast = Physics.OverlapSphere(transform.position, flBlastRadius);

        foreach (Collider AffectedObject in Blast)
        {
            Enemy AffectedEnemy = AffectedObject.GetComponent<Enemy>();

            if (AffectedEnemy != null)
            {
                AffectedEnemy.TakeDamage(intDamage);
            }
        }

        Destroy(gameObject);
    }
}
