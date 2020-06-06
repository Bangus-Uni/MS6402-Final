
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerEnemy : Enemy
{

    void Update()
    {
        if(!boolFrozen) gameObject.transform.Rotate(0f, 30f, 0.0f, Space.Self);
        for (int i = 0; i < EnemyGun.Length; i++) {

            if (boolShocked)
            {
                EnemyGun[i].boolIsFiring = false;
            }

            else EnemyGun[i].boolIsFiring = true;
        }
    }
}
