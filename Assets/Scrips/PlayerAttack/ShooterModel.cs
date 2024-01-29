using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponModel : ScriptableObject
{
    [SerializeField] private float      fireRate;
    [SerializeField] private float      weaponRecoil;
    [SerializeField] private float      reloadTime;

    [SerializeField] private int        magazine;
    [SerializeField] private int        ammoRecerve;
    [SerializeField] private int        bulletsPerShot;
    [SerializeField] private float        accuracy;

    [SerializeField] private GameObject bulletPrefab;

    public float getFireRate()
    {
        return this.fireRate;
    }

    public float getWeaponRecoil()
    {
        return this.weaponRecoil;
    }

    public float getReloadTime()
    {
        return this.reloadTime;
    }

    public int getMagazine()
    {
        return this.magazine;
    }

    public int getAmmoRecerve()
    {
        return this.ammoRecerve;
    }

    public GameObject getBulletPrefab()
    {
        return this.bulletPrefab;
    }

    public int getBulletsPerShot()
    {
        return this.bulletsPerShot;
    }

    public float getAccuracy()
    {
        return this.accuracy;
    }
}