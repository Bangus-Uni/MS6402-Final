using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool boolIsFiring;

    public Bullet bullet;
    public float flBulletSpeed;

    public float flTimeBetweenShots;
    private float flShotCounter;

    public Transform trFirePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boolIsFiring) {
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0) {
                flShotCounter = flTimeBetweenShots;
                Bullet newBullet = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation) as Bullet;
                newBullet.flSpeed = flBulletSpeed;
            }
        }

        else {
            flShotCounter = 0;
        }
    }
}
