using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private ShooterModel shooterModel; // Referencia a la arma actual
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform player; // Referencia al jugador
    [SerializeField] private Vector3 gunOffset; // Desplazamiento de la pistola
    [SerializeField] private float followSpeed = 1f; // Velocidad de seguimiento
    private float nextFireTime;

    // Start is called before the first frame update
    void Start()
    {
        //definir offset
        gunOffset = new Vector3(0.7f, -0.2f, -1);
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime){
            shoot();
            nextFireTime = Time.time + 1f / shooterModel.fireRate;
        }

        // Hacer que el ShooterController siga al jugador con un retraso
        Vector3 targetPosition = player.position + gunOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
    }

    void shoot () {
        // Instantiate the bullet at the position and rotation of the bulletSpawnPoint
        GameObject bullet = Instantiate(shooterModel.bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Calculate the direction vector from the ShooterController to the bulletSpawnPoint
        Vector3 direction = (bulletSpawnPoint.position - transform.position).normalized;

        // Make sure the bullet is fired in the correct direction
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null) {
            BulletController bulletScript = bullet.GetComponent<BulletController>();
            if (bulletScript != null) {
            rb.velocity = direction;
            }
        }
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);

        
        // Draw a Gizmo at the bulletSpawnPoint
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(bulletSpawnPoint.position, Vector3.one * 0.1f);
    }
}