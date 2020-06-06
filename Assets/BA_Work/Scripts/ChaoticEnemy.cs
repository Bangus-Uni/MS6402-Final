using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoticEnemy : Enemy
{
    void Update()
    {

        if (!boolFrozen) gameObject.transform.Rotate(0f, 30f, 0.0f, Space.Self);
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
