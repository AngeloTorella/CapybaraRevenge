using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] BulletModel bulletData;

    private void Start()
    {
        StartCoroutine(DestroyOnTime());
    }

    IEnumerator DestroyOnTime()
    {
        yield return new WaitForSeconds(bulletData.getBulletRange());
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (!collision.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);
    }
}
