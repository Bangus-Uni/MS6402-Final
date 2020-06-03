using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoticEnemy : Enemy
{
    void Update()
    {
        IceCooldown();
        ShockCooldown();

        if (boolFrozen)
        {
            boolFrozenAct = true;
            flIceTime = 0;
        }

        if (boolShocked)
        {
            boolShockedAct = true;
            flShockTime = 0;
        }

        if (boolFrozenAct)
        {
            flMoveSpeed = 0;
        }

        gameObject.transform.Rotate(0f, 30f, 0.0f, Space.Self);
        for (int i = 0; i < EnemyGun.Length; i++)
        {
            if (boolShockedAct)
            {
                EnemyGun[i].boolIsFiring = false;
            }

            else
            {
                EnemyGun[i].boolIsFiring = true;
            }
        }

    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, goPC.transform.position) >= flRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, goPC.transform.position, flMoveSpeed * Time.deltaTime);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, goPC.transform.position, -1 * flMoveSpeed * Time.deltaTime);
        }

    }
}
