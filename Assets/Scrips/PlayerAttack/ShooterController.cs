using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private WeaponModel    weaponModel; // Referencia a la arma actual
    [SerializeField] private Transform      bulletSpawnPoint;
    [SerializeField] private Transform      player; // Referencia al jugador
    [SerializeField] private Vector3        gunOffset; // Desplazamiento de la pistola
    [SerializeField] private float          followSpeed = 1f; // Velocidad de seguimiento

    private float                           nextFireTime;

    // Start is called before the first frame update
    void Start()
    {
        //definir offset
        gunOffset = new Vector3(0.7f, -0.2f, -1);
    }

    private void FixedUpdate()
    {
        bulletSpawnPoint.localRotation = transform.localRotation;
    }

    void Update() 
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime){
            shoot();
            nextFireTime = Time.time + 1f / weaponModel.getFireRate();
        }

        // Hacer que el ShooterController siga al jugador con un retraso
        Vector3 targetPosition = player.position + gunOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
    }

    void shoot () {
        // Instantiate the bullet at the position and rotation of the bulletSpawnPoint
        GameObject bullet = Instantiate(weaponModel.getBulletPrefab(), bulletSpawnPoint.position, bulletSpawnPoint.rotation);

    }

    void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);

        
        // Draw a Gizmo at the bulletSpawnPoint
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(bulletSpawnPoint.position, Vector3.one * 0.1f);
    }
}