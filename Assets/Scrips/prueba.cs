using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entre");
        if (other.gameObject.layer == LayerMask.NameToLayer("Damagable"))
        {
            Debug.Log("llame a la funcion");
            other.gameObject.GetComponent<Enemy1>().Damage(25f);
        }
    }
}
