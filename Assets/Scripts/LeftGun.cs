using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGun : Gun
{
    void SetGun(GunType GunPickup)
    {
        intGunType = GunPickup.intGTFireType;
        bullet = GunPickup.GTBullet;
        flBulletSpeed = GunPickup.flGTBulletSpeed;
        flTimeBetweenShots = GunPickup.flGTTimeBetweenShots;
        GM.SetLeftGun(GunPickup);
    }
}
