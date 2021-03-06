﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameManager GM;

    public bool boolPCGun = false;

    public bool boolIsFiring;
    public int intLeftOrRight;

    public Bullet bullet;
    public float flBulletSpeed;

    public float flTimeBetweenShots;
    private float flShotCounter;

    public Transform trFirePoint;

    public int intHeat = 0;
    public int intMaxHeat = 100;
    public bool boolHeatGen = false;
    public bool boolOverHeat = false;

    public int intGunType = 1;

    int intWaveShotTicker = 0;
    bool boolWaveShotDir = true;


    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boolPCGun) { 
            if (intLeftOrRight == 1)
            {
                GM.LeftGunAmmo(intHeat, boolOverHeat);
            }

            if (intLeftOrRight == 2)
            {
                GM.RightGunAmmo(intHeat, boolOverHeat);
            }

            if (boolHeatGen) HeatGun();
            Cooldown();
            boolHeatGen = false;
        }


        if (intGunType == 1)
        {
            BasicShot();
        }
        if (intGunType == 2)
        {
            WideShot();
        }
        if (intGunType == 3)
        {
            WaveShot();
        }
        if (intGunType == 4)
        {
            ThreeProngShot();
        }
        if (intGunType == 5)
        {
            FiveProngShot();
        }
        if (intGunType == 6)
        {
            GrenadeShot();
        }
        if (intGunType == 7)
        {
            BuckShot();
        }
    }

    void BasicShot()
    {
        if (boolIsFiring && !boolOverHeat)
        {
            boolHeatGen = true;
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                flShotCounter = flTimeBetweenShots;
                Bullet newBullet = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation) as Bullet;
                newBullet.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void WideShot()
    {
        Vector3 v3FirePointLoc1 = new Vector3(trFirePoint.position.x - 0.5f, trFirePoint.position.y, trFirePoint.position.z);
        Vector3 v3FirePointLoc2 = new Vector3(trFirePoint.position.x, trFirePoint.position.y, trFirePoint.position.z);
        Vector3 v3FirePointLoc3 = new Vector3(trFirePoint.position.x + 0.5f, trFirePoint.position.y, trFirePoint.position.z);



        if (boolIsFiring && !boolOverHeat)
        {
            boolHeatGen = true;
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                flShotCounter = flTimeBetweenShots;
                Bullet newBullet1 = Instantiate(bullet, v3FirePointLoc1, trFirePoint.rotation) as Bullet;
                Bullet newBullet2 = Instantiate(bullet, v3FirePointLoc2, trFirePoint.rotation) as Bullet;
                Bullet newBullet3 = Instantiate(bullet, v3FirePointLoc3, trFirePoint.rotation) as Bullet;
                newBullet1.flSpeed = flBulletSpeed;
                newBullet2.flSpeed = flBulletSpeed;
                newBullet3.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void WaveShot()
    {
        float[] a_flWaveLocs = {
            trFirePoint.position.x - 1f,
            trFirePoint.position.x - 0.5f,
            trFirePoint.position.x,
            trFirePoint.position.x + 0.5f,
            trFirePoint.position.x + 1f 
        };
        Vector3 v3FirePointWaveLoc;
        

        if (boolIsFiring && !boolOverHeat)
        {
            boolHeatGen = true;
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                flShotCounter = flTimeBetweenShots;

                if (intWaveShotTicker > 3)
                {
                    boolWaveShotDir = false;
                }
                    
                if (intWaveShotTicker < 1)
                {
                    boolWaveShotDir = true;
                }

                if (!boolWaveShotDir) intWaveShotTicker--;

                if (boolWaveShotDir) intWaveShotTicker++;

                v3FirePointWaveLoc = new Vector3(a_flWaveLocs[intWaveShotTicker], trFirePoint.position.y, trFirePoint.position.z);
                Bullet newBullet = Instantiate(bullet, v3FirePointWaveLoc, trFirePoint.rotation) as Bullet;
                newBullet.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void ThreeProngShot()
    {
        if (boolIsFiring && !boolOverHeat)
        {
            boolHeatGen = true;
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                Quaternion leftFirePoint = Quaternion.Euler(0, -30, 0);
                Quaternion rightFirePoint = Quaternion.Euler(0, 30, 0);

                flShotCounter = flTimeBetweenShots;
                Bullet newBullet1 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * leftFirePoint) as Bullet;
                Bullet newBullet2 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation) as Bullet;
                Bullet newBullet3 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * rightFirePoint) as Bullet;
                newBullet1.flSpeed = flBulletSpeed;
                newBullet2.flSpeed = flBulletSpeed;
                newBullet3.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void FiveProngShot()
    {
        if (boolIsFiring && !boolOverHeat)
        {
            boolHeatGen = true;
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                Quaternion leftFirePoint = Quaternion.Euler(0, -25, 0);
                Quaternion rightFirePoint = Quaternion.Euler(0, 25, 0);
                Quaternion leftFirePoint2 = Quaternion.Euler(0, -50, 0);
                Quaternion rightFirePoint2 = Quaternion.Euler(0, 50, 0);

                flShotCounter = flTimeBetweenShots;
                Bullet newBullet1 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * leftFirePoint) as Bullet;
                Bullet newBullet2 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation) as Bullet;
                Bullet newBullet3 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * rightFirePoint) as Bullet;
                Bullet newBullet4 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * leftFirePoint2) as Bullet;
                Bullet newBullet5 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * rightFirePoint2) as Bullet;
                newBullet1.flSpeed = flBulletSpeed;
                newBullet2.flSpeed = flBulletSpeed;
                newBullet3.flSpeed = flBulletSpeed;
                newBullet4.flSpeed = flBulletSpeed;
                newBullet5.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }
    void GrenadeShot()
    {
        if (boolIsFiring && !boolOverHeat)
        {
            boolHeatGen = true;
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                Quaternion GrenadeThrowPoint = Quaternion.Euler(-45, 0, 0);

                flShotCounter = flTimeBetweenShots;
                Bullet NewGrenade = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * GrenadeThrowPoint) as Bullet;
                intHeat += 51;
                NewGrenade.flSpeed = flBulletSpeed;
                NewGrenade.gameObject.GetComponent<Rigidbody>().AddForce(trFirePoint.forward * flBulletSpeed, ForceMode.VelocityChange);
                NewGrenade.gameObject.GetComponent<Rigidbody>().AddForce(trFirePoint.up * (flBulletSpeed * 1.5f), ForceMode.VelocityChange);
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void BuckShot()
    {
        Vector3 v3FirePointLoc1 = new Vector3(trFirePoint.position.x - 0.5f, trFirePoint.position.y, trFirePoint.position.z);
        Vector3 v3FirePointLoc2 = new Vector3(trFirePoint.position.x, trFirePoint.position.y, trFirePoint.position.z);
        Vector3 v3FirePointLoc3 = new Vector3(trFirePoint.position.x + 0.5f, trFirePoint.position.y, trFirePoint.position.z);
        Vector3 v3FirePointLoc4 = new Vector3(trFirePoint.position.x - 0.5f, trFirePoint.position.y - 0.5f, trFirePoint.position.z);
        Vector3 v3FirePointLoc5 = new Vector3(trFirePoint.position.x, trFirePoint.position.y - 0.5f, trFirePoint.position.z);
        Vector3 v3FirePointLoc6 = new Vector3(trFirePoint.position.x + 0.5f, trFirePoint.position.y - 0.5f, trFirePoint.position.z);
        Vector3 v3FirePointLoc7 = new Vector3(trFirePoint.position.x - 0.5f, trFirePoint.position.y + 0.5f, trFirePoint.position.z);
        Vector3 v3FirePointLoc8 = new Vector3(trFirePoint.position.x, trFirePoint.position.y + 0.5f, trFirePoint.position.z);
        Vector3 v3FirePointLoc9 = new Vector3(trFirePoint.position.x + 0.5f, trFirePoint.position.y + 0.5f, trFirePoint.position.z);



        if (boolIsFiring && !boolOverHeat)
        {
            boolHeatGen = true;
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                flShotCounter = flTimeBetweenShots;
                Bullet newBullet1 = Instantiate(bullet, v3FirePointLoc1, trFirePoint.rotation) as Bullet;
                Bullet newBullet2 = Instantiate(bullet, v3FirePointLoc2, trFirePoint.rotation) as Bullet;
                Bullet newBullet3 = Instantiate(bullet, v3FirePointLoc3, trFirePoint.rotation) as Bullet;
                Bullet newBullet4 = Instantiate(bullet, v3FirePointLoc4, trFirePoint.rotation) as Bullet;
                Bullet newBullet5 = Instantiate(bullet, v3FirePointLoc5, trFirePoint.rotation) as Bullet;
                Bullet newBullet6 = Instantiate(bullet, v3FirePointLoc6, trFirePoint.rotation) as Bullet;
                Bullet newBullet7 = Instantiate(bullet, v3FirePointLoc7, trFirePoint.rotation) as Bullet;
                Bullet newBullet8 = Instantiate(bullet, v3FirePointLoc8, trFirePoint.rotation) as Bullet;
                Bullet newBullet9 = Instantiate(bullet, v3FirePointLoc9, trFirePoint.rotation) as Bullet;

                newBullet1.flSpeed = flBulletSpeed;
                newBullet2.flSpeed = flBulletSpeed;
                newBullet3.flSpeed = flBulletSpeed;
                newBullet4.flSpeed = flBulletSpeed;
                newBullet5.flSpeed = flBulletSpeed;
                newBullet6.flSpeed = flBulletSpeed;
                newBullet7.flSpeed = flBulletSpeed;
                newBullet8.flSpeed = flBulletSpeed;
                newBullet9.flSpeed = flBulletSpeed;

                newBullet1.flDestroyTime = 0.2f;
                newBullet2.flDestroyTime = 0.2f;
                newBullet3.flDestroyTime = 0.2f;
                newBullet4.flDestroyTime = 0.2f;
                newBullet5.flDestroyTime = 0.2f;
                newBullet6.flDestroyTime = 0.2f;
                newBullet7.flDestroyTime = 0.2f;
                newBullet8.flDestroyTime = 0.2f;
                newBullet9.flDestroyTime = 0.2f;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void HeatGun()
    {
        intHeat++;
        if (intHeat >= intMaxHeat) boolOverHeat = true;
    }

    void HeatGunGrenade()
    {
        intHeat += 50;
        if (intHeat >= intMaxHeat) boolOverHeat = true;
    }

    void Cooldown()
    {
        if (intHeat == 0) boolOverHeat = false;
        if (intHeat > 0 && !boolHeatGen) intHeat--;
        if (intHeat < 0) intHeat = 0;
    }
}
