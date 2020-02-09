using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : Bullet
{

    public GameObject goTarget = null;
    public int intDamage = 10;

    private void Start()
    {

        Destroy(gameObject, flDestroyTime);

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        goTarget = closest;
    }

    // Update is called once per frame
    void Update()
    {
        if (goTarget != null)
        {
            transform.LookAt(new Vector3(goTarget.transform.position.x, goTarget.transform.position.y + 1, goTarget.transform.position.z));
        }

        transform.Translate(Vector3.forward * flSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemyHit = collision.gameObject.GetComponent<Enemy>();

        if(enemyHit != null)
        {
            enemyHit.TakeDamage(intDamage);
        }

        if(collision.gameObject.tag != "EnemyBullet")
        {
            Debug.Log("Collided With: " + collision.gameObject);
            Destroy(gameObject);
        }
    }
}
