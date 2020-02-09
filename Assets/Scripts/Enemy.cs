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
            Destroy(collision.gameObject);

            if (intHealth <= 0) Destroy(gameObject);
        }
    }

}
