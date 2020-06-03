using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : Enemy
{
    void Update()
    {
        transform.LookAt(new Vector3(goPC.transform.position.x, transform.position.y, goPC.transform.position.z));
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, goPC.transform.position) >= flRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, goPC.transform.position, flMoveSpeed * Time.deltaTime);
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
