using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunShotingController : MonoBehaviour, IGunLogicController
{
    [SerializeField] WeaponModel    weaponData;

    [SerializeField] Image          fillImage;

    [SerializeField] GameObject     weaponName;
    [SerializeField] GameObject     weaponAmmoInfo;

    private int maxAmmo;
    private int magazine;

    private GunSoundController soundController;

    private bool isReloading;

    private void Awake()
    {
        soundController = this.GetComponent<GunSoundController>();
        this.maxAmmo = weaponData.getMagazine();
        this.magazine = weaponData.getMagazine();

        this.isReloading = false;

        weaponName.GetComponent<TextMeshProUGUI>().text = weaponData.name.ToString();
        weaponAmmoInfo.GetComponent<TextMeshProUGUI>().text = magazine.ToString() + " / " + maxAmmo.ToString();
    }

    private void Update()
    {
        if (!isReloading)
        {
            fillImage.GetComponentInParent<Canvas>().enabled = false;
        }
        weaponName.GetComponent<TextMeshProUGUI>().text = weaponData.name.ToString();
        weaponAmmoInfo.GetComponent<TextMeshProUGUI>().text = magazine.ToString() + " / " + maxAmmo.ToString();
    }

    public void Shoot()
    {
        this.magazine -= 1;
        if (this.magazine <= 0)
        {
            this.isReloading = true;
            StartCoroutine(Relaod());
        }
    }

    public bool getBoolReload()
    {
        return isReloading;
    }

    private IEnumerator Relaod()
    {
        StartCoroutine(soundController.Reload());

        fillImage.GetComponentInParent<Canvas>().enabled = true;

        fillImage.fillAmount = 0.0f;

        float timeElapsed = 0.0f;

        while (timeElapsed < weaponData.getReloadTime())
        {
            timeElapsed += Time.deltaTime;
            fillImage.fillAmount = Mathf.Lerp(0.0f, 1.0f, timeElapsed / weaponData.getReloadTime());
            yield return null;
        }
        fillImage.fillAmount = 1.0f;
        isReloading = false;
        magazine = maxAmmo;
    }
}
