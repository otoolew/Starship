using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public KeyCode fireWeaponKey;

    public WeaponSystem[] weaponSystems;
    public Weapon LoadedWeapon;
    public Transform weaponMount;
    // Use this for initialization
    void Start () {
        LoadWeapon(weaponSystems[0]);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.R))
        {
            LoadWeapon(weaponSystems[0]);
        }
        if (Input.GetKey(KeyCode.F))
        {
            LoadWeapon(weaponSystems[1]);
        }
        if (Input.GetKeyDown(fireWeaponKey))
        {

            Fire();
        }
    }
    public void LoadWeapon(WeaponSystem weaponSystem)
    {
        LoadedWeapon.WeaponPrefab = weaponSystem.weaponPrefab;
        LoadedWeapon.WeaponName = weaponSystem.weaponName;
        LoadedWeapon.MunitionPrefab = weaponSystem.munitionPrefab;
        LoadedWeapon.WeaponRange = weaponSystem.weaponRange;
        LoadedWeapon.WeaponPower = weaponSystem.weaponPower;
        LoadedWeapon.WeaponCooldown = weaponSystem.weaponCooldown;
        LoadedWeapon.WeaponTimer = weaponSystem.weaponCooldown;
    }
    private void Fire()
    {
        Instantiate(LoadedWeapon.MunitionPrefab, weaponMount);      
    }
}
