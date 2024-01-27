using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet")]
public class BulletModel : ScriptableObject
{
    public int damage;
    public float speed;
    public float range;
}
