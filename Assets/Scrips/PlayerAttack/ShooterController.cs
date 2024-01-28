using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] GameObject             bulletPrefab;

    [SerializeField] Transform              bulletSpawn;
    [SerializeField] Transform              gunT;
    [SerializeField] Transform              playerT;

    [SerializeField] BulletModel            bulletData;
    [SerializeField] WeaponModel            weaponData;

    [SerializeField] float                  gunFollowSpeed;

    private SpriteRenderer      spriteRenderer;

    private IGunLogicController gunInfo;
    private GunSoundController gunSoundController;

    private float               timeSinceLastShoot;

    private Vector3             targetRotation;
    private Vector3             finalTarget;
    private Vector3             gunOffset;

    private bool                isReloading;

    private void Start()
    {
        gunInfo = this.GetComponent<IGunLogicController>();
        gunSoundController = this.GetComponent<GunSoundController>();

        timeSinceLastShoot = weaponData.getFireRate();

        gunOffset = new Vector3(0.7f, -0.2f, -1.0f);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        isReloading = gunInfo.getBoolReload();

        timeSinceLastShoot += Time.deltaTime;

        // Hacer que el ShooterController siga al jugador con un retraso
        Vector3 targetPosition = playerT.position + gunOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, gunFollowSpeed);

        targetRotation = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;

        bulletSpawn.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));
        gunT.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));

        if (angle > 90 || angle < -90)
            spriteRenderer.flipY = true;
        else
            spriteRenderer.flipY = false;

        if (Input.GetMouseButton(0) && timeSinceLastShoot >= weaponData.getFireRate() && !isReloading)
        {
            StartCoroutine(gunSoundController.Shoot());
            Shoot();
            gunInfo.Shoot();
            timeSinceLastShoot = 0.0f;
        }
            
    }

    private void Shoot()
    {
        for (int i = 1; i <= weaponData.getBulletsPerShot(); i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation, transform.parent);

            targetRotation.z = 0.0f;
            finalTarget = (targetRotation - transform.position).normalized;

            // Generar un �ngulo aleatorio dentro del rango de desviaci�n
            float deviationAngle = Random.Range(-weaponData.getAccuracy(), weaponData.getAccuracy());

            // Convertir el �ngulo a radianes
            float deviationAngleRad = deviationAngle * Mathf.Deg2Rad;

            // Calcular la desviaci�n aplicando el �ngulo a la direcci�n original
            Vector3 deviation = Quaternion.Euler(0f, deviationAngle, 0f) * finalTarget;

            // Aplicar la desviaci�n a la direcci�n final del objetivo
            Vector3 finalDirection = finalTarget + deviation;

            bullet.GetComponent<Rigidbody2D>().AddForce(finalDirection * bulletData.getBulletSpeed(), ForceMode2D.Impulse);
        }
    }
}