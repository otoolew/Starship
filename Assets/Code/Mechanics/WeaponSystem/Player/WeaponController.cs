﻿// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  OCT 2018
// ----------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public KeyCode fireWeaponKey;

    public WeaponSystem[] weaponSystems;
    public List<Weapon> WeaponList;
    public int weaponIndex;
    public Transform weaponMount;

    private void Awake()
    {
        WeaponList = new List<Weapon>();
        LoadWeaponSystems();
    }
    // Use this for initialization
    private void Start ()
    {
        weaponIndex = 0;
        //LoadWeapon(WeaponList[0]);
    }
	
	// Update is called once per frame
	private void Update ()
    {
        if (Input.GetKey(KeyCode.R))
        {
            weaponIndex = 0;
            //LoadWeapon(WeaponList[0]);
        }
        if (Input.GetKey(KeyCode.F))
        {
            weaponIndex = 1;
            //LoadWeapon(WeaponList[1]);
        }
        if (Input.GetKeyDown(fireWeaponKey))
        {
            Fire();
        }
        CooldownWeapons();
    }
    /// <summary>
    /// Load Weapons into a collection.
    /// </summary>
    public void LoadWeaponSystems()
    {
        for (int i = 0; i < weaponSystems.Length; i++)
        {
            WeaponList.Add(MountWeapon(weaponSystems[i]));
        }
    }
    /// <summary>
    /// Used when LoadWeaponSystems is called.
    /// </summary>
    /// <param name="weaponSystem"></param>
    /// <returns></returns>
    private Weapon MountWeapon(WeaponSystem weaponSystem)
    {
        Weapon weapon = new Weapon
        {
            WeaponPrefab = weaponSystem.weaponPrefab,
            WeaponName = weaponSystem.weaponName,
            MunitionPrefab = weaponSystem.munitionPrefab,
            WeaponRange = weaponSystem.weaponRange,
            WeaponPower = weaponSystem.weaponPower,
            WeaponCooldown = weaponSystem.weaponCooldown,
            WeaponTimer = weaponSystem.weaponCooldown
        };
        return weapon;
    }

    private void CooldownWeapons()
    {
        foreach (var item in WeaponList)
        {
            item.WeaponTimer -= Time.deltaTime;
            if (item.WeaponTimer <= 0)
            {
                item.WeaponTimer = 0;
                item.WeaponReady = true;
            }
            else
            {
                item.WeaponReady = false;
            }
        }
    }
    private void Fire()
    {
        if (WeaponList[weaponIndex].WeaponReady)
        {
            WeaponList[weaponIndex].WeaponTimer = WeaponList[weaponIndex].WeaponCooldown;
            Instantiate(WeaponList[weaponIndex].MunitionPrefab, weaponMount);
        }
    }

}