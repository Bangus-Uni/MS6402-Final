using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargeterEnemy : Enemy
{

    public GameObject goIcePS;
    public GameObject goShockPS;

    // Start is called before the first frame update
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

}
