using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public float flMoveSpeed = 5;
    private Rigidbody rbEnemy;

    public GameObject goPC;

    public float flRange;

    private Vector3 v3MoveVelocity;

    public Gun EnemyGun;

    void Start() {
        rbEnemy = GetComponent<Rigidbody>();
        goPC = GameObject.FindGameObjectWithTag("PC");
    }

    void Update() {

       transform.LookAt(new Vector3(goPC.transform.position.x, transform.position.y, goPC.transform.position.z));
       EnemyGun.boolIsFiring = true;
    }

    private void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, goPC.transform.position, flMoveSpeed * Time.deltaTime);
    }

}
