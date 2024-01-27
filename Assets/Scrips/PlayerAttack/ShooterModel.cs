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

    public float getMagazine()
    {
        return this.magazine;
    }

    public float getAmmoRecerve()
    {
        return this.ammoRecerve;
    }

    public GameObject getBulletPrefab()
    {
        return this.bulletPrefab;
    }
}