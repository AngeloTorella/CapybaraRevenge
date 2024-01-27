using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private BulletModel bulletData;

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(bulletData.getBulletSpeed() * Time.deltaTime * transform.right);
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (!collision.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);
    } 
}
