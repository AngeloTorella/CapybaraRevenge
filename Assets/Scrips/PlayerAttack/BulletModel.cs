using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet")]
public class BulletModel : ScriptableObject
{
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletRange;

    public float getBulletDamage()
    {
        return bulletDamage;
    }

    public float getBulletSpeed()
    {
        return Mathf.Round(bulletSpeed);
    }

    public float getBulletRange()
    {
        return bulletRange;
    }
}
