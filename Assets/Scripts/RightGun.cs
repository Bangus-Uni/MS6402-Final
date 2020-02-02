using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGun : Gun
{
    public void SetGun(GunType GunPickup)
    {
        intGunType = GunPickup.intGTFireType;
        bullet = GunPickup.GTBullet;
        flBulletSpeed = GunPickup.flGTBulletSpeed;
        flTimeBetweenShots = GunPickup.flGTTimeBetweenShots;
        GM.SetRightGun(GunPickup);
        intHeat = 0;
    }
}
