using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GunType : IComparable<GunType>
{

    public string strGTGunName;
    public string strGTGunDesc;
    public int intGTFireType;
    public Bullet GTBullet;
    public float flGTBulletSpeed;
    public float flGTTimeBetweenShots;
    public bool boolGTCorrupted;
    public int intGTCorruption;

    public GunType(string _strGTGunName, string _strGTGunDesc, int _intGTFireType, Bullet _GTBullet, float _flGTBulletSpeed, float _flGTTimeBetweenShots, bool _boolGTCorrupted, int _intGTCorruption) {
        strGTGunName = _strGTGunName;
        strGTGunDesc = _strGTGunDesc;
        intGTFireType = _intGTFireType;
        GTBullet = _GTBullet;
        flGTBulletSpeed = _flGTBulletSpeed;
        flGTTimeBetweenShots = _flGTTimeBetweenShots;
        boolGTCorrupted = _boolGTCorrupted;
        intGTCorruption = _intGTCorruption;
    }

    public int CompareTo(GunType other) {
        if (other == null) {
            return 1;
        }

        return intGTFireType = other.intGTFireType;
    }

}
