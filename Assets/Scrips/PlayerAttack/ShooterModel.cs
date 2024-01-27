using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shooter", menuName = "Shooter")]
public class ShooterModel : ScriptableObject
{
    public float fireRate;
    public GameObject bulletPrefab;
}