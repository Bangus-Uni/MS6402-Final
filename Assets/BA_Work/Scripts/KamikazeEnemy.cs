using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : Enemy
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
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, goPC.transform.position) >= flRange)
        {
            if (!boolFrozen) transform.position = Vector3.MoveTowards(transform.position, goPC.transform.position, flMoveSpeed * Time.deltaTime);
        }

        else {

            Collider[] Blast = Physics.OverlapSphere(transform.position, 3);

            foreach (Collider AffectedObject in Blast)
            {
                PC AffectedPC = AffectedObject.GetComponent<PC>();

                if (AffectedPC != null)
                {
                    AffectedPC.GrenadeHit();
                }
            }

            Destroy(gameObject);
        }

    }
}
