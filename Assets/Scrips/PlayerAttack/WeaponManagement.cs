using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    [SerializeField] List<GameObject>   weapons;
    [SerializeField] float              swapDelay;

    private GameObject  currentWeapon;

    private float       currentTime;

    private int         currentWeaponIndex;

    private void Start()
    {
        currentTime = 0.0f;

        currentWeapon = weapons[0];
        currentWeaponIndex = 0;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q) && currentTime >= swapDelay)
        {
            currentWeaponIndex++;
            if (currentWeaponIndex > weapons.Count - 1)
            { 
                currentWeaponIndex = 0; 
            }
            SwapWeapon();
        }
    }

    private void SwapWeapon()
    {
        currentWeapon.SetActive(false);
        currentWeapon = weapons[currentWeaponIndex];
        currentWeapon.SetActive(true);
    }
}
