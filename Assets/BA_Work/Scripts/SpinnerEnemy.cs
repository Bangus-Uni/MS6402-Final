
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerEnemy : Enemy
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


        if (!boolFrozen) gameObject.transform.Rotate(0f, 30f, 0.0f, Space.Self);
        for (int i = 0; i < EnemyGun.Length; i++) {

            if (boolShocked)
            {
                EnemyGun[i].boolIsFiring = false;
            }

            else EnemyGun[i].boolIsFiring = true;
        }
    }
}
