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

                if (!boolFrozenAct)
                {
                    Invoke("TurnOffFrozen", 8);
                }
                boolFrozenAct = true;
            }
            else if (collision.gameObject.GetComponent<Bullet>().boolShockBullet == true && !boolShockedPerma)
            {
                boolShocked = true;

                if (!boolShockedAct)
                {
                    Invoke("TurnOffShock", 5);
                }

                boolShockedAct = true;
            }


            Destroy(collision.gameObject);

            if (intHealth <= 0) Destroy(gameObject);
        }
    }

    public void TurnOffFrozen() {
        boolFrozen = false;
        boolFrozenPerma = true;
    }

     public void TurnOffShock() {
        boolShocked = false;
        boolShockedPerma = true;
    }

}
