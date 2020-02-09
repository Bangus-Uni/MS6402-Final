
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerEnemy : Enemy
{

    void Update()
    {
        gameObject.transform.Rotate(0f, 30f, 0.0f, Space.Self);
        for (int i = 0; i < EnemyGun.Length; i++)
        {
            EnemyGun[i].boolIsFiring = true;
        }

    }
}
