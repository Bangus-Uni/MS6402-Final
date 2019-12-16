using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{

    public int intHealth;
    public int intMaxHealth;
    public float flMoveSpeed = 5;
    private Rigidbody rbEnemy;

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

    void Update()
    {
        gameObject.transform.Rotate(0f, 30f, 0.0f, Space.Self);
        //transform.LookAt(new Vector3(goPC.transform.position.x, transform.position.y, goPC.transform.position.z));
        for (int i = 0; i < EnemyGun.Length; i++)
        {
            EnemyGun[i].boolIsFiring = true;
        }

    }

    private void FixedUpdate()
    {
       // transform.position = Vector3.MoveTowards(transform.position, goPC.transform.position, flMoveSpeed * Time.deltaTime);
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
