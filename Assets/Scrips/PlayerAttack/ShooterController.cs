using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform player; // Referencia al jugador
    [SerializeField] private Vector3 gunOffset; // Desplazamiento de la pistola
    [SerializeField] private float followSpeed = 1f; // Velocidad de seguimiento

    // Start is called before the first frame update
    void Start()
    {
        //definir offset
        gunOffset = new Vector3(0.7f, -0.2f, 0);
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetButtonDown("Fire1")){
            shoot();
        }

        // Hacer que el ShooterController siga al jugador con un retraso
        Vector3 targetPosition = player.position + gunOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
    }

    void shoot () {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}