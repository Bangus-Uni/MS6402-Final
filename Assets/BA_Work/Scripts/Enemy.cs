using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int intHealth;
    public int intMaxHealth;
    public float flMoveSpeed = 5;
    public Rigidbody rbEnemy;

    public GameObject goPC;

    public float flRange;

    private Vector3 v3MoveVelocity;

    public Gun[] EnemyGun;

    public float flCooldownTime = 5f;

    public float flIceTime = 0;
    public float flShockTime = 0;

    public bool boolFrozen = false;
    public bool boolShocked = false;

    public bool boolFrozenAct = false;
    public bool boolShockedAct = false;

    public bool boolFrozenPerma = false;
    public bool boolShockedPerma = false;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
        goPC = GameObject.FindGameObjectWithTag("PC");
        intHealth = intMaxHealth;
    }

    public void IceCooldown()
    {
        flIceTime += Time.deltaTime;
        if (flIceTime >= flCooldownTime)
        {
            boolFrozen = false;
            boolFrozenAct = false;
            boolFrozenPerma = true;
            flIceTime = 0;
        }
    }

    public void ShockCooldown()
    {
        flShockTime += Time.deltaTime;
        if (flShockTime >= flCooldownTime)
        {
            boolShocked = false;
            boolShockedAct = false;
            boolShockedPerma = true;
            flIceTime = 0;
        }
    }

    public void TakeDamage(int _intDamage)
    {
        intHealth = intHealth - _intDamage;
        if (intHealth <= 0) Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            intHealth--;

            if (collision.gameObject.GetComponent<Bullet>().boolFireBullet == true)
            {
                intHealth--;
                intHealth--;
            }

            else if (collision.gameObject.GetComponent<Bullet>().boolIceBullet == true && !boolFrozenPerma)
            {
                boolFrozen = true;
            }
            else if (collision.gameObject.GetComponent<Bullet>().boolFireBullet == true && !boolShockedPerma)
            {
                boolShocked = true;
            }


            Destroy(collision.gameObject);

            if (intHealth <= 0) Destroy(gameObject);
        }
    }

}
