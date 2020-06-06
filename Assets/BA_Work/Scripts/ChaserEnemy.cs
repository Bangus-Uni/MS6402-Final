using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : Enemy
{

    public GameObject goIcePS;
    public GameObject goShockPS;

    void Update()
    {

        if (boolFrozen)
        {
            goIcePS.SetActive(true);
        }

        else
        {
            goIcePS.SetActive(false);
        }

        if (boolShocked)
        {
            goShockPS.SetActive(true);
        }

        else
        {
            goShockPS.SetActive(false);
        }


        if (!boolFrozen) transform.LookAt(new Vector3(goPC.transform.position.x, transform.position.y, goPC.transform.position.z));
        for (int i = 0; i < EnemyGun.Length; i++)
        {
            if (boolShocked)
            {
                EnemyGun[i].boolIsFiring = false;
            }

            else EnemyGun[i].boolIsFiring = true;
        }

    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, goPC.transform.position) >= flRange)
        {
            if (!boolFrozen) transform.position = Vector3.MoveTowards(transform.position, goPC.transform.position, flMoveSpeed * Time.deltaTime);
        }

        else
        {
            if (!boolFrozen) transform.position = Vector3.MoveTowards(transform.position, goPC.transform.position, -1 * flMoveSpeed * Time.deltaTime);
        }
        
    }
}
