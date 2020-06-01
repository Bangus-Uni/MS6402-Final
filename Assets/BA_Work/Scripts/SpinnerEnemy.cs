
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerEnemy : Enemy
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

        if (boolShockedAct)
        {
            EnemyGun[i].boolIsFiring = false;
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
}
