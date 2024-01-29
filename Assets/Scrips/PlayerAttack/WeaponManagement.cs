using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    [SerializeField] List<GameObject>   weapons;
    [SerializeField] float              swapDelay;

    private IGunLogicController gunInfo;

    private GameObject          currentWeapon;

    private float               currentTime;

    private int                 currentWeaponIndex;

    private bool isReloading;

    private void Start()
    {
        isReloading = false;

        currentTime = 0.0f;

        currentWeapon = weapons[0];
        currentWeaponIndex = 0;

        gunInfo = currentWeapon.GetComponent<IGunLogicController>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        isReloading = gunInfo.getBoolReload();

        if (Input.GetKeyDown(KeyCode.Q) && currentTime >= swapDelay  && !isReloading)
        {
            currentWeaponIndex++;
            if (currentWeaponIndex > weapons.Count - 1)
            { 
                currentWeaponIndex = 0; 
            }
            SwapWeapon();
            gunInfo = currentWeapon.GetComponent<IGunLogicController>();
        }
    }

    private void SwapWeapon()
    {
        currentWeapon.SetActive(false);
        currentWeapon = weapons[currentWeaponIndex];
        currentWeapon.SetActive(true);
    }
}
